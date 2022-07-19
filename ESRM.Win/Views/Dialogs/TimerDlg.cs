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
using ESRM.Win.Views;

namespace ESRM.Win
{
    public partial class TimerDlg : Form
    {
        DispatcherTimer dispatcherTimer;
        RaceManager _helper ;
        int count = 5;

        public TimerDlg(RaceManager helper)
        {
            _helper = helper;

            InitializeComponent();
            //  DispatcherTimer setup
            //_helper.PlaySoundAsync(Entities.SoundEnum.Beep);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            count--;
            // Updating the Label which displays the current second
            lblTimer.Text = count.ToString();
            //if (count > 0)
            //    _helper.PlaySoundAsync(Entities.SoundEnum.Beep);
            //else
            //{
            //    dispatcherTimer.Stop();
            //    Close();
            //}
        }

    }
 
}
