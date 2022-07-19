using System;
using ESRM.Entities;
using System.Windows.Threading;
using System.Drawing;
using ESRM.HWInterfaces;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using ESRM.GamePads;

namespace ESRM.Win.Views
{
    public partial class TestPageSSD : BasePage
    {
        int NbReceveided = 0;
        DispatcherTimer timer;


        ESRMGamePad _pad;
        SmartSensorInterface_ForPitLane ssInterface;

        public TestPageSSD()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0,10);

        }

        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);


            ssInterface = Program.pitSensors;

            _pad = new ESRMGamePad(0);
            //_pad.RightTriggerValueChanged += Pas_RightTriggerValueChanged;
            //_pad.ButtonAPressed += _pad_ButtonAPressed;
        }

        private void _pad_ButtonAPressed(object sender, EventArgs e)
        {
            this.BeginInvoke(new StandardCallBack(ChangePBColor));
        }

        private void Pas_RightTriggerValueChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new StandardCallBack(SetProgressValue));
        }

        public void ChangePBColor()
        {
            simpleButton3.Visible = !simpleButton3.Visible;
            if (progressBar1.ForeColor == Color.Red)
                progressBar1.ForeColor = Color.Violet;
            else
                progressBar1.ForeColor = Color.Red;
        }
        public void SetProgressValue()
        {
            progressBar1.Value = (int) (_pad.RightTriggerValue * 100.0);
        }

        void ssd_NeedRefresh(object sender, EventArgs e)
        {
            //if (AppViewModel.CurrentRace != null && !Program.hwInterface.Paused)
            {
              //this.BeginInvoke(new HardwareInterfaceGetDatasCallback(RefreshSSDDatas), new object[] { null });
                this.BeginInvoke(new HardwareInterfaceGetDatasCallback(RefreshSSDDatas), new object[] { Program.hwInterface.Handsets });
            }
        }

        void RefreshSSDDatas(IHandsetList datas)
        {
            NbReceveided++;
            edtNbReceived.Text = NbReceveided.ToString();
            //this.accel.Value = datas.HandSetList[0].Throttle;
            //this.lblBrake.ForeColor = datas.HandSetList[0].BrakingButtonPressed ? Color.Green : Color.Red;
            //this.lblLC.ForeColor = datas.HandSetList[0].LaneChangingButtonPressed ? Color.Green : Color.Red;
            //this.lblTrackCall.ForeColor = datas.Race.YellowFlag ? Color.Green : Color.Red;

            receivedBox.Text += Environment.NewLine;
            receivedBox.Text += datas.HandSetList[0].Throttle;
        }


        void Race_RaceFinished(object sender, EventArgs e)
        {
        }

        void Race_LapEndedEvent(object sender, EventArgs e)
        {
        }

        void Race_IncidentEvent(object sender, LaneIdEventArgs e)
        {
        }

        void Race_YellowFlagEvent(object sender, EventArgs e)
        {
        }

        void Race_PitStopRefresh(object sender, LaneIdEventArgs e)
        {
            this.BeginInvoke(new RefreshOneTeamCallback(RefreshOneTeam), new object[] { e.LaneId });
        }

        void Race_PitStopEnded(object sender, LaneIdEventArgs e)
        {
            this.BeginInvoke(new RefreshOneTeamCallback(RefreshOneTeam), new object[] { e.LaneId });
        }

        void Race_PitStopBegin(object sender, LaneIdEventArgs e)
        {
            this.BeginInvoke(new RefreshOneTeamCallback(RefreshOneTeam), new object[] { e.LaneId });
        }

        void RefreshOneTeam(int teamId)
        {
        }

        


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Program.hwInterface.StartCommand();
            timer.Tick -= timer_Tick;
            timer.Tick += timer_Tick;
            NbReceveided = 0;
            //Program.hwInterface.ConnectToCommand();
            //Program.StartCommunication();
            Program.hwInterface.DataReceived += ssd_NeedRefresh;
           // AppViewModel.CurrentRace = DefaultDatas.GetDefaultRaceFromParameters(DefaultDatas.GetDefaultRaceParameters(RaceType.GP, null, Program.hwInterface.DigitalParams));
            timer.Start();
            //Program.hwInterface.StartRaceCommand();

            //AppViewModel.CurrentRace.PitStopBegin += Race_PitStopBegin;
            //AppViewModel.CurrentRace.PitStopEnded += Race_PitStopEnded;
            //AppViewModel.CurrentRace.PitStopRefresh += Race_PitStopRefresh;
            //AppViewModel.CurrentRace.YellowFlagEvent += Race_YellowFlagEvent;
            //AppViewModel.CurrentRace.IncidentEvent += Race_IncidentEvent;
            //AppViewModel.CurrentRace.LapEndedEvent += Race_LapEndedEvent;
            //AppViewModel.CurrentRace.RaceFinished += Race_RaceFinished;


        }

        void timer_Tick(object sender, EventArgs e)
        {
            Program.hwInterface.DataReceived -= ssd_NeedRefresh;
            Program.hwInterface.StopCommand();
            timer.Stop();
            //Program.hwInterface.CloseConnexionCommand();

        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Program.hwInterface.PauseCommand();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Program._startLight.YellowFlag();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Program._startLight.GreenFlag();
        }

        int redled = 0;
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Program._startLight.RedLight(redled);

            redled++;
            if (redled > 4)
            {
                redled = 0;
            }
        }





    }
}
