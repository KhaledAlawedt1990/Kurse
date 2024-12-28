namespace BilliardHalle
{
    partial class Form1
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.userControl11 = new ctrBilliardHalle.UserControl1();
            this.userControl12 = new ctrBilliardHalle.UserControl1();
            this.userControl13 = new ctrBilliardHalle.UserControl1();
            this.userControl14 = new ctrBilliardHalle.UserControl1();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userControl11.Location = new System.Drawing.Point(2, 2);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(601, 450);
            this.userControl11.StundenStaz = 10F;
            this.userControl11.TabIndex = 0;
            this.userControl11.TischSpieler = "Spieler";
            this.userControl11.TischTitel = "Tisch";
            // 
            // userControl12
            // 
            this.userControl12.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userControl12.Location = new System.Drawing.Point(618, 2);
            this.userControl12.Name = "userControl12";
            this.userControl12.Size = new System.Drawing.Size(601, 450);
            this.userControl12.StundenStaz = 10F;
            this.userControl12.TabIndex = 1;
            this.userControl12.TischSpieler = "Spieler";
            this.userControl12.TischTitel = "Tisch";
            // 
            // userControl13
            // 
            this.userControl13.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userControl13.Location = new System.Drawing.Point(2, 458);
            this.userControl13.Name = "userControl13";
            this.userControl13.Size = new System.Drawing.Size(601, 450);
            this.userControl13.StundenStaz = 10F;
            this.userControl13.TabIndex = 2;
            this.userControl13.TischSpieler = "Spieler";
            this.userControl13.TischTitel = "Tisch";
            // 
            // userControl14
            // 
            this.userControl14.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userControl14.Location = new System.Drawing.Point(618, 458);
            this.userControl14.Name = "userControl14";
            this.userControl14.Size = new System.Drawing.Size(601, 450);
            this.userControl14.StundenStaz = 10F;
            this.userControl14.TabIndex = 3;
            this.userControl14.TischSpieler = "Spieler";
            this.userControl14.TischTitel = "Tisch";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 910);
            this.Controls.Add(this.userControl14);
            this.Controls.Add(this.userControl13);
            this.Controls.Add(this.userControl12);
            this.Controls.Add(this.userControl11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrBilliardHalle.UserControl1 userControl11;
        private ctrBilliardHalle.UserControl1 userControl12;
        private ctrBilliardHalle.UserControl1 userControl13;
        private ctrBilliardHalle.UserControl1 userControl14;
    }
}

