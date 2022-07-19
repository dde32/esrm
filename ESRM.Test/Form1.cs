using ESRM.Entities;
using ESRM.GamePads;
using ESRM.GamePads.Common;
using ESRM.GamePadV2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Web.Http;

namespace ESRM.Test
{
    public partial class Form1 : Form
    {
        GlobalGamePadHandSet gp;
        ESRMGamePadv2 _esrmGp;
        Thread gpThread;

        public Form1()
        {
            InitializeComponent();

            //_esrmGp = new ESRMGamePadv2(EsrmPlayerIndex.One);
            gpThread = new Thread(CheckButtonStateLoop);
            gpThread.SetApartmentState(ApartmentState.STA);

            //gp = new GlobalGamePadHandSet(_esrmGp);

            //GamePadHandSetv2.IsConnectedByIndex((int)EsrmPlayerIndex.One);


        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckButtonStateLoop();
        }



        private void CheckButtonStateLoop()
        {
            _esrmGp = new ESRMGamePadv2(EsrmPlayerIndex.One);

            while (true)
            {
                Thread.Sleep(50);
                try
                {
                    _esrmGp.CheckButtonState();
                    VibrationValues values = new VibrationValues(_esrmGp.LeftTriggerValue, _esrmGp.RightTriggerValue, _esrmGp.LeftTriggerValue, _esrmGp.RightTriggerValue);
                    //bool b = gp.LaneChangingPressed;
                    //if(values.HasOnePositive)
                    _esrmGp.SetVibration(values);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //gp = new GlobalGamePadHandSet(GamePadFactory.GetESRMGamePad(EsrmPlayerIndex.One));
            //gpThread.Start();
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetTeamById(1);
        }

        protected async void GetTeamById(int teamLaneId)
        {
            try
            {
                string url = "http://localhost:666/teams/team/" + teamLaneId;
                Uri strUri = new Uri(url);
                HttpClient client = new HttpClient();
                await client.GetAsync(strUri);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
