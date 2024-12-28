using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ctrBilliardHalle
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public class BilliardTischZeitEndeEventArgs : EventArgs
        {
            public string ZeitText { get; }
            public int ZeitInSekunden { get; }
            public float StundenSatz { get; }
            public float GesamtGebühren { get; }

            public BilliardTischZeitEndeEventArgs(string zeittext, int ZeitInSekunden, float StundenSatz, float GesamtGebühren)
            {
                this.ZeitText = zeittext;
                this.ZeitInSekunden = ZeitInSekunden;
                this.StundenSatz = StundenSatz;
                this.GesamtGebühren = GesamtGebühren;
            }
        }

        public event EventHandler<BilliardTischZeitEndeEventArgs> OnTischZeitZuEnde;

        public void OnZeitZuEndeFreigabe(string zeittext, int zeitInSekunden, float Stundensatz, float GesamtGebühren)
        {
            OnZeitZuEndeFreigabe(new BilliardTischZeitEndeEventArgs(zeittext, zeitInSekunden, Stundensatz, GesamtGebühren));
        }

        protected virtual void OnZeitZuEndeFreigabe(BilliardTischZeitEndeEventArgs e)
        {
            OnTischZeitZuEnde?.Invoke(this, e);
        }

        private int _Sekunde;
        private string _TischTitel = "Tisch";
        // The Category attribute tells the designer to display  
        // it in the Flash grouping.
        // The Description attribute provides a description of  
        // the property.
        [
            Category("Billiard Config"),
            Description("Der Tisch name")
        ]

        public string TischTitel
        {
            get
            {
                return _TischTitel;
            }
            set
            {
                _TischTitel = value;
                gbBilliardTisch.Text = value;
            }
        }

        private string _TischSpieler = "Spieler";
        [
            Category("Billiard Config"),
            Description("der Spieler name")
        ]

        public string TischSpieler
        {
            get
            {
                return _TischSpieler;
            }
            set
            {
                _TischSpieler = value;
                lblSpieler.Text = value;
            }
        }

        private float _StundenSatz = 10.00F;
        [
            Category("Billiard Config"),
            Description("Stundensatz")
        ]

        public float StundenStaz
        {
            get
            {
                return _StundenSatz;
            }
            set
            {
                _StundenSatz = value;

            }
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            gbBilliardTisch.Text = _TischTitel;
            lblSpieler.Text = _TischSpieler;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Start")
            {
                btnStartStop.Text = "Stop";
                timer1.Start();
            }
            else
            {
                btnStartStop.Text = "Start";
                timer1.Stop();
            }
        }

        private void btnBeenden_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            float GesamteGebühren = ((float)_Sekunde / 60 / 60) * _StundenSatz;
            OnZeitZuEndeFreigabe(lblTime.Text, _Sekunde, StundenStaz, GesamteGebühren);
            gbBilliardTisch.Text = "Tisch";
            lblSpieler.Text = "Spieler";
            lblTime.Text = "00:00:00";
            btnStartStop.Text = "Start";
            _Sekunde = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _Sekunde++;
            TimeSpan time = TimeSpan.FromSeconds(_Sekunde);
            string str = time.ToString(@"hh\:mm\:ss");
            lblTime.Text = str;
            lblTime.Refresh();
        }
    }
}
