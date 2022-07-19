using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;
using System.Windows.Threading;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;

namespace ESRM.Win.Views
{
    public partial class LapCountPage : BasePage
    {
        bool _isLapMode;

        public LapCountPage()
        {
            InitializeComponent();
        }

        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);
        }

        protected override void btnMouseHover(object sender, EventArgs e)
        {
            base.btnMouseHover(sender, e);
        }

        protected override void btnMouseLeave(object sender, EventArgs e)
        {
            base.btnMouseLeave(sender, e);
        }

        private void btn15Laps_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                if (AppViewModel.CurrentRaceParameters.ShowLapCount)
                {
                    AppViewModel.CurrentRaceParameters.LapCount = 15;
                    lblPersoLapCount.Text = string.Format("{0} {1}", AppViewModel.CurrentRaceParameters.LapCount, Textes.Laps);
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();
                }
                else
                {
                    AppViewModel.CurrentRaceParameters.TimeLimit= new TimeSpan(0,15,0);
                    lblPersoLapCount.Text = string.Format("{0}", AppViewModel.CurrentRaceParameters.TimeLimit.Value.ToString("h'h 'm'm '"));
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();

                }
            }

        }

        private void btn30Laps_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                if (AppViewModel.CurrentRaceParameters.ShowLapCount)
                {
                    AppViewModel.CurrentRaceParameters.LapCount = 30;
                    lblPersoLapCount.Text = string.Format("{0} {1}", AppViewModel.CurrentRaceParameters.LapCount, Textes.Laps);
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();
                }
                else
                {
                    AppViewModel.CurrentRaceParameters.TimeLimit = new TimeSpan(0, 30, 0);
                    lblPersoLapCount.Text = string.Format("{0}", AppViewModel.CurrentRaceParameters.TimeLimit.Value.ToString("h'h 'm'm '"));
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();

                }
            }
        }

        private void btn50Laps_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                if (AppViewModel.CurrentRaceParameters.ShowLapCount)
                {
                    AppViewModel.CurrentRaceParameters.LapCount = 50;
                    lblPersoLapCount.Text = string.Format("{0} {1}", AppViewModel.CurrentRaceParameters.LapCount, Textes.Laps);
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();
                }
                else
                {
                    AppViewModel.CurrentRaceParameters.TimeLimit = new TimeSpan(0, 50, 0);
                    lblPersoLapCount.Text = string.Format("{0}", AppViewModel.CurrentRaceParameters.TimeLimit.Value.ToString("h'h 'm'm '"));
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();

                }
            }
        }

        private void btn75Laps_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                if (AppViewModel.CurrentRaceParameters.ShowLapCount)
                {
                    AppViewModel.CurrentRaceParameters.LapCount = 75;
                    lblPersoLapCount.Text = string.Format("{0} {1}", AppViewModel.CurrentRaceParameters.LapCount, Textes.Laps);
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();
                }
                else
                {
                    AppViewModel.CurrentRaceParameters.TimeLimit = new TimeSpan(0, 75, 0);
                    lblPersoLapCount.Text = string.Format("{0}", AppViewModel.CurrentRaceParameters.TimeLimit.Value.ToString("h'h 'm'm '"));
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();

                }
            }
        }

        private void btn100Laps_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                if (AppViewModel.CurrentRaceParameters.ShowLapCount)
                {
                    AppViewModel.CurrentRaceParameters.LapCount = 100;
                    lblPersoLapCount.Text = string.Format("{0} {1}", AppViewModel.CurrentRaceParameters.LapCount, Textes.Laps);
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();
                }
                else
                {
                    AppViewModel.CurrentRaceParameters.TimeLimit = new TimeSpan(0, 100, 0);
                    lblPersoLapCount.Text = string.Format("{0}", AppViewModel.CurrentRaceParameters.TimeLimit.Value.ToString("h'h 'm'm '"));
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();

                }
            }
        }

        private void btnCustomLaps_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                if (AppViewModel.CurrentRaceParameters.ShowLapCount)
                {
                    AppViewModel.CurrentRaceParameters.LapCount -= 1;
                    lblPersoLapCount.Text = string.Format("{0} {1}", AppViewModel.CurrentRaceParameters.LapCount, Textes.Laps);
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();
                }
                else
                {
                    if (AppViewModel.CurrentRaceParameters.TimeLimit.HasValue)
                        AppViewModel.CurrentRaceParameters.TimeLimit -=  new TimeSpan(0, 1, 0);

                    lblPersoLapCount.Text = string.Format("{0}", AppViewModel.CurrentRaceParameters.TimeLimit.Value.ToString("h'h 'm'm '"));
                    AppViewModel.CurrentRaceParameters.CalculRelayDuration();

                }
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (AppViewModel.CurrentRaceParameters.ShowLapCount)
            {
                AppViewModel.CurrentRaceParameters.LapCount += 5;
                lblPersoLapCount.Text = string.Format("{0} {1}", AppViewModel.CurrentRaceParameters.LapCount, Textes.Laps);
                AppViewModel.CurrentRaceParameters.CalculRelayDuration();
            }
            else
            {
                if (!AppViewModel.CurrentRaceParameters.TimeLimit.HasValue)
                    AppViewModel.CurrentRaceParameters.TimeLimit = new TimeSpan(0, 5, 0);
                else
                    AppViewModel.CurrentRaceParameters.TimeLimit += new TimeSpan(0, 5, 0);

                lblPersoLapCount.Text = string.Format("{0}", AppViewModel.CurrentRaceParameters.TimeLimit.Value.ToString("h'h 'm'm '"));
                AppViewModel.CurrentRaceParameters.CalculRelayDuration();

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AppViewModel.ActivatePage("pageRaceParams");
        }


    }
}
