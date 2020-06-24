namespace Forms
{
    partial class ResultForm
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
            this.FFTshResButton = new System.Windows.Forms.Button();
            this.AmpShRes = new System.Windows.Forms.Button();
            this.PlayerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resLabel
            // 
            this.resLabel.AutoSize = true;
            this.resLabel.Font = new System.Drawing.Font("Bauhaus 93", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resLabel.Location = new System.Drawing.Point(162, 9);
            this.resLabel.Name = "resLabel";
            this.resLabel.Size = new System.Drawing.Size(364, 42);
            this.resLabel.TabIndex = 0;
            this.resLabel.Text = "Результат обработки";
            this.resLabel.Click += new System.EventHandler(this.resLabel_Click);
            // 
            // FFTshResButton
            // 
            this.FFTshResButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.FFTshResButton.FlatAppearance.BorderSize = 0;
            this.FFTshResButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FFTshResButton.Location = new System.Drawing.Point(190, 109);
            this.FFTshResButton.Name = "FFTshResButton";
            this.FFTshResButton.Size = new System.Drawing.Size(320, 38);
            this.FFTshResButton.TabIndex = 1;
            this.FFTshResButton.Text = "БПФ график";
            this.FFTshResButton.UseVisualStyleBackColor = false;
            this.FFTshResButton.Click += new System.EventHandler(this.resLabel_Click);
            // 
            // AmpShRes
            // 
            this.AmpShRes.BackColor = System.Drawing.SystemColors.HotTrack;
            this.AmpShRes.FlatAppearance.BorderSize = 0;
            this.AmpShRes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AmpShRes.Location = new System.Drawing.Point(190, 183);
            this.AmpShRes.Name = "AmpShRes";
            this.AmpShRes.Size = new System.Drawing.Size(320, 38);
            this.AmpShRes.TabIndex = 2;
            this.AmpShRes.Text = "График амплитуды от частоты";
            this.AmpShRes.UseVisualStyleBackColor = false;
            // 
            // PlayerButton
            // 
            this.PlayerButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PlayerButton.FlatAppearance.BorderSize = 0;
            this.PlayerButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PlayerButton.Location = new System.Drawing.Point(190, 246);
            this.PlayerButton.Name = "PlayerButton";
            this.PlayerButton.Size = new System.Drawing.Size(320, 38);
            this.PlayerButton.TabIndex = 3;
            this.PlayerButton.Text = "Проигрыватель";
            this.PlayerButton.UseVisualStyleBackColor = false;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PlayerButton);
            this.Controls.Add(this.AmpShRes);
            this.Controls.Add(this.FFTshResButton);
            this.Controls.Add(this.resLabel);
            this.Name = "ResultForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resLabel;
        private System.Windows.Forms.Button FFTshResButton;
        private System.Windows.Forms.Button AmpShRes;
        private System.Windows.Forms.Button PlayerButton;
    }
}