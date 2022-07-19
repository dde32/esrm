using ESRM.Entities;
using ESRM.Win.Panels;
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
    public partial class SecondRaceView : Form
    {
        public IRacePage RacePage
        {
            get { return racePage2; }
        }
        public EndRacePage EndRacePage
        {
            get { return endracePage; }
        }

        public SecondRaceView()
        {
            InitializeComponent();
        }

        public SecondRaceView(RaceManager raceHelper)
        {
            InitializeComponent();

            racePage2.IsSecondPage = true;
            racePage2.ShowButtonPanel(false);
            racePage2.ShowHeaderPanel(true);
        }

        public void SwitchView(bool toRaceView)
        {
            racePage2.Visible = toRaceView;
            endracePage.Visible = !toRaceView;
            if(!toRaceView)
                endracePage.InitSecondView(racePage2.AppViewModel);

        }

        public void InitUI(IESRMViewModel appViewModelParam)
        {
            racePage2.InitSecondView(appViewModelParam);
            racePage2.Refresh();
        }


    }

 
}
