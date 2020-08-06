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

        public LoadFileForm()
        {
            this.wav = new WavFile();
            InitializeComponent();
            this.convertToWavLabel.Enabled = false;
            this.showResButton.BackColor = Color.Gray;
            
        }


        private void runButton_Click(object sender, EventArgs e)
        {
            runButton.Enabled = false;
            //Конвертация файла в wav(если требуется)
            if (this.type == FileType.Mp3 || this.type == FileType.Mp4)
            {
                this.convertToWavLabel.Enabled = true;
                ConverterBackgroundWorker.RunWorkerAsync();
            }

            //Заполнение структуры wav файла данными 
            Analizator.GetWaveData(ref this.wav);

            //Посекундное БПФ левой и правой дорожки
            FFT_bgWorker.RunWorkerAsync();
        }

        

        private void LoadFileForm_Load(object sender, EventArgs e)
        {

        }

        private void showResButton_Click(object sender, EventArgs e)
        {
            ///Создание формы результата
            ///
            ResGraphick resForm = new ResGraphick(this.wav);
            resForm.Show();
        }


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


        private void ConverterBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void ConverterBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.convertToWavLabel.Enabled = false;
        }
        #endregion

        #region FFTBgworker
        //Посекундное БПФ преобразование 
        private void FFT_bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int progressCount = (wav.Samplerate * wav.Length) / 10;
            wav.FFTleft = new double[wav.Length * wav.Samplerate / 2 + 1];
            wav.FFTright = new double[wav.Length * wav.Samplerate / 2 + 1];
            for (int i = 0, p = 0; i < wav.Length; i++, p+=wav.Samplerate)
            {
                double[] toFFTleft = SubArray(wav.Left, i * wav.Samplerate, wav.Samplerate);
                double[] toFFTright = SubArray(wav.Right, i * wav.Samplerate, wav.Samplerate);
                double[] resFFTleft = Analizator.FFT(toFFTleft);
                double[] resFFTright = Analizator.FFT(toFFTright);
                for (int j = 0; j < wav.Samplerate / 2; j++)
                {
                    wav.FFTleft[j] = resFFTleft[j];
                    wav.FFTright[j] = resFFTright[j];
                }
                if (p >= progressCount)
                {
                    FFT_bgWorker.ReportProgress(9);
                    p = 0;
                }
            }
            FFT_bgWorker.ReportProgress(1);
        }

        //Инкремент прогресс бара БПФ преобразования
        private void FFT_bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FFTProgressBar.Increment(10);
        }

        //Делаем кнопку показания результата активной
        private void FFT_bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.showResButton.BackColor = Color.LimeGreen;
            this.showResButton.Enabled = true;
        }
        #endregion

        /// <summary>
        /// Возвращает подмассив заданного массива
        /// </summary>
        /// <param name="src">Исходный массив</param>
        /// <param name="index">Начальный индекс</param>
        /// <param name="length">Длина</param>
        /// <returns></returns>
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



    }
}
