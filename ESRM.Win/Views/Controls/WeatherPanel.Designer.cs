using DevExpress.XtraEditors;

namespace ESRM.Win.Panels
{
    partial class WeatherPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeatherPanel));
            this.panelTeamHeader = new ESRM.Win.ScalablePanel();
            this.panelTeam = new ESRM.Win.ScalablePanel();
            this.panelName = new ESRM.Win.ScalablePanel();
            this.btnShowOptimalTiresType = new ESRM.Win.ESRMButtonSelect();
            this.btnRandomWeather = new ESRM.Win.ESRMButtonSelect();
            this.btnMaxTemp = new ESRM.Win.ESRMButton();
            this.btnDownMaxTemp = new ESRM.Win.ESRMButton();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMaxTemp = new System.Windows.Forms.Label();
            this.p1 = new ESRM.Win.ScalablePanel();
            this.pEvolve = new ESRM.Win.ScalablePanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownEvolveInterval = new ESRM.Win.ESRMButton();
            this.lblEvoleInterval = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpEvolveInterval = new ESRM.Win.ESRMButton();
            this.pAvgLapTime = new ESRM.Win.ScalablePanel();
            this.btnDownLapTime = new ESRM.Win.ESRMButton();
            this.btnUpLapTime = new ESRM.Win.ESRMButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAvgLapTime = new System.Windows.Forms.Label();
            this.pMaxTemp = new ESRM.Win.ScalablePanel();
            this.pMinTemp = new ESRM.Win.ScalablePanel();
            this.btnDownMinTemp = new ESRM.Win.ESRMButton();
            this.btnUpMinTemp = new ESRM.Win.ESRMButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMinTemp = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtEndTme = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.scalablePanel9 = new ESRM.Win.ScalablePanel();
            this.pFrequency = new ESRM.Win.ScalablePanel();
            this.chkBxRainSound = new System.Windows.Forms.CheckBox();
            this.btnRainRisk = new ESRM.Win.ESRMButtonSelect();
            this.btnEvolFrequency = new ESRM.Win.ESRMButtonSelect();
            this.pWeather = new ESRM.Win.ScalablePanel();
            this.edtTemp = new System.Windows.Forms.NumericUpDown();
            this.pbWeather = new DevExpress.XtraEditors.PictureEdit();
            this.btnNextWeather = new ESRM.Win.ESRMButton();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelTeamHeader)).BeginInit();
            this.panelTeamHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTeam)).BeginInit();
            this.panelTeam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelName)).BeginInit();
            this.panelName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            this.p1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pEvolve)).BeginInit();
            this.pEvolve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pAvgLapTime)).BeginInit();
            this.pAvgLapTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMaxTemp)).BeginInit();
            this.pMaxTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMinTemp)).BeginInit();
            this.pMinTemp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scalablePanel9)).BeginInit();
            this.scalablePanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pFrequency)).BeginInit();
            this.pFrequency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pWeather)).BeginInit();
            this.pWeather.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeather.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTeamHeader
            // 
            this.panelTeamHeader.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelTeamHeader.Appearance.BackColor")));
            this.panelTeamHeader.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.panelTeamHeader, "panelTeamHeader");
            this.panelTeamHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTeamHeader.Controls.Add(this.panelTeam);
            this.panelTeamHeader.Name = "panelTeamHeader";
            // 
            // panelTeam
            // 
            this.panelTeam.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelTeam.Appearance.BackColor")));
            this.panelTeam.Appearance.Options.UseBackColor = true;
            this.panelTeam.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTeam.Controls.Add(this.panelName);
            resources.ApplyResources(this.panelTeam, "panelTeam");
            this.panelTeam.Name = "panelTeam";
            // 
            // panelName
            // 
            this.panelName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelName.Controls.Add(this.btnShowOptimalTiresType);
            this.panelName.Controls.Add(this.btnRandomWeather);
            resources.ApplyResources(this.panelName, "panelName");
            this.panelName.Name = "panelName";
            // 
            // btnShowOptimalTiresType
            // 
            this.btnShowOptimalTiresType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnShowOptimalTiresType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.btnShowOptimalTiresType, "btnShowOptimalTiresType");
            this.btnShowOptimalTiresType.ForeColor = System.Drawing.Color.White;
            this.btnShowOptimalTiresType.Name = "btnShowOptimalTiresType";
            this.btnShowOptimalTiresType.ShowSecondText = true;
            this.btnShowOptimalTiresType.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowOptimalTiresType.SubTextForeColor = System.Drawing.Color.Yellow;
            this.btnShowOptimalTiresType.SubTextSize = new System.Drawing.Size(138, 61);
            this.btnShowOptimalTiresType.TextBoxHint = "";
            this.btnShowOptimalTiresType.TextFont = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowOptimalTiresType.Click += new System.EventHandler(this.btnShowOptimalTiresType_Click);
            // 
            // btnRandomWeather
            // 
            this.btnRandomWeather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnRandomWeather.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.btnRandomWeather, "btnRandomWeather");
            this.btnRandomWeather.ForeColor = System.Drawing.Color.White;
            this.btnRandomWeather.Name = "btnRandomWeather";
            this.btnRandomWeather.ShowSecondText = false;
            this.btnRandomWeather.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomWeather.SubTextForeColor = System.Drawing.Color.Yellow;
            this.btnRandomWeather.SubTextSize = new System.Drawing.Size(138, 62);
            this.btnRandomWeather.TextBoxHint = "";
            this.btnRandomWeather.TextFont = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomWeather.Click += new System.EventHandler(this.btnRandomWeather_Click);
            // 
            // btnMaxTemp
            // 
            this.btnMaxTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnMaxTemp, "btnMaxTemp");
            this.btnMaxTemp.ForeColor = System.Drawing.Color.White;
            this.btnMaxTemp.Name = "btnMaxTemp";
            this.btnMaxTemp.UseCompatibleTextRendering = true;
            this.btnMaxTemp.UseVisualStyleBackColor = true;
            this.btnMaxTemp.Click += new System.EventHandler(this.btnMaxTemp_Click);
            // 
            // btnDownMaxTemp
            // 
            this.btnDownMaxTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnDownMaxTemp, "btnDownMaxTemp");
            this.btnDownMaxTemp.ForeColor = System.Drawing.Color.White;
            this.btnDownMaxTemp.Name = "btnDownMaxTemp";
            this.btnDownMaxTemp.UseCompatibleTextRendering = true;
            this.btnDownMaxTemp.UseVisualStyleBackColor = true;
            this.btnDownMaxTemp.Click += new System.EventHandler(this.btnDownMaxTemp_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // lblMaxTemp
            // 
            resources.ApplyResources(this.lblMaxTemp, "lblMaxTemp");
            this.lblMaxTemp.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxTemp.ForeColor = System.Drawing.Color.Yellow;
            this.lblMaxTemp.Name = "lblMaxTemp";
            // 
            // p1
            // 
            this.p1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("p1.Appearance.BackColor")));
            this.p1.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.p1, "p1");
            this.p1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.p1.Controls.Add(this.pEvolve);
            this.p1.Controls.Add(this.pAvgLapTime);
            this.p1.Controls.Add(this.pMaxTemp);
            this.p1.Controls.Add(this.pMinTemp);
            this.p1.Name = "p1";
            // 
            // pEvolve
            // 
            this.pEvolve.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pEvolve.Appearance.BackColor")));
            this.pEvolve.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.pEvolve, "pEvolve");
            this.pEvolve.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pEvolve.Controls.Add(this.label1);
            this.pEvolve.Controls.Add(this.btnDownEvolveInterval);
            this.pEvolve.Controls.Add(this.lblEvoleInterval);
            this.pEvolve.Controls.Add(this.label3);
            this.pEvolve.Controls.Add(this.btnUpEvolveInterval);
            this.pEvolve.Name = "pEvolve";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // btnDownEvolveInterval
            // 
            this.btnDownEvolveInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnDownEvolveInterval, "btnDownEvolveInterval");
            this.btnDownEvolveInterval.ForeColor = System.Drawing.Color.White;
            this.btnDownEvolveInterval.Name = "btnDownEvolveInterval";
            this.btnDownEvolveInterval.UseCompatibleTextRendering = true;
            this.btnDownEvolveInterval.UseVisualStyleBackColor = true;
            this.btnDownEvolveInterval.Click += new System.EventHandler(this.btnDownEvolveInterval_Click);
            // 
            // lblEvoleInterval
            // 
            resources.ApplyResources(this.lblEvoleInterval, "lblEvoleInterval");
            this.lblEvoleInterval.BackColor = System.Drawing.Color.Transparent;
            this.lblEvoleInterval.ForeColor = System.Drawing.Color.Yellow;
            this.lblEvoleInterval.Name = "lblEvoleInterval";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // btnUpEvolveInterval
            // 
            this.btnUpEvolveInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnUpEvolveInterval, "btnUpEvolveInterval");
            this.btnUpEvolveInterval.ForeColor = System.Drawing.Color.White;
            this.btnUpEvolveInterval.Name = "btnUpEvolveInterval";
            this.btnUpEvolveInterval.UseCompatibleTextRendering = true;
            this.btnUpEvolveInterval.UseVisualStyleBackColor = true;
            this.btnUpEvolveInterval.Click += new System.EventHandler(this.btnUpEvolveInterval_Click);
            // 
            // pAvgLapTime
            // 
            this.pAvgLapTime.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pAvgLapTime.Appearance.BackColor")));
            this.pAvgLapTime.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.pAvgLapTime, "pAvgLapTime");
            this.pAvgLapTime.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pAvgLapTime.Controls.Add(this.btnDownLapTime);
            this.pAvgLapTime.Controls.Add(this.btnUpLapTime);
            this.pAvgLapTime.Controls.Add(this.label4);
            this.pAvgLapTime.Controls.Add(this.lblAvgLapTime);
            this.pAvgLapTime.Name = "pAvgLapTime";
            // 
            // btnDownLapTime
            // 
            this.btnDownLapTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnDownLapTime, "btnDownLapTime");
            this.btnDownLapTime.ForeColor = System.Drawing.Color.White;
            this.btnDownLapTime.Name = "btnDownLapTime";
            this.btnDownLapTime.UseCompatibleTextRendering = true;
            this.btnDownLapTime.UseVisualStyleBackColor = true;
            this.btnDownLapTime.Click += new System.EventHandler(this.btnDownLapTime_Click);
            // 
            // btnUpLapTime
            // 
            this.btnUpLapTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnUpLapTime, "btnUpLapTime");
            this.btnUpLapTime.ForeColor = System.Drawing.Color.White;
            this.btnUpLapTime.Name = "btnUpLapTime";
            this.btnUpLapTime.UseCompatibleTextRendering = true;
            this.btnUpLapTime.UseVisualStyleBackColor = true;
            this.btnUpLapTime.Click += new System.EventHandler(this.btnUpLapTime_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // lblAvgLapTime
            // 
            resources.ApplyResources(this.lblAvgLapTime, "lblAvgLapTime");
            this.lblAvgLapTime.BackColor = System.Drawing.Color.Transparent;
            this.lblAvgLapTime.ForeColor = System.Drawing.Color.Yellow;
            this.lblAvgLapTime.Name = "lblAvgLapTime";
            // 
            // pMaxTemp
            // 
            this.pMaxTemp.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pMaxTemp.Appearance.BackColor")));
            this.pMaxTemp.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.pMaxTemp, "pMaxTemp");
            this.pMaxTemp.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pMaxTemp.Controls.Add(this.btnDownMaxTemp);
            this.pMaxTemp.Controls.Add(this.lblMaxTemp);
            this.pMaxTemp.Controls.Add(this.label8);
            this.pMaxTemp.Controls.Add(this.btnMaxTemp);
            this.pMaxTemp.Name = "pMaxTemp";
            // 
            // pMinTemp
            // 
            this.pMinTemp.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pMinTemp.Appearance.BackColor")));
            this.pMinTemp.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.pMinTemp, "pMinTemp");
            this.pMinTemp.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pMinTemp.Controls.Add(this.btnDownMinTemp);
            this.pMinTemp.Controls.Add(this.btnUpMinTemp);
            this.pMinTemp.Controls.Add(this.label2);
            this.pMinTemp.Controls.Add(this.lblMinTemp);
            this.pMinTemp.Name = "pMinTemp";
            // 
            // btnDownMinTemp
            // 
            this.btnDownMinTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnDownMinTemp, "btnDownMinTemp");
            this.btnDownMinTemp.ForeColor = System.Drawing.Color.White;
            this.btnDownMinTemp.Name = "btnDownMinTemp";
            this.btnDownMinTemp.UseCompatibleTextRendering = true;
            this.btnDownMinTemp.UseVisualStyleBackColor = true;
            this.btnDownMinTemp.Click += new System.EventHandler(this.btnDownMinTemp_Click);
            // 
            // btnUpMinTemp
            // 
            this.btnUpMinTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnUpMinTemp, "btnUpMinTemp");
            this.btnUpMinTemp.ForeColor = System.Drawing.Color.White;
            this.btnUpMinTemp.Name = "btnUpMinTemp";
            this.btnUpMinTemp.UseCompatibleTextRendering = true;
            this.btnUpMinTemp.UseVisualStyleBackColor = true;
            this.btnUpMinTemp.Click += new System.EventHandler(this.btnUpMinTemp_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // lblMinTemp
            // 
            resources.ApplyResources(this.lblMinTemp, "lblMinTemp");
            this.lblMinTemp.BackColor = System.Drawing.Color.Transparent;
            this.lblMinTemp.ForeColor = System.Drawing.Color.Yellow;
            this.lblMinTemp.Name = "lblMinTemp";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Name = "label10";
            // 
            // dtEndTme
            // 
            resources.ApplyResources(this.dtEndTme, "dtEndTme");
            this.dtEndTme.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtEndTme.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEndTme.Name = "dtEndTme";
            this.dtEndTme.ShowUpDown = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Name = "label9";
            // 
            // dtStartTime
            // 
            resources.ApplyResources(this.dtStartTime, "dtStartTime");
            this.dtStartTime.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.ShowUpDown = true;
            this.dtStartTime.UseWaitCursor = true;
            // 
            // scalablePanel9
            // 
            this.scalablePanel9.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("scalablePanel9.Appearance.BackColor")));
            this.scalablePanel9.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.scalablePanel9, "scalablePanel9");
            this.scalablePanel9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.scalablePanel9.Controls.Add(this.pFrequency);
            this.scalablePanel9.Controls.Add(this.pWeather);
            this.scalablePanel9.Name = "scalablePanel9";
            // 
            // pFrequency
            // 
            this.pFrequency.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pFrequency.Appearance.BackColor")));
            this.pFrequency.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.pFrequency, "pFrequency");
            this.pFrequency.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pFrequency.Controls.Add(this.chkBxRainSound);
            this.pFrequency.Controls.Add(this.btnRainRisk);
            this.pFrequency.Controls.Add(this.dtEndTme);
            this.pFrequency.Controls.Add(this.label10);
            this.pFrequency.Controls.Add(this.btnEvolFrequency);
            this.pFrequency.Controls.Add(this.label9);
            this.pFrequency.Controls.Add(this.dtStartTime);
            this.pFrequency.Name = "pFrequency";
            // 
            // chkBxRainSound
            // 
            resources.ApplyResources(this.chkBxRainSound, "chkBxRainSound");
            this.chkBxRainSound.FlatAppearance.CheckedBackColor = System.Drawing.Color.YellowGreen;
            this.chkBxRainSound.Name = "chkBxRainSound";
            this.chkBxRainSound.UseVisualStyleBackColor = true;
            // 
            // btnRainRisk
            // 
            this.btnRainRisk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnRainRisk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.btnRainRisk, "btnRainRisk");
            this.btnRainRisk.ForeColor = System.Drawing.Color.White;
            this.btnRainRisk.Name = "btnRainRisk";
            this.btnRainRisk.ShowSecondText = true;
            this.btnRainRisk.SubTextFont = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRainRisk.SubTextForeColor = System.Drawing.Color.Yellow;
            this.btnRainRisk.SubTextSize = new System.Drawing.Size(138, 51);
            this.btnRainRisk.TextBoxHint = "";
            this.btnRainRisk.TextFont = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRainRisk.Click += new System.EventHandler(this.btnRainRisk_Click);
            // 
            // btnEvolFrequency
            // 
            this.btnEvolFrequency.BackColor = System.Drawing.Color.Transparent;
            this.btnEvolFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.btnEvolFrequency, "btnEvolFrequency");
            this.btnEvolFrequency.ForeColor = System.Drawing.Color.White;
            this.btnEvolFrequency.Name = "btnEvolFrequency";
            this.btnEvolFrequency.ShowSecondText = true;
            this.btnEvolFrequency.SubTextFont = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvolFrequency.SubTextForeColor = System.Drawing.Color.Yellow;
            this.btnEvolFrequency.SubTextSize = new System.Drawing.Size(138, 51);
            this.btnEvolFrequency.TextBoxHint = "";
            this.btnEvolFrequency.TextFont = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvolFrequency.Click += new System.EventHandler(this.btnEvolFrequency_Click);
            // 
            // pWeather
            // 
            this.pWeather.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pWeather.Appearance.BackColor")));
            this.pWeather.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.pWeather, "pWeather");
            this.pWeather.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pWeather.Controls.Add(this.edtTemp);
            this.pWeather.Controls.Add(this.pbWeather);
            this.pWeather.Controls.Add(this.btnNextWeather);
            this.pWeather.Controls.Add(this.label13);
            this.pWeather.Name = "pWeather";
            // 
            // edtTemp
            // 
            resources.ApplyResources(this.edtTemp, "edtTemp");
            this.edtTemp.Name = "edtTemp";
            // 
            // pbWeather
            // 
            this.pbWeather.EditValue = global::ESRM.Win.Images.SunnyRain1;
            resources.ApplyResources(this.pbWeather, "pbWeather");
            this.pbWeather.Name = "pbWeather";
            this.pbWeather.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pbWeather.Properties.Appearance.BackColor")));
            this.pbWeather.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("pbWeather.Properties.Appearance.Font")));
            this.pbWeather.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("pbWeather.Properties.Appearance.ForeColor")));
            this.pbWeather.Properties.Appearance.Options.UseBackColor = true;
            this.pbWeather.Properties.Appearance.Options.UseFont = true;
            this.pbWeather.Properties.Appearance.Options.UseForeColor = true;
            this.pbWeather.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbWeather.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pbWeather.Properties.ZoomAccelerationFactor = 1D;
            // 
            // btnNextWeather
            // 
            this.btnNextWeather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnNextWeather, "btnNextWeather");
            this.btnNextWeather.ForeColor = System.Drawing.Color.White;
            this.btnNextWeather.Name = "btnNextWeather";
            this.btnNextWeather.UseCompatibleTextRendering = true;
            this.btnNextWeather.UseVisualStyleBackColor = true;
            this.btnNextWeather.Click += new System.EventHandler(this.btnNextWeather_Click);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Name = "label13";
            // 
            // WeatherPanel
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(this.p1);
            this.Controls.Add(this.scalablePanel9);
            this.Controls.Add(this.panelTeamHeader);
            this.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.Name = "WeatherPanel";
            ((System.ComponentModel.ISupportInitialize)(this.panelTeamHeader)).EndInit();
            this.panelTeamHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelTeam)).EndInit();
            this.panelTeam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelName)).EndInit();
            this.panelName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            this.p1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pEvolve)).EndInit();
            this.pEvolve.ResumeLayout(false);
            this.pEvolve.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pAvgLapTime)).EndInit();
            this.pAvgLapTime.ResumeLayout(false);
            this.pAvgLapTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMaxTemp)).EndInit();
            this.pMaxTemp.ResumeLayout(false);
            this.pMaxTemp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMinTemp)).EndInit();
            this.pMinTemp.ResumeLayout(false);
            this.pMinTemp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scalablePanel9)).EndInit();
            this.scalablePanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pFrequency)).EndInit();
            this.pFrequency.ResumeLayout(false);
            this.pFrequency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pWeather)).EndInit();
            this.pWeather.ResumeLayout(false);
            this.pWeather.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeather.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ScalablePanel panelTeamHeader;
        private ScalablePanel panelTeam;
        private ScalablePanel panelName;
        private ESRMButton btnMaxTemp;
        private ESRMButton btnDownMaxTemp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMaxTemp;
        private ScalablePanel p1;
        private ScalablePanel pMinTemp;
        private ESRMButton btnDownMinTemp;
        private ESRMButton btnUpMinTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMinTemp;
        private ScalablePanel pMaxTemp;
        private ESRMButtonSelect btnShowOptimalTiresType;
        private ScalablePanel pEvolve;
        private ESRMButton btnDownEvolveInterval;
        private System.Windows.Forms.Label lblEvoleInterval;
        private System.Windows.Forms.Label label3;
        private ESRMButton btnUpEvolveInterval;
        private ScalablePanel pAvgLapTime;
        private ESRMButton btnDownLapTime;
        private ESRMButton btnUpLapTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAvgLapTime;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtEndTme;
        private System.Windows.Forms.Label label9;
        private ESRMButtonSelect btnRandomWeather;
        private ScalablePanel scalablePanel9;
        private ScalablePanel pFrequency;
        private ScalablePanel pWeather;
        private ESRMButton btnNextWeather;
        private ESRMButtonSelect btnEvolFrequency;
        private System.Windows.Forms.NumericUpDown edtTemp;
        private System.Windows.Forms.Label label13;
        private PictureEdit pbWeather;
        private ESRMButtonSelect btnRainRisk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBxRainSound;
    }
}
