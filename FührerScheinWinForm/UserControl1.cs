using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FührerScheinWinForm
{
    public partial class UserControl1 : UserControl
    {
        public class KalkulationCompletedEventArgs : EventArgs
        {
            public int wert1 { get; }
            public int wert2 { get; }
           public  int result { get; }

            public KalkulationCompletedEventArgs(int wert1, int wert2, int result)
            {
                this.wert1 = wert1;
                this.wert2 = wert2;
                this.result = result;
            }
        }

        public event EventHandler<KalkulationCompletedEventArgs> OnKalkulationCompleted;

        protected virtual void FreigabeKompleteKalkulation(KalkulationCompletedEventArgs e)
        {
            OnKalkulationCompleted?.Invoke(this, e);
        }

        public void FreigabeKompleteKalkulation(int wert1, int wert2, int result)
        {
            FreigabeKompleteKalkulation(new KalkulationCompletedEventArgs(wert1, wert2, result));
        }



        public UserControl1()
        {
            InitializeComponent();
        }

        //public event Action<int> OnKalkulationCompleted;
        
        //protected virtual void KalkulationCompleted(int result)
        //{
        //    Action<int> handler = OnKalkulationCompleted;
        //    if(handler != null)
        //    {
        //        handler(result);
        //    }
        //}
        private void btnKalkulieren_Click(object sender, EventArgs e)
        {
            int wert1 = int.Parse(textBox1.Text);
            int wert2 = int.Parse(textBox2.Text);
            int result = wert1 + wert2;

            lblResult.Text = result.ToString();

            if (OnKalkulationCompleted != null)
                FreigabeKompleteKalkulation(wert1, wert2, result);

            
        }
    }
}
