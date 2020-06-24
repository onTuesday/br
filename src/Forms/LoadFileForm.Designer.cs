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
            this.mp3ToWavProgressBar = new System.Windows.Forms.ProgressBar();
            this.mp3ToWavLabel = new System.Windows.Forms.Label();
            this.FFTLabel = new System.Windows.Forms.Label();
            this.showResButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.FFT_bgWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
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
            this.FFTProgressBar.Location = new System.Drawing.Point(12, 101);
            this.FFTProgressBar.Name = "FFTProgressBar";
            this.FFTProgressBar.Size = new System.Drawing.Size(229, 23);
            this.FFTProgressBar.TabIndex = 1;
            // 
            // mp3ToWavProgressBar
            // 
            this.mp3ToWavProgressBar.Location = new System.Drawing.Point(14, 54);
            this.mp3ToWavProgressBar.Name = "mp3ToWavProgressBar";
            this.mp3ToWavProgressBar.Size = new System.Drawing.Size(229, 23);
            this.mp3ToWavProgressBar.TabIndex = 2;
            // 
            // mp3ToWavLabel
            // 
            this.mp3ToWavLabel.AutoSize = true;
            this.mp3ToWavLabel.Location = new System.Drawing.Point(307, 64);
            this.mp3ToWavLabel.Name = "mp3ToWavLabel";
            this.mp3ToWavLabel.Size = new System.Drawing.Size(192, 13);
            this.mp3ToWavLabel.TabIndex = 3;
            this.mp3ToWavLabel.Text = "Конвертация в wav (если требуется)";
            // 
            // FFTLabel
            // 
            this.FFTLabel.AutoSize = true;
            this.FFTLabel.Location = new System.Drawing.Point(310, 110);
            this.FFTLabel.Name = "FFTLabel";
            this.FFTLabel.Size = new System.Drawing.Size(72, 13);
            this.FFTLabel.TabIndex = 4;
            this.FFTLabel.Text = "БПФ анализ";
            // 
            // showResButton
            // 
            this.showResButton.Enabled = false;
            this.showResButton.Location = new System.Drawing.Point(36, 175);
            this.showResButton.Name = "showResButton";
            this.showResButton.Size = new System.Drawing.Size(189, 49);
            this.showResButton.TabIndex = 5;
            this.showResButton.Text = "Показать результат";
            this.showResButton.UseVisualStyleBackColor = true;
            this.showResButton.Click += new System.EventHandler(this.showResButton_Click);
            // 
            // runButton
            // 
            this.runButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.runButton.Location = new System.Drawing.Point(354, 175);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(175, 48);
            this.runButton.TabIndex = 6;
            this.runButton.Text = "Начать обработку";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // FFT_bgWorker
            // 
            this.FFT_bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FFT_bgWorker_DoWork);
            this.FFT_bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FFT_bgWorker_ProgressChanged);
            this.FFT_bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FFT_bgWorker_RunWorkerCompleted);
            // 
            // LoadFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.showResButton);
            this.Controls.Add(this.FFTLabel);
            this.Controls.Add(this.mp3ToWavLabel);
            this.Controls.Add(this.mp3ToWavProgressBar);
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
        private System.Windows.Forms.ProgressBar mp3ToWavProgressBar;
        private System.Windows.Forms.Label mp3ToWavLabel;
        private System.Windows.Forms.Label FFTLabel;
        private System.Windows.Forms.Button showResButton;
        private System.Windows.Forms.Button runButton;
        private System.ComponentModel.BackgroundWorker FFT_bgWorker;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}