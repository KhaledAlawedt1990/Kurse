namespace ctrBilliardHalle
{
    partial class UserControl1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbBilliardTisch = new System.Windows.Forms.GroupBox();
            this.lblSpieler = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnBeenden = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbBilliardTisch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Image = global::ctrBilliardHalle.Properties.Resources.pool1;
            this.pictureBox1.Location = new System.Drawing.Point(6, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(397, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gbBilliardTisch
            // 
            this.gbBilliardTisch.Controls.Add(this.btnBeenden);
            this.gbBilliardTisch.Controls.Add(this.btnStartStop);
            this.gbBilliardTisch.Controls.Add(this.lblTime);
            this.gbBilliardTisch.Controls.Add(this.lblSpieler);
            this.gbBilliardTisch.Controls.Add(this.pictureBox1);
            this.gbBilliardTisch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBilliardTisch.ForeColor = System.Drawing.SystemColors.Control;
            this.gbBilliardTisch.Location = new System.Drawing.Point(14, 15);
            this.gbBilliardTisch.Name = "gbBilliardTisch";
            this.gbBilliardTisch.Size = new System.Drawing.Size(570, 418);
            this.gbBilliardTisch.TabIndex = 1;
            this.gbBilliardTisch.TabStop = false;
            this.gbBilliardTisch.Text = "Tisch";
            // 
            // lblSpieler
            // 
            this.lblSpieler.AutoSize = true;
            this.lblSpieler.Location = new System.Drawing.Point(224, 34);
            this.lblSpieler.Name = "lblSpieler";
            this.lblSpieler.Size = new System.Drawing.Size(104, 32);
            this.lblSpieler.TabIndex = 1;
            this.lblSpieler.Text = "Spieler";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(167, 370);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(126, 32);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "00:00:00";
            // 
            // btnStartStop
            // 
            this.btnStartStop.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStartStop.Location = new System.Drawing.Point(409, 225);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(149, 42);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnBeenden
            // 
            this.btnBeenden.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBeenden.Location = new System.Drawing.Point(409, 309);
            this.btnBeenden.Name = "btnBeenden";
            this.btnBeenden.Size = new System.Drawing.Size(149, 42);
            this.btnBeenden.TabIndex = 4;
            this.btnBeenden.Text = "Beenden";
            this.btnBeenden.UseVisualStyleBackColor = false;
            this.btnBeenden.Click += new System.EventHandler(this.btnBeenden_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.gbBilliardTisch);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(601, 450);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbBilliardTisch.ResumeLayout(false);
            this.gbBilliardTisch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbBilliardTisch;
        private System.Windows.Forms.Button btnBeenden;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblSpieler;
        private System.Windows.Forms.Timer timer1;
    }
}
