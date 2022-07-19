using DevExpress.XtraEditors;

namespace ESRM.Win.Views
{
    partial class RaceParamsPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaceParamsPage));
            this.btnShowPilote = new ESRM.Win.ESRMButtonSelect();
            this.btnShowCarImage = new ESRM.Win.ESRMButtonSelect();
            this.btnGoRacing = new ESRM.Win.ESRMButton();
            this.btnTires = new ESRM.Win.ESRMButtonSelect();
            this.btnDamages = new ESRM.Win.ESRMButtonSelect();
            this.btnLapCount = new ESRM.Win.ESRMButtonSelect();
            this.btnFreqFuelPitStop = new ESRM.Win.ESRMButtonSelect();
            this.btnTeams = new ESRM.Win.ESRMButtonSelect();
            this.btnFuel = new ESRM.Win.ESRMButtonSelect();
            this.btnFreqDommages = new ESRM.Win.ESRMButtonSelect();
            this.btnPilotPerTeams = new ESRM.Win.ESRMButtonSelect();
            this.btnFreqTiresPitStop = new ESRM.Win.ESRMButtonSelect();
            this.btnUseWeather = new ESRM.Win.ESRMButtonSelect();
            this.paneWeather = new ESRM.Win.Panels.WeatherPanel();
            this.panelHeaderButtons = new ESRM.Win.ScalablePanel();
            this.btnAdvancedSettings = new ESRM.Win.ESRMButton();
            this.btnWeather = new ESRM.Win.ESRMButton();
            this.btnGlobalParams = new ESRM.Win.ESRMButton();
            this.panelGeneral = new ESRM.Win.ScalablePanel();
            this.btnTimeDuration = new ESRM.Win.ESRMButtonForTime();
            this.btnRelayDuration = new ESRM.Win.ESRMButtonForTime();
            this.scalablePanel2 = new ESRM.Win.ScalablePanel();
            this.btnSelectDriversAndCars = new ESRM.Win.ESRMButton();
            this.panelFiller = new ESRM.Win.ScalablePanel();
            this.panelAadvancedParams = new ESRM.Win.Panels.AdvancedRaceParams();
            this.weatherPanel = new ESRM.Win.Panels.WeatherPanel();
            this.btnMinLapTime = new ESRM.Win.ESRMButtonForNumeric();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeaderButtons)).BeginInit();
            this.panelHeaderButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelGeneral)).BeginInit();
            this.panelGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scalablePanel2)).BeginInit();
            this.scalablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFiller)).BeginInit();
            this.panelFiller.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowPilote
            // 
            resources.ApplyResources(this.btnShowPilote, "btnShowPilote");
            this.btnShowPilote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnShowPilote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnShowPilote.ForeColor = System.Drawing.Color.White;
            this.btnShowPilote.Name = "btnShowPilote";
            this.btnShowPilote.ShowSecondText = true;
            this.btnShowPilote.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPilote.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnShowPilote.SubTextSize = new System.Drawing.Size(180, 46);
            this.btnShowPilote.TextBoxHint = "";
            this.btnShowPilote.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPilote.Click += new System.EventHandler(this.btnShowPilote_Click);
            // 
            // btnShowCarImage
            // 
            resources.ApplyResources(this.btnShowCarImage, "btnShowCarImage");
            this.btnShowCarImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnShowCarImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnShowCarImage.ForeColor = System.Drawing.Color.White;
            this.btnShowCarImage.Name = "btnShowCarImage";
            this.btnShowCarImage.ShowSecondText = true;
            this.btnShowCarImage.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowCarImage.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnShowCarImage.SubTextSize = new System.Drawing.Size(180, 46);
            this.btnShowCarImage.TextBoxHint = "";
            this.btnShowCarImage.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowCarImage.Click += new System.EventHandler(this.btnShowCarImage_Click);
            // 
            // btnGoRacing
            // 
            resources.ApplyResources(this.btnGoRacing, "btnGoRacing");
            this.btnGoRacing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnGoRacing.ForeColor = System.Drawing.Color.White;
            this.btnGoRacing.Name = "btnGoRacing";
            this.btnGoRacing.UseCompatibleTextRendering = true;
            this.btnGoRacing.UseVisualStyleBackColor = false;
            this.btnGoRacing.Click += new System.EventHandler(this.btnGoRacing_Click);
            // 
            // btnTires
            // 
            resources.ApplyResources(this.btnTires, "btnTires");
            this.btnTires.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTires.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnTires.ForeColor = System.Drawing.Color.White;
            this.btnTires.Name = "btnTires";
            this.btnTires.ShowSecondText = true;
            this.btnTires.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTires.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnTires.SubTextSize = new System.Drawing.Size(180, 46);
            this.btnTires.TextBoxHint = "";
            this.btnTires.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTires.Click += new System.EventHandler(this.btnTires_Click);
            // 
            // btnDamages
            // 
            resources.ApplyResources(this.btnDamages, "btnDamages");
            this.btnDamages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnDamages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDamages.ForeColor = System.Drawing.Color.White;
            this.btnDamages.Name = "btnDamages";
            this.btnDamages.ShowSecondText = true;
            this.btnDamages.SubTextFont = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDamages.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnDamages.SubTextSize = new System.Drawing.Size(180, 46);
            this.btnDamages.TextBoxHint = "";
            this.btnDamages.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDamages.Click += new System.EventHandler(this.btnDamages_Click);
            // 
            // btnLapCount
            // 
            resources.ApplyResources(this.btnLapCount, "btnLapCount");
            this.btnLapCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnLapCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLapCount.ForeColor = System.Drawing.Color.White;
            this.btnLapCount.Name = "btnLapCount";
            this.btnLapCount.ShowSecondText = true;
            this.btnLapCount.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapCount.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnLapCount.SubTextSize = new System.Drawing.Size(138, 46);
            this.btnLapCount.TextBoxHint = "";
            this.btnLapCount.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapCount.Click += new System.EventHandler(this.btnLaps_Click);
            // 
            // btnFreqFuelPitStop
            // 
            resources.ApplyResources(this.btnFreqFuelPitStop, "btnFreqFuelPitStop");
            this.btnFreqFuelPitStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnFreqFuelPitStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnFreqFuelPitStop.ForeColor = System.Drawing.Color.White;
            this.btnFreqFuelPitStop.Name = "btnFreqFuelPitStop";
            this.btnFreqFuelPitStop.ShowSecondText = true;
            this.btnFreqFuelPitStop.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreqFuelPitStop.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnFreqFuelPitStop.SubTextSize = new System.Drawing.Size(138, 46);
            this.btnFreqFuelPitStop.TextBoxHint = "Set the approximate number of laps between pitstops . The exact number depends on" +
    " the car setup and the driving style.";
            this.btnFreqFuelPitStop.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreqFuelPitStop.Click += new System.EventHandler(this.btnFreqFuelPitStop_Click);
            // 
            // btnTeams
            // 
            resources.ApplyResources(this.btnTeams, "btnTeams");
            this.btnTeams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTeams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnTeams.ForeColor = System.Drawing.Color.White;
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.ShowSecondText = true;
            this.btnTeams.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeams.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnTeams.SubTextSize = new System.Drawing.Size(138, 46);
            this.btnTeams.TextBoxHint = "Choice of drivers for the race";
            this.btnTeams.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeams.Click += new System.EventHandler(this.btnTeams_Click);
            // 
            // btnFuel
            // 
            resources.ApplyResources(this.btnFuel, "btnFuel");
            this.btnFuel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnFuel.ForeColor = System.Drawing.Color.White;
            this.btnFuel.Name = "btnFuel";
            this.btnFuel.ShowSecondText = true;
            this.btnFuel.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuel.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnFuel.SubTextSize = new System.Drawing.Size(180, 46);
            this.btnFuel.TextBoxHint = "";
            this.btnFuel.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuel.Click += new System.EventHandler(this.btnFuel_Click);
            // 
            // btnFreqDommages
            // 
            resources.ApplyResources(this.btnFreqDommages, "btnFreqDommages");
            this.btnFreqDommages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnFreqDommages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnFreqDommages.ForeColor = System.Drawing.Color.White;
            this.btnFreqDommages.Name = "btnFreqDommages";
            this.btnFreqDommages.ShowSecondText = true;
            this.btnFreqDommages.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreqDommages.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnFreqDommages.SubTextSize = new System.Drawing.Size(180, 46);
            this.btnFreqDommages.TextBoxHint = "";
            this.btnFreqDommages.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreqDommages.Click += new System.EventHandler(this.btnFreqDommages_Click);
            // 
            // btnPilotPerTeams
            // 
            resources.ApplyResources(this.btnPilotPerTeams, "btnPilotPerTeams");
            this.btnPilotPerTeams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnPilotPerTeams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnPilotPerTeams.ForeColor = System.Drawing.Color.White;
            this.btnPilotPerTeams.Name = "btnPilotPerTeams";
            this.btnPilotPerTeams.ShowSecondText = true;
            this.btnPilotPerTeams.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPilotPerTeams.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnPilotPerTeams.SubTextSize = new System.Drawing.Size(138, 46);
            this.btnPilotPerTeams.TextBoxHint = "";
            this.btnPilotPerTeams.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPilotPerTeams.Click += new System.EventHandler(this.btnPilotPerTeams_Click);
            // 
            // btnFreqTiresPitStop
            // 
            resources.ApplyResources(this.btnFreqTiresPitStop, "btnFreqTiresPitStop");
            this.btnFreqTiresPitStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnFreqTiresPitStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnFreqTiresPitStop.ForeColor = System.Drawing.Color.White;
            this.btnFreqTiresPitStop.Name = "btnFreqTiresPitStop";
            this.btnFreqTiresPitStop.ShowSecondText = true;
            this.btnFreqTiresPitStop.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreqTiresPitStop.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnFreqTiresPitStop.SubTextSize = new System.Drawing.Size(138, 46);
            this.btnFreqTiresPitStop.TextBoxHint = "Set the average number of laps for one set of tyres . The exact number depends on" +
    " the car setup and the driving style.";
            this.btnFreqTiresPitStop.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreqTiresPitStop.Click += new System.EventHandler(this.btnFreqTiresPitStop_Click);
            // 
            // btnUseWeather
            // 
            resources.ApplyResources(this.btnUseWeather, "btnUseWeather");
            this.btnUseWeather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnUseWeather.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnUseWeather.ForeColor = System.Drawing.Color.White;
            this.btnUseWeather.Name = "btnUseWeather";
            this.btnUseWeather.ShowSecondText = true;
            this.btnUseWeather.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUseWeather.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnUseWeather.SubTextSize = new System.Drawing.Size(180, 46);
            this.btnUseWeather.TextBoxHint = "";
            this.btnUseWeather.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUseWeather.Click += new System.EventHandler(this.btnUseWeather_Click);
            // 
            // paneWeather
            // 
            resources.ApplyResources(this.paneWeather, "paneWeather");
            this.paneWeather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.paneWeather.ForeColor = System.Drawing.Color.White;
            this.paneWeather.Name = "paneWeather";
            // 
            // panelHeaderButtons
            // 
            resources.ApplyResources(this.panelHeaderButtons, "panelHeaderButtons");
            this.panelHeaderButtons.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelHeaderButtons.Appearance.BackColor")));
            this.panelHeaderButtons.Appearance.FontSizeDelta = ((int)(resources.GetObject("panelHeaderButtons.Appearance.FontSizeDelta")));
            this.panelHeaderButtons.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("panelHeaderButtons.Appearance.FontStyleDelta")));
            this.panelHeaderButtons.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("panelHeaderButtons.Appearance.GradientMode")));
            this.panelHeaderButtons.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("panelHeaderButtons.Appearance.Image")));
            this.panelHeaderButtons.Appearance.Options.UseBackColor = true;
            this.panelHeaderButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeaderButtons.Controls.Add(this.btnAdvancedSettings);
            this.panelHeaderButtons.Controls.Add(this.btnWeather);
            this.panelHeaderButtons.Controls.Add(this.btnGlobalParams);
            this.panelHeaderButtons.Name = "panelHeaderButtons";
            // 
            // btnAdvancedSettings
            // 
            resources.ApplyResources(this.btnAdvancedSettings, "btnAdvancedSettings");
            this.btnAdvancedSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnAdvancedSettings.ForeColor = System.Drawing.Color.DimGray;
            this.btnAdvancedSettings.Name = "btnAdvancedSettings";
            this.btnAdvancedSettings.UseCompatibleTextRendering = true;
            this.btnAdvancedSettings.UseVisualStyleBackColor = true;
            this.btnAdvancedSettings.Click += new System.EventHandler(this.btnAdvancedSettings_Click);
            // 
            // btnWeather
            // 
            resources.ApplyResources(this.btnWeather, "btnWeather");
            this.btnWeather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnWeather.ForeColor = System.Drawing.Color.DimGray;
            this.btnWeather.Name = "btnWeather";
            this.btnWeather.UseCompatibleTextRendering = true;
            this.btnWeather.UseVisualStyleBackColor = true;
            this.btnWeather.Click += new System.EventHandler(this.btnWeather_Click);
            // 
            // btnGlobalParams
            // 
            resources.ApplyResources(this.btnGlobalParams, "btnGlobalParams");
            this.btnGlobalParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnGlobalParams.ForeColor = System.Drawing.Color.YellowGreen;
            this.btnGlobalParams.Name = "btnGlobalParams";
            this.btnGlobalParams.UseCompatibleTextRendering = true;
            this.btnGlobalParams.UseVisualStyleBackColor = true;
            this.btnGlobalParams.Click += new System.EventHandler(this.btnGlobalParams_Click);
            // 
            // panelGeneral
            // 
            resources.ApplyResources(this.panelGeneral, "panelGeneral");
            this.panelGeneral.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelGeneral.Controls.Add(this.btnTimeDuration);
            this.panelGeneral.Controls.Add(this.btnRelayDuration);
            this.panelGeneral.Controls.Add(this.btnPilotPerTeams);
            this.panelGeneral.Controls.Add(this.btnTeams);
            this.panelGeneral.Controls.Add(this.btnShowCarImage);
            this.panelGeneral.Controls.Add(this.btnFreqFuelPitStop);
            this.panelGeneral.Controls.Add(this.btnFuel);
            this.panelGeneral.Controls.Add(this.btnTires);
            this.panelGeneral.Controls.Add(this.btnUseWeather);
            this.panelGeneral.Controls.Add(this.btnShowPilote);
            this.panelGeneral.Controls.Add(this.btnLapCount);
            this.panelGeneral.Controls.Add(this.btnFreqDommages);
            this.panelGeneral.Controls.Add(this.btnDamages);
            this.panelGeneral.Controls.Add(this.btnFreqTiresPitStop);
            this.panelGeneral.Name = "panelGeneral";
            // 
            // btnTimeDuration
            // 
            resources.ApplyResources(this.btnTimeDuration, "btnTimeDuration");
            this.btnTimeDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTimeDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnTimeDuration.ForeColor = System.Drawing.Color.White;
            this.btnTimeDuration.Name = "btnTimeDuration";
            this.btnTimeDuration.ShowSecondText = true;
            this.btnTimeDuration.SubTextFont = new System.Drawing.Font("Impact", 20.25F);
            this.btnTimeDuration.SubTextForeColor = System.Drawing.Color.LightSkyBlue;
            this.btnTimeDuration.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnRelayDuration
            // 
            resources.ApplyResources(this.btnRelayDuration, "btnRelayDuration");
            this.btnRelayDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnRelayDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRelayDuration.ForeColor = System.Drawing.Color.White;
            this.btnRelayDuration.Name = "btnRelayDuration";
            this.btnRelayDuration.ShowSecondText = true;
            this.btnRelayDuration.SubTextFont = new System.Drawing.Font("Impact", 20.25F);
            this.btnRelayDuration.SubTextForeColor = System.Drawing.Color.LightSkyBlue;
            this.btnRelayDuration.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // scalablePanel2
            // 
            resources.ApplyResources(this.scalablePanel2, "scalablePanel2");
            this.scalablePanel2.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("scalablePanel2.Appearance.BackColor")));
            this.scalablePanel2.Appearance.FontSizeDelta = ((int)(resources.GetObject("scalablePanel2.Appearance.FontSizeDelta")));
            this.scalablePanel2.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("scalablePanel2.Appearance.FontStyleDelta")));
            this.scalablePanel2.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("scalablePanel2.Appearance.GradientMode")));
            this.scalablePanel2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("scalablePanel2.Appearance.Image")));
            this.scalablePanel2.Appearance.Options.UseBackColor = true;
            this.scalablePanel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.scalablePanel2.Controls.Add(this.btnSelectDriversAndCars);
            this.scalablePanel2.Controls.Add(this.btnGoRacing);
            this.scalablePanel2.Name = "scalablePanel2";
            // 
            // btnSelectDriversAndCars
            // 
            resources.ApplyResources(this.btnSelectDriversAndCars, "btnSelectDriversAndCars");
            this.btnSelectDriversAndCars.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSelectDriversAndCars.ForeColor = System.Drawing.Color.White;
            this.btnSelectDriversAndCars.Name = "btnSelectDriversAndCars";
            this.btnSelectDriversAndCars.UseCompatibleTextRendering = true;
            this.btnSelectDriversAndCars.UseVisualStyleBackColor = false;
            this.btnSelectDriversAndCars.Click += new System.EventHandler(this.btnSelectDriversAndCars_Click);
            // 
            // panelFiller
            // 
            resources.ApplyResources(this.panelFiller, "panelFiller");
            this.panelFiller.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelFiller.Appearance.BackColor")));
            this.panelFiller.Appearance.FontSizeDelta = ((int)(resources.GetObject("panelFiller.Appearance.FontSizeDelta")));
            this.panelFiller.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("panelFiller.Appearance.FontStyleDelta")));
            this.panelFiller.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("panelFiller.Appearance.GradientMode")));
            this.panelFiller.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("panelFiller.Appearance.Image")));
            this.panelFiller.Appearance.Options.UseBackColor = true;
            this.panelFiller.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFiller.Controls.Add(this.panelGeneral);
            this.panelFiller.Controls.Add(this.paneWeather);
            this.panelFiller.Controls.Add(this.panelAadvancedParams);
            this.panelFiller.Name = "panelFiller";
            // 
            // panelAadvancedParams
            // 
            resources.ApplyResources(this.panelAadvancedParams, "panelAadvancedParams");
            this.panelAadvancedParams.BackColor = System.Drawing.Color.Transparent;
            this.panelAadvancedParams.ForeColor = System.Drawing.Color.White;
            this.panelAadvancedParams.Name = "panelAadvancedParams";
            // 
            // weatherPanel
            // 
            resources.ApplyResources(this.weatherPanel, "weatherPanel");
            this.weatherPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.weatherPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weatherPanel.ForeColor = System.Drawing.Color.White;
            this.weatherPanel.Name = "weatherPanel";
            // 
            // btnMinLapTime
            // 
            resources.ApplyResources(this.btnMinLapTime, "btnMinLapTime");
            this.btnMinLapTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMinLapTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMinLapTime.ForeColor = System.Drawing.Color.White;
            this.btnMinLapTime.IsFloatValue = false;
            this.btnMinLapTime.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnMinLapTime.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnMinLapTime.Name = "btnMinLapTime";
            this.btnMinLapTime.ShowSecondText = true;
            this.btnMinLapTime.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinLapTime.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMinLapTime.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // RaceParamsPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::ESRM.Win.Images.background;
            this.Controls.Add(this.panelFiller);
            this.Controls.Add(this.scalablePanel2);
            this.Controls.Add(this.panelHeaderButtons);
            this.Name = "RaceParamsPage";
            ((System.ComponentModel.ISupportInitialize)(this.panelHeaderButtons)).EndInit();
            this.panelHeaderButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelGeneral)).EndInit();
            this.panelGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scalablePanel2)).EndInit();
            this.scalablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelFiller)).EndInit();
            this.panelFiller.ResumeLayout(false);
            this.panelFiller.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ESRMButton btnGoRacing;
        private ESRMButtonSelect btnDamages;
        private ESRMButtonSelect btnFuel;
        private ESRMButtonSelect btnLapCount;
        private ESRMButtonSelect btnTeams;
        private ESRMButtonSelect btnPilotPerTeams;
        private ESRMButtonSelect btnFreqDommages;
        private ESRMButtonSelect btnFreqFuelPitStop;
        private ESRMButtonSelect btnTires;
        private ESRMButtonSelect btnShowCarImage;
        private ESRMButtonSelect btnShowPilote;
        private ESRMButtonSelect btnFreqTiresPitStop;
        private ESRMButtonSelect btnUseWeather;
        private Panels.WeatherPanel paneWeather;
        private ScalablePanel panelHeaderButtons;
        private ESRMButton btnWeather;
        private ESRMButton btnGlobalParams;
        private ScalablePanel panelGeneral;
        private ScalablePanel scalablePanel2;
        private ScalablePanel panelFiller;
        private Panels.WeatherPanel weatherPanel;
        private ESRMButton btnAdvancedSettings;
        private Panels.AdvancedRaceParams panelAadvancedParams;
        private ESRMButton btnSelectDriversAndCars;
        private ESRMButtonForNumeric btnMinLapTime;
        private ESRMButtonForTime btnRelayDuration;
        private ESRMButtonForTime btnTimeDuration;
    }
}
