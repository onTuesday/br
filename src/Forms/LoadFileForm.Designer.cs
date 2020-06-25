namespace Forms
{
    partial class LoadFileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resLabel = new System.Windows.Forms.Label();
            this.FFTProgressBar = new System.Windows.Forms.ProgressBar();
            this.convertToWavLabel = new System.Windows.Forms.Label();
            this.FFTLabel = new System.Windows.Forms.Label();
            this.showResButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.FFT_bgWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.loadFileLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.ConverterBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // resLabel
            // 
            this.resLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resLabel.Location = new System.Drawing.Point(9, 9);
            this.resLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.resLabel.Name = "resLabel";
            this.resLabel.Size = new System.Drawing.Size(384, 31);
            this.resLabel.TabIndex = 0;
            this.resLabel.Text = "Результат обработки";
            // 
            // FFTProgressBar
            // 
            this.FFTProgressBar.Location = new System.Drawing.Point(316, 175);
            this.FFTProgressBar.Name = "FFTProgressBar";
            this.FFTProgressBar.Size = new System.Drawing.Size(229, 23);
            this.FFTProgressBar.TabIndex = 1;
            this.FFTProgressBar.Click += new System.EventHandler(this.FFTProgressBar_Click);
            // 
            // convertToWavLabel
            // 
            this.convertToWavLabel.AutoSize = true;
            this.convertToWavLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.convertToWavLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.convertToWavLabel.Location = new System.Drawing.Point(27, 126);
            this.convertToWavLabel.Name = "convertToWavLabel";
            this.convertToWavLabel.Size = new System.Drawing.Size(105, 13);
            this.convertToWavLabel.TabIndex = 3;
            this.convertToWavLabel.Text = "Конвертация в wav";
            // 
            // FFTLabel
            // 
            this.FFTLabel.AutoSize = true;
            this.FFTLabel.Location = new System.Drawing.Point(27, 185);
            this.FFTLabel.Name = "FFTLabel";
            this.FFTLabel.Size = new System.Drawing.Size(72, 13);
            this.FFTLabel.TabIndex = 4;
            this.FFTLabel.Text = "БПФ анализ";
            // 
            // showResButton
            // 
            this.showResButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.showResButton.Enabled = false;
            this.showResButton.Location = new System.Drawing.Point(14, 250);
            this.showResButton.Name = "showResButton";
            this.showResButton.Size = new System.Drawing.Size(189, 49);
            this.showResButton.TabIndex = 5;
            this.showResButton.Text = "Показать результат";
            this.showResButton.UseVisualStyleBackColor = false;
            this.showResButton.Click += new System.EventHandler(this.showResButton_Click);
            // 
            // runButton
            // 
            this.runButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.runButton.Location = new System.Drawing.Point(338, 250);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(175, 48);
            this.runButton.TabIndex = 6;
            this.runButton.Text = "Начать обработку";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // FFT_bgWorker
            // 
            this.FFT_bgWorker.WorkerReportsProgress = true;
            this.FFT_bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FFT_bgWorker_DoWork);
            this.FFT_bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FFT_bgWorker_ProgressChanged);
            this.FFT_bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FFT_bgWorker_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(686, 71);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(75, 23);
            this.loadFileButton.TabIndex = 7;
            this.loadFileButton.Text = "Обзор";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // loadFileLabel
            // 
            this.loadFileLabel.AutoSize = true;
            this.loadFileLabel.Location = new System.Drawing.Point(27, 76);
            this.loadFileLabel.Name = "loadFileLabel";
            this.loadFileLabel.Size = new System.Drawing.Size(88, 13);
            this.loadFileLabel.TabIndex = 8;
            this.loadFileLabel.Text = "Загрузить файл";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "loadFile";
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(316, 73);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(353, 20);
            this.fileTextBox.TabIndex = 9;
            // 
            // ConverterBackgroundWorker
            // 
            this.ConverterBackgroundWorker.WorkerReportsProgress = true;
            this.ConverterBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ConverterBackgroundWorker_DoWork);
            this.ConverterBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ConverterBackgroundWorker_RunWorkerCompleted);
            // 
            // LoadFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.loadFileLabel);
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.showResButton);
            this.Controls.Add(this.FFTLabel);
            this.Controls.Add(this.convertToWavLabel);
            this.Controls.Add(this.resLabel);
            this.Controls.Add(this.FFTProgressBar);
            this.Name = "LoadFileForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoadFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label resLabel;
        private System.Windows.Forms.ProgressBar FFTProgressBar;
        private System.Windows.Forms.Label convertToWavLabel;
        private System.Windows.Forms.Label FFTLabel;
        private System.Windows.Forms.Button showResButton;
        private System.Windows.Forms.Button runButton;
        private System.ComponentModel.BackgroundWorker FFT_bgWorker;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Label loadFileLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.ComponentModel.BackgroundWorker ConverterBackgroundWorker;
    }
}