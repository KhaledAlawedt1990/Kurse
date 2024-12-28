using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FührerScheinWinForm
{
    public partial class frmUpdate_AddNewPerson : Form
    {
        public frmUpdate_AddNewPerson()
        {
            InitializeComponent();
        }

        private void userControl11_OnKalkulationCompleted(object sender, UserControl1.KalkulationCompletedEventArgs e)
        {
            MessageBox.Show($"Result = {e.result}, Wert1 = {e.wert1}, Wert2 = {e.wert2} ");
        }
    }
}
