using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class LoadFileForm : Form
    {
        public string Path { get; set; }
        public double Lower { get; set; }

        public LoadFileForm()
        { 
            InitializeComponent();
        }

        public LoadFileForm(string path, double lower)
        {
            this.Path = path;
            this.Lower = lower;
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            this.FFT_bgWorker_DoWork(sender, null);
            ////
            ///Делаем кнопку результата активной
            showResButton.Enabled = true;
            showResButton.BackColor = Color.Red;
        }

        //FFT
        private void FFT_bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            
            for (int i = 0; i < 100; i++)
            {
                FFT_bgWorker_ProgressChanged(sender, null);
            }

        }

        private void FFT_bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FFTProgressBar.Increment(1);
        }

        private void FFT_bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void LoadFileForm_Load(object sender, EventArgs e)
        {

        }

        private void showResButton_Click(object sender, EventArgs e)
        {
            ///Создание формы результата
            ///
            ResultForm resForm = new ResultForm();
            resForm.Show();
        }
    }
}
