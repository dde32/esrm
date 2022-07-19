using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

namespace ESRM.Win
{
    public partial class FinishDlg : Form
    {
        DispatcherTimer dispatcherTimer;
        int count = 5;

        public FinishDlg(int teamColor, int lapCount)
        {

            InitializeComponent();

            lblLapCount.Text = lapCount.ToString();
            panelColor.BackColor = Color.FromArgb(teamColor);


            //  DispatcherTimer setup
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            count--;
            if (count == 0)
            {
                dispatcherTimer.Stop();
                Close();
            }
        }

        private void panelColor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
 
}
