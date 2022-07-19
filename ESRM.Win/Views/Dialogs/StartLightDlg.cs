using ESRM.Entities;
using ESRM.Win.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

namespace ESRM.Win
{
    public partial class StartLightDlg : Form
    {
        System.Timers.Timer _blinkTimer;
        int _blinkCount;
        bool _showPaceCarMessage;
        bool _warningLight;
        BackgroundWorker worker;


    

    public StartLightDlg()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
        }

        protected override void OnShown(EventArgs e)
        {
            lblPaceCar.Visible = false;
            _showPaceCarMessage = false;
            HideAllRedLights();
            this.CenterToParent();
            base.OnShown(e);         
        }


        public void ShowRedLight(int number)
        {
            switch(number)
            {
                case 1:
                    pb5.Image = Images.RedFlag;
                    break;
                case 2:
                    pb4.Image = Images.RedFlag;
                    break;
                case 3:
                    pb3.Image = Images.RedFlag;
                    break;
                case 4:
                    pb2.Image = Images.RedFlag;
                    break;
                case 5:
                    pb1.Image = Images.RedFlag;
                    break;
            }
        }

        public void HideAllRedLights()
        {
            pb1.Image = Images.DisabledLight;
            pb2.Image = Images.DisabledLight;
            pb3.Image = Images.DisabledLight;
            pb4.Image = Images.DisabledLight;
            pb5.Image = Images.DisabledLight;
        }

        public void AllGreen()
        {
            pb1.Image = Images.GreenFlag;
            pb2.Image = Images.GreenFlag;
            pb3.Image = Images.GreenFlag;
            pb4.Image = Images.GreenFlag;
            pb5.Image = Images.GreenFlag;
        }

        public void CloseDialog()
        {
            _blinkTimer.Stop();
            _blinkTimer.Dispose();
            _blinkTimer = null;


            base.Close();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            InternalWarningLights();
        }
        public void WarningLights()
        {
            if (worker.IsBusy)
                return;

            worker.RunWorkerAsync();
        }

        private void InternalWarningLights()
        {
            if (!_warningLight)
            {
                _warningLight = true;
                HideAllRedLights();

                if (_blinkTimer == null)
                {
                    _blinkTimer = new System.Timers.Timer();
                    _blinkTimer.Interval = 500;
                    _blinkTimer.Elapsed += BlinkTimer_Elapsed;
                    _blinkTimer.Enabled = true;
                    _blinkTimer.Start();
                }
                else
                {
                    _blinkTimer.Stop();
                    _blinkTimer.Enabled = true;
                    _blinkTimer.Start();
                }
            }
        }

        public void StopWarningLights()
        {
            worker.CancelAsync();

            _warningLight = false;
            _blinkTimer.Stop();
            HideAllRedLights();
            Hide();
            lblPaceCar.Visible = false;
        }

        public void SafetyCarInThisLap()
        {
            this.BeginInvoke(new StandardCallBack(InternalSafetyCarInThisLap));
        }
        private void InternalSafetyCarInThisLap()
        {
            _showPaceCarMessage = true;
            //lblPaceCar.Visible = true;
            _blinkTimer.Interval = 50;

        }
        private void BlinkTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _blinkCount++;

            if (!_showPaceCarMessage)
            {

                if (_blinkCount == 1)
                {
                    pb1.Image = Images.YellowFlag;
                    pb2.Image = Images.DisabledLight;
                    pb3.Image = Images.YellowFlag;
                    pb4.Image = Images.DisabledLight;
                    pb5.Image = Images.YellowFlag;
                    //if (_showPaceCarMessage)
                    //    lblPaceCar.ForeColor = Color.White;
                }
                else
                {
                    _blinkCount = 0;
                    pb1.Image = Images.DisabledLight;
                    pb2.Image = Images.YellowFlag;
                    pb3.Image = Images.DisabledLight;
                    pb4.Image = Images.YellowFlag;
                    pb5.Image = Images.DisabledLight;
                    //if (_showPaceCarMessage)
                    //    lblPaceCar.ForeColor = Color.YellowGreen;
                }
            }
            else
            {
                switch (_blinkCount)
                {
                    case 1:
                        pb5.Image = Images.DisabledLight;
                        pb1.Image = Images.YellowFlag;
                        break;
                    case 2:
                        //pb1.Image = Images.DisabledLight;
                        pb2.Image = Images.YellowFlag;
                        break;
                    case 3:
                        pb1.Image = Images.DisabledLight;
                        pb3.Image = Images.YellowFlag;
                        break;
                    case 4:
                        pb2.Image = Images.DisabledLight;
                        pb4.Image = Images.YellowFlag;
                        break;
                    case 5:
                        pb3.Image = Images.DisabledLight;
                        pb5.Image = Images.YellowFlag;
                        break;
                    case 6:
                        pb4.Image = Images.DisabledLight;
                        //pb4.Image = Images.YellowFlag;
                        break;
                    case 7:
                        pb4.Image = Images.YellowFlag;
                        //pb3.Image = Images.YellowFlag;
                        break;
                    case 8:
                        pb5.Image = Images.DisabledLight;
                        pb3.Image = Images.YellowFlag;
                        break;
                    case 9:
                        pb4.Image = Images.DisabledLight;
                        pb2.Image = Images.YellowFlag;
                        break;
                    case 10:
                        pb3.Image = Images.DisabledLight;
                        pb1.Image = Images.YellowFlag;
                        break;
                    case 11:
                        pb2.Image = Images.DisabledLight;
                        _blinkCount = 0;
                        break;
                }
            }


        }

    }
}
