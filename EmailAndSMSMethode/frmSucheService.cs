using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailAndSMSMethode
{
    public partial class frmSucheService : Form
    {
        public frmSucheService()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string erhalten = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(erhalten))
            {
                erhalten = await clsParfümSucheService.SendMessageToServerAsync(erhalten);
        
            }
            textBox1.Text = erhalten;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
