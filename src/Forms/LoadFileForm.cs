using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinauralAnalysis;

namespace Forms
{
    public partial class LoadFileForm : Form
    {

        FileType type;
        WavFile wav;
        bool leftChannelCompleted;

        public LoadFileForm()
        {
            this.wav = new WavFile();
            this.leftChannelCompleted = false;
            InitializeComponent();
        }

        /// Конвертация файла в wav, если она нужна, запуск БПФ обработки файла.
        /// При завершении обработки кнопка результата становиться активной.
        private void runButton_Click(object sender, EventArgs e)
        {
            runButton.Enabled = false;
            try
            {
                //Конвертация файла в wav(если требуется)
                if (this.type == FileType.Mp3 || this.type == FileType.Mp4)
                {
                    ConverterBackgroundWorker.RunWorkerAsync();
                }

                //Заполнение структуры wav файла данными 
                Analizator.GetWaveData(ref this.wav);
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                runButton.Enabled = true;
                return;
            }

            //Посекундное БПФ левой и правой дорожки
            //FFT_bgWorker.RunWorkerAsync();
            leftFFTbgWorker.RunWorkerAsync();
            rightFFTbgWorker.RunWorkerAsync();
        }
        
        /// Создаёт и показывает форму результата, скрывает данную форму.
        private void showResButton_Click(object sender, EventArgs e)
        {
            ///Создание формы результата
            ///
            ResGraphick resForm = new ResGraphick(this.wav, this);
            this.Hide();
            resForm.Show();
        }

        /// Открывает OpenFileDialog для выбора файла для обработки.
        private void loadFileButton_Click(object sender, EventArgs e)
        {
            //Получение полного пути файла с помошью openFileDialog
            openFileDialog.Filter = "wav files (*.wav)|*.wav|mp3 files (*.mp3)|*.mp3|mp4 files (*.mp4)|*.mp4|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                wav.Name = openFileDialog.FileName;
                this.fileTextBox.Text = this.wav.Name;
                this.type = (FileType)openFileDialog.FilterIndex;
            }
        }

        #region ConverterBgworker
        /// Производит конвертацию файла в wav в отдельном потоке
        private void ConverterBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ConverterBackgroundWorker.ReportProgress(1);
            //Конвертация файла в wav
            switch (this.type)
            {
                case FileType.Mp3:
                    BinauralAnalysis.Converter.Mp3ToWav(this.wav.Name, "tmpfile.wav");
                    this.wav.Name = "tmpfile.wav";
                    break;

                case FileType.Mp4:
                    //TODO Выделение аудиодорожки из mp4 файла
                    break;
            }
        }
        #endregion

 


        /// Возвращает подмассив заданного массива
        private double[] SubArray(double[] src ,int index, int length)
        {
            double[] tmp = new double[length];
            int lastIndex = index + length;
            for (int i = index, j = 0; i < lastIndex; i++, ++j)
            {
                tmp[j] = src[i];
            }
            return tmp;
        }

        /// При скрывании окна сбрасывает все параметры данного окна до исходных.
        private void LoadFileForm_VisibleChanged(object sender, EventArgs e)
        {
            this.wav = new WavFile();
            this.fileTextBox.Text = "";
            this.showResButton.BackColor = Color.Gray;
            this.showResButton.Enabled = false;
            this.runButton.Enabled = true;
            this.FFTProgressBar.Value = 0;
        }

        #region leftFFT
        private void leftFFTbgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            wav.FFTleft = new double[(wav.Length + 1) * wav.Samplerate / 2 + 100];
            int progressDelta = wav.Samplerate * wav.Length / 10;

            //Посекундное БПФ преобразование и запись результата
            for (int i = 0, p = 0; i < wav.Length; i++, p += wav.Samplerate)
            {
                double[] toFFTleft = SubArray(wav.Left, i * wav.Samplerate, wav.Samplerate);
                
                double[] resFFTleft = SubArray(Analizator.FFT(toFFTleft), 0, wav.Samplerate / 2);
                
                int fftSampleIndex = (wav.Samplerate * i) / 2;
                for (int j = 0; j < wav.Samplerate / 2; j++)
                    wav.FFTleft[fftSampleIndex + j] = resFFTleft[j];
                if (p >= progressDelta)
                {
                    this.leftFFTbgWorker.ReportProgress(1);
                    p = 0;
                }
            }
            this.leftFFTbgWorker.ReportProgress(1);
        }

        private void leftFFTbgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FFTProgressBar.Increment(5);
        }

        private void leftFFTbgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.leftChannelCompleted = true;
        }

        #endregion

        private void rightFFTbgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            wav.FFTright = new double[(wav.Length + 1) * wav.Samplerate / 2 + 50];
            int progressDelta = wav.Samplerate * wav.Length / 10;

            //Посекундное БПФ преобразование и запись результата
            for (int i = 0, p = 0; i < wav.Length; i++, p += wav.Samplerate)
            {
                double[] toFFTright = SubArray(wav.Right, i * wav.Samplerate, wav.Samplerate);

                double[] resFFTright = SubArray(Analizator.FFT(toFFTright), 0, wav.Samplerate / 2);

                int fftSampleIndex = (wav.Samplerate * i) / 2;
                for (int j = 0; j < wav.Samplerate / 2; j++)
                    wav.FFTright[fftSampleIndex + j] = resFFTright[j];
                if (p >= progressDelta)
                {
                    this.rightFFTbgWorker.ReportProgress(1);
                    p = 0;
                }
            }
            while (!this.leftChannelCompleted)
                System.Threading.Thread.Sleep(50);
            this.rightFFTbgWorker.ReportProgress(1);
        }

        private void rightFFTbgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.FFTProgressBar.Increment(5);
        }

        private void rightFFTbgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.showResButton.BackColor = SystemColors.Highlight;
            this.showResButton.Enabled = true;
        }
    }



}
