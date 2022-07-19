using System;
using System.Drawing;
using System.Windows.Forms;
using ESRM.Entities;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;

namespace ESRM.Win.Views
{
    public partial class RaceParamsPage : BasePage
    {
        #region PROPERTIES
        public TimeSpan TimeLimit
        {
            get { return AppViewModel.CurrentRaceParameters.TimeLimit.HasValue ? AppViewModel.CurrentRaceParameters.TimeLimit.Value : new TimeSpan(0,0,0); }
            set { AppViewModel.CurrentRaceParameters.TimeLimit = value; }
        }
        public TimeSpan RelayTimeLimit
        {
            get { return AppViewModel.CurrentRaceParameters.RelayTimeLimit.HasValue ? AppViewModel.CurrentRaceParameters.RelayTimeLimit.Value : new TimeSpan(0, 0, 0); }
            set { AppViewModel.CurrentRaceParameters.RelayTimeLimit = value; }
        }
        public Color ColorLbUseDamages
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters != null && AppViewModel.CurrentRaceParameters.Damages != DamagesEnum.None)
                    return Color.YellowGreen;
                else
                    return Color.Red;
            }
        }

        public Color ColorLbUseFuel
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters != null && AppViewModel.CurrentRaceParameters.FuelImpact)
                    return Color.YellowGreen;
                else
                    return Color.Red;
            }
        }

        public Color ColorShowPilotsForUI
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters != null && AppViewModel.CurrentRaceParameters.ShowPilots)
                    return Color.YellowGreen;
                else
                    return Color.Red;
            }
        }
        public Color ColorUseWeatherConditions
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters != null && AppViewModel.CurrentRaceParameters.UseWeatherConditions)
                    return Color.YellowGreen;
                else
                    return Color.Red;
            }
        }
    

        public Color ColorManualRefuel
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters != null && AppViewModel.CurrentRaceParameters.ManualRefuel)
                    return Color.YellowGreen;
                else
                    return Color.Red;
            }
        }

        


        public Color ColorShowCarsForUI
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters != null && AppViewModel.CurrentRaceParameters.ShowCars)
                    return Color.YellowGreen;
                else
                    return Color.Red;
            }
        }


        

        public Color ColorLbUseTires
        {
            get
            {
                if (AppViewModel.CurrentRaceParameters != null && AppViewModel.CurrentRaceParameters.TiresImpact != TiresImpactEnum.None)
                    return Color.YellowGreen;
                else
                    return Color.Red;
            }
        }

        
        #endregion

        public RaceParamsPage()
        {
            InitializeComponent();

            Font btnFont = Program.fontManager.GetRadioStarFont(btnWeather.Font.Size, FontStyle.Italic);
            btnWeather.Font = btnFont;
            btnGlobalParams.Font = btnFont;
            btnAdvancedSettings.Font = btnFont;

            paneWeather.Dock = DockStyle.Top;
            panelAadvancedParams.Dock = DockStyle.Top;
        }

        public override void OnNavigatedTo(INavigationArgs args)
        {
            base.OnNavigatedTo(args);

            if(AppViewModel.CurrentRaceParameters == null)
                AppViewModel.CreateRaceFromParameters();

            paneWeather.SetDatas(AppViewModel);
            panelAadvancedParams.SetDatas(AppViewModel);

            if (this.ParentForm != null && this.ParentForm is MainForm)
                (this.ParentForm as MainForm).SetTitle(AppViewModel.CurrentRaceParameters.RaceType.ToString());

            BindDatas();
        }



        private void BindDatas()
        {
            foreach (Control c in this.panelGeneral.Controls)
                c.DataBindings.Clear();

            if (AppViewModel.CurrentRaceParameters.ShowLapCount)
            {
                btnLapCount.Enabled = true;
                btnLapCount.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "LapCount");
                if (!AppViewModel.CurrentRaceParameters.LapCount.HasValue)
                    AppViewModel.CurrentRaceParameters.LapCount = 30;
            }
            else
                btnLapCount.Enabled = false;


            if (AppViewModel.CurrentRaceParameters.ShowTimeDuration)
            {
                btnTimeDuration.Enabled = true;
                if (!AppViewModel.CurrentRaceParameters.TimeLimit.HasValue)
                    AppViewModel.CurrentRaceParameters.TimeLimit = new TimeSpan(0, 10, 0);

                btnTimeDuration.DataBindings.Add("SubText", this, "TimeLimit");
            }
            else
                btnTimeDuration.Enabled = false;

            btnRelayDuration.DataBindings.Add("SubText", this, "RelayTimeLimit");

            btnPilotPerTeams.DataBindings.Add("Enabled", AppViewModel.CurrentRaceParameters, "ShowRelayTime");
            btnRelayDuration.DataBindings.Add("Enabled", AppViewModel.CurrentRaceParameters, "ShowRelayTime");

            btnLapCount.DataBindings.Add("Enabled", AppViewModel.CurrentRaceParameters, "ShowLapCount");
            btnTimeDuration.DataBindings.Add("Enabled", AppViewModel.CurrentRaceParameters, "ShowTimeDuration");

            btnPilotPerTeams.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "PilotPerTeam");
            btnTeams.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "TeamsCount");
            

            btnDamages.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "IncidentForUI");
            btnDamages.DataBindings.Add("Enabled", AppViewModel.CurrentRaceParameters, "ShowDamages");
            btnDamages.DataBindings.Add("SubTextForeColor", this, "ColorLbUseDamages");
            btnFuel.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "FuelImpactForUI");
            btnFuel.DataBindings.Add("Enabled", AppViewModel.CurrentRaceParameters, "ShowFuelImpact");
            btnFuel.DataBindings.Add("SubTextForeColor", this, "ColorLbUseFuel");

            btnTires.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "TiresImpactForUI");
            btnTires.DataBindings.Add("Enabled", AppViewModel.CurrentRaceParameters, "ShowFuelImpact");
            btnTires.DataBindings.Add("SubTextForeColor", this, "ColorLbUseTires");

            btnFreqFuelPitStop.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "FullTankLifeTime");
            btnFreqTiresPitStop.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "TireLifeTime");

            btnFreqDommages.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "DamagesFrequencyForUI");
            btnFreqDommages.DataBindings.Add("Enabled", AppViewModel.CurrentRaceParameters, "ShowIncidentFrequency");

            btnShowCarImage.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "ShowCarsForUI");
            btnShowCarImage.DataBindings.Add("SubTextForeColor", this, "ColorShowCarsForUI");
            btnShowPilote.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "ShowPilotsForUI");
            btnShowPilote.DataBindings.Add("SubTextForeColor", this, "ColorShowPilotsForUI");

            btnUseWeather.DataBindings.Add("SubText", AppViewModel.CurrentRaceParameters, "UseWeatherConditions");
            btnUseWeather.DataBindings.Add("SubTextForeColor", this, "ColorUseWeatherConditions");

            btnWeather.DataBindings.Clear();
            btnWeather.DataBindings.Add("Visible", AppViewModel.CurrentRaceParameters, "UseWeatherConditions");
        }

        private void btnTrackSelect_Click(object sender, EventArgs e)
        {           
            AppViewModel.ActivatePage("pageTracks");
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            AppViewModel.ActivatePage("RPTeamsPage");
        }


        private void btnLaps_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                if (AppViewModel.CurrentRaceParameters.RaceType == RaceType.Endurance || AppViewModel.CurrentRaceParameters.RaceType == RaceType.Qualification)
                {
                    if (!AppViewModel.CurrentRaceParameters.TimeLimit.HasValue)
                        AppViewModel.CurrentRaceParameters.TimeLimit = new TimeSpan(0, 2, 0);

                    if (AppViewModel.CurrentRaceParameters.TimeLimit.Value.TotalMinutes < 20)
                        AppViewModel.CurrentRaceParameters.TimeLimit = AppViewModel.CurrentRaceParameters.TimeLimit.Value.Add(new TimeSpan(0, 2, 0));
                    else if (AppViewModel.CurrentRaceParameters.TimeLimit.Value.TotalMinutes < 60)
                        AppViewModel.CurrentRaceParameters.TimeLimit = AppViewModel.CurrentRaceParameters.TimeLimit.Value.Add(new TimeSpan(0, 5, 0));
                    else
                        AppViewModel.CurrentRaceParameters.TimeLimit = new TimeSpan(0, 2, 0);
                }
                else
                {
                    AppViewModel.CreateRaceFromParameters();
                    AppViewModel.ActivatePage("pageLapCount");
                }
                btnLapCount.DataBindings["SubText"].ReadValue();
                AppViewModel.CurrentRaceParameters.CalculRelayDuration();
                btnRelayDuration.DataBindings["SubText"].ReadValue();
                AppViewModel.CurrentRaceParameters.TimeLimit = null;

            }
        }


        private void btnTimeDuration_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CreateRaceFromParameters();
                AppViewModel.ActivatePage("pageLapCount");

                btnTimeDuration.DataBindings["SubText"].ReadValue();
                AppViewModel.CurrentRaceParameters.CalculRelayDuration();
                btnRelayDuration.DataBindings["SubText"].ReadValue();
                AppViewModel.CurrentRaceParameters.LapCount = null;
            }
        }


        //private void btnRelayDuration_Click(object sender, EventArgs e)
        //{
        //    if (AppViewModel != null)
        //    {
        //        if (AppViewModel.CurrentRaceParameters.RaceType == RaceType.Endurance)
        //        {
        //            if (!AppViewModel.CurrentRaceParameters.RelayTimeLimit.HasValue)
        //                AppViewModel.CurrentRaceParameters.RelayTimeLimit = new TimeSpan(0, 1, 0);

        //            else
        //                AppViewModel.CurrentRaceParameters.RelayTimeLimit = AppViewModel.CurrentRaceParameters.RelayTimeLimit.Value.Add(new TimeSpan(0, 5, 0));

        //            if (AppViewModel.CurrentRaceParameters.RelayTimeLimit.Value.TotalMinutes > 30)
        //                AppViewModel.CurrentRaceParameters.RelayTimeLimit = new TimeSpan(0, 1, 0);

        //        }
        //        else
        //        {
        //        }
        //        btnRelayDuration.DataBindings["SubText"].ReadValue();
        //    }

        //}

        private void btnFuel_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.FuelImpact = !AppViewModel.CurrentRaceParameters.FuelImpact;
                btnFuel.DataBindings["SubText"].ReadValue();
                btnFuel.DataBindings["SubTextForeColor"].ReadValue();
            }
        }

        private void btnTires_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.TiresImpact++;
                if ((int)AppViewModel.CurrentRaceParameters.TiresImpact > 3)
                    AppViewModel.CurrentRaceParameters.TiresImpact = TiresImpactEnum.None;
                btnTires.DataBindings["SubText"].ReadValue();
                btnTires.DataBindings["SubTextForeColor"].ReadValue();
            }
        }

        private void btnDamages_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                if (AppViewModel.CurrentRaceParameters.Damages == DamagesEnum.Both)
                    AppViewModel.CurrentRaceParameters.Damages = DamagesEnum.None;
                else
                    AppViewModel.CurrentRaceParameters.Damages = (DamagesEnum)((int)AppViewModel.CurrentRaceParameters.Damages+1);

                btnDamages.DataBindings["SubText"].ReadValue();
                btnDamages.DataBindings["SubTextForeColor"].ReadValue();
                btnFreqDommages.DataBindings["Enabled"].ReadValue();


            }
        }


        private void btnPilotPerTeams_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.PilotPerTeam = AppViewModel.CurrentRaceParameters.PilotPerTeam + 1;
                if (AppViewModel.CurrentRaceParameters.PilotPerTeam > 3)
                    AppViewModel.CurrentRaceParameters.PilotPerTeam = 1;

                btnPilotPerTeams.DataBindings["SubText"].ReadValue();
                btnRelayDuration.DataBindings["Enabled"].ReadValue();
            }
        }

        private void btnFreqDommages_Click(object sender, EventArgs e)
        {
            if (AppViewModel.CurrentRaceParameters.DamagesFrequency == 5)
                AppViewModel.CurrentRaceParameters.DamagesFrequency = 1;
            else
                AppViewModel.CurrentRaceParameters.DamagesFrequency = AppViewModel.CurrentRaceParameters.DamagesFrequency + 1;

            btnFreqDommages.DataBindings["SubText"].ReadValue();
        }

        private void btnFreqFuelPitStop_Click(object sender, EventArgs e)
        {
            int maxLaps = AppViewModel.CurrentRaceParameters.ShowLapCount ? AppViewModel.CurrentRaceParameters.LapCount.Value : 200;
            if (AppViewModel.CurrentRaceParameters.FullTankLifeTime >= maxLaps)
                AppViewModel.CurrentRaceParameters.FullTankLifeTime = 10;
            else
                AppViewModel.CurrentRaceParameters.FullTankLifeTime = AppViewModel.CurrentRaceParameters.FullTankLifeTime + 5;

            btnFreqFuelPitStop.DataBindings["SubText"].ReadValue();

        }

        private void btnFreqTiresPitStop_Click(object sender, EventArgs e)
        {
            int maxLaps = AppViewModel.CurrentRaceParameters.ShowLapCount ? AppViewModel.CurrentRaceParameters.LapCount.Value : 200;
            if (AppViewModel.CurrentRaceParameters.TireLifeTime >= maxLaps)
                AppViewModel.CurrentRaceParameters.TireLifeTime = 10;
            else
                AppViewModel.CurrentRaceParameters.TireLifeTime = AppViewModel.CurrentRaceParameters.TireLifeTime + 5;

            btnFreqTiresPitStop.DataBindings["SubText"].ReadValue();

        }

        private void btnShowCarImage_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.ShowCars = !AppViewModel.CurrentRaceParameters.ShowCars;
                btnShowCarImage.DataBindings["SubText"].ReadValue();
                btnShowCarImage.DataBindings["SubTextForeColor"].ReadValue();
            }
        }

        private void btnShowPilote_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.ShowPilots = !AppViewModel.CurrentRaceParameters.ShowPilots;
                btnShowPilote.DataBindings["SubText"].ReadValue();
                btnShowPilote.DataBindings["SubTextForeColor"].ReadValue();
            }
        }

        private void btnUseWeather_Click(object sender, EventArgs e)
        {
            if (AppViewModel != null)
            {
                AppViewModel.CurrentRaceParameters.UseWeatherConditions = !AppViewModel.CurrentRaceParameters.UseWeatherConditions;
                btnUseWeather.DataBindings["SubText"].ReadValue();
                btnUseWeather.DataBindings["SubTextForeColor"].ReadValue();

                btnWeather.Visible = AppViewModel.CurrentRaceParameters.UseWeatherConditions;
                paneWeather.SetDatas(AppViewModel);
            }
        }

        private void btnGlobalParams_Click(object sender, EventArgs e)
        {
            btnGlobalParams.ForeColor = Color.YellowGreen;
            btnAdvancedSettings.ForeColor = Color.DimGray;
            btnWeather.ForeColor = Color.DimGray;
            panelAadvancedParams.Visible = false;
            paneWeather.Visible = false;
            panelGeneral.Visible = true;

        }

        private void btnWeather_Click(object sender, EventArgs e)
        {
            btnGlobalParams.ForeColor = Color.DimGray;
            btnAdvancedSettings.ForeColor = Color.DimGray;
            btnWeather.ForeColor = Color.YellowGreen;
            panelGeneral.Visible = false;
            panelAadvancedParams.Visible = false;
            paneWeather.Visible = true;

        }

        private void btnAdvancedSettings_Click(object sender, EventArgs e)
        {
            btnGlobalParams.ForeColor = Color.DimGray;
            btnAdvancedSettings.ForeColor = Color.YellowGreen;
            btnWeather.ForeColor = Color.DimGray;
            panelGeneral.Visible = false;
            panelAadvancedParams.Visible = true;
            paneWeather.Visible = false;

        }



        private void btnGoRacing_Click(object sender, EventArgs e)
        {
            AppViewModel.CreateRaceFromParameters();
            // on applique les restrictions de la licence
            if (Program.Licence.LapCountLimit.HasValue)
                AppViewModel.CurrentRaceParameters.LapCount = Program.Licence.LapCountLimit;
            if (Program.Licence.TeamLimit.HasValue)
                AppViewModel.CurrentRaceParameters.MaxTeamsCount = Program.Licence.TeamLimit.Value;
            if (Program.Licence.TeamLimit.HasValue)
                AppViewModel.CurrentRaceParameters.TimeLimit = Program.Licence.TimeLimit;
            if (Program.Licence.TimeAttackLevelLimit.HasValue)
                AppViewModel.CurrentRaceParameters.TimeAttackLevelLimit = Program.Licence.TimeAttackLevelLimit;

            AppViewModel.ActivatePage("pageRace");
        }

        private void btnSelectDriversAndCars_Click(object sender, EventArgs e)
        {
            AppViewModel.ActivatePage("pageDriverAndCarSelection");

        }
        //
    }
}
