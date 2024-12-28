namespace ctrBilliardProjekt
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            gbBiliardTisch = new GroupBox();
            lblTime = new Label();
            lblSpieler = new Label();
            btnBeenden = new Button();
            btnStartStop = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbBiliardTisch.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.Image = Properties.Resources.pool;
            pictureBox1.Location = new Point(6, 73);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(322, 187);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // gbBiliardTisch
            // 
            gbBiliardTisch.BackColor = SystemColors.ActiveCaptionText;
            gbBiliardTisch.Controls.Add(lblTime);
            gbBiliardTisch.Controls.Add(lblSpieler);
            gbBiliardTisch.Controls.Add(btnBeenden);
            gbBiliardTisch.Controls.Add(btnStartStop);
            gbBiliardTisch.Controls.Add(pictureBox1);
            gbBiliardTisch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbBiliardTisch.ForeColor = SystemColors.Control;
            gbBiliardTisch.Location = new Point(3, 3);
            gbBiliardTisch.Name = "gbBiliardTisch";
            gbBiliardTisch.Size = new Size(499, 441);
            gbBiliardTisch.TabIndex = 1;
            gbBiliardTisch.TabStop = false;
            gbBiliardTisch.Text = "Tisch";
            gbBiliardTisch.Enter += gbBiliardTisch_Enter;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.Location = new Point(118, 273);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(136, 41);
            lblTime.TabIndex = 4;
            lblTime.Text = "00:00:00";
            lblTime.Click += lblTime_Click;
            // 
            // lblSpieler
            // 
            lblSpieler.AutoSize = true;
            lblSpieler.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSpieler.Location = new Point(166, 30);
            lblSpieler.Name = "lblSpieler";
            lblSpieler.Size = new Size(107, 38);
            lblSpieler.TabIndex = 3;
            lblSpieler.Text = "Spieler";
            // 
            // btnBeenden
            // 
            btnBeenden.ForeColor = SystemColors.ActiveCaptionText;
            btnBeenden.Location = new Point(334, 158);
            btnBeenden.Name = "btnBeenden";
            btnBeenden.Size = new Size(149, 45);
            btnBeenden.TabIndex = 2;
            btnBeenden.Text = "Beenden";
            btnBeenden.UseVisualStyleBackColor = true;
            btnBeenden.Click += btnStop_Click;
            // 
            // btnStartStop
            // 
            btnStartStop.ForeColor = SystemColors.ActiveCaptionText;
            btnStartStop.Location = new Point(334, 82);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(149, 45);
            btnStartStop.TabIndex = 1;
            btnStartStop.Text = "Start";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += btnStart_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            Controls.Add(gbBiliardTisch);
            Name = "UserControl1";
            Size = new Size(505, 332);
            Load += UserControl1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            gbBiliardTisch.ResumeLayout(false);
            gbBiliardTisch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox gbBiliardTisch;
        private Label lblSpieler;
        private Button btnBeenden;
        private Button btnStartStop;
        private Label lblTime;
        private System.Windows.Forms.Timer timer1;
    }
}
