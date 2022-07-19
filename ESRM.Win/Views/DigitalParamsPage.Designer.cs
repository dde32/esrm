namespace ESRM.Win.Views
{
    partial class DigitalParamsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DigitalParamsPage));
            this.btnTCMethod = new ESRM.Win.ESRMButtonSelect();
            this.btnTest = new ESRM.Win.ESRMButton();
            this.btnOk = new ESRM.Win.ESRMButton();
            this.btnMaxDamages = new ESRM.Win.ESRMButtonForNumeric();
            this.btnNormalDamages = new ESRM.Win.ESRMButtonForNumeric();
            this.btnMinorDamages = new ESRM.Win.ESRMButtonForNumeric();
            this.btnMaxPenalityPower = new ESRM.Win.ESRMButtonForNumeric();
            this.btnMaxYFPower = new ESRM.Win.ESRMButtonForNumeric();
            this.btnZeroGaz = new ESRM.Win.ESRMButtonForNumeric();
            this.btnAutoGreenFlag = new ESRM.Win.ESRMButtonSelect();
            this.btnMaxPitPower = new ESRM.Win.ESRMButtonForNumeric();
            this.btnPitStopMethod = new ESRM.Win.ESRMButtonSelect();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBreakdownAction = new ESRM.Win.ESRMButtonSelect();
            this.btnAddLapOnPitStop = new ESRM.Win.ESRMButtonSelect();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxComPorts = new System.Windows.Forms.ComboBox();
            this.btnTestConnexion = new ESRM.Win.ESRMButton();
            this.lblConnection = new System.Windows.Forms.Label();
            this.panelGeneral = new ESRM.Win.ScalablePanel();
            this.btnTCDamages = new ESRM.Win.ESRMButtonForNumeric();
            this.edtPitPressDelay = new DevExpress.XtraEditors.SpinEdit();
            this.edtTCPressDelay = new DevExpress.XtraEditors.SpinEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUsePitDetection = new ESRM.Win.ESRMButtonSelect();
            this.btnConnectSL = new ESRM.Win.ESRMButton();
            this.cbxComPortsForSL = new System.Windows.Forms.ComboBox();
            this.btnUseStartLight = new ESRM.Win.ESRMButton();
            this.edtSensorsCount = new DevExpress.XtraEditors.SpinEdit();
            this.lblSensorsCount = new System.Windows.Forms.Label();
            this.btnConnectPitSS = new ESRM.Win.ESRMButton();
            this.cbxComPortsForPits = new System.Windows.Forms.ComboBox();
            this.btnPenalityOnTC = new ESRM.Win.ESRMButton();
            this.panelHeader = new ESRM.Win.ScalablePanel();
            this.btnTiresConfig = new ESRM.Win.ESRMButton();
            this.btnGlobalParams = new ESRM.Win.ESRMButton();
            this.scalablePanel1 = new ESRM.Win.ScalablePanel();
            this.panelHeaderButtons = new ESRM.Win.ScalablePanel();
            this.btnSounds = new ESRM.Win.ESRMButton();
            this.btnAdvancedParams = new ESRM.Win.ESRMButton();
            this.panelTires = new ESRM.Win.Panels.TiresParamsPanel();
            this.panelFiller = new ESRM.Win.ScalablePanel();
            this.advancedParams = new ESRM.Win.Panels.AdvancedDigitalParams();
            this.soundsParams1 = new ESRM.Win.Panels.SoundsParams();
            this.btnbrakeParams = new ESRM.Win.ESRMButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelGeneral)).BeginInit();
            this.panelGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPitPressDelay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTCPressDelay.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSensorsCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalablePanel1)).BeginInit();
            this.scalablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeaderButtons)).BeginInit();
            this.panelHeaderButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFiller)).BeginInit();
            this.panelFiller.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTCMethod
            // 
            resources.ApplyResources(this.btnTCMethod, "btnTCMethod");
            this.btnTCMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTCMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnTCMethod.ForeColor = System.Drawing.Color.White;
            this.btnTCMethod.Name = "btnTCMethod";
            this.btnTCMethod.ShowSecondText = true;
            this.btnTCMethod.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTCMethod.SubTextForeColor = System.Drawing.Color.LightSkyBlue;
            this.btnTCMethod.SubTextSize = new System.Drawing.Size(138, 48);
            this.btnTCMethod.TextBoxHint = "";
            this.btnTCMethod.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTCMethod.Click += new System.EventHandler(this.btnTCMethod_Click);
            // 
            // btnTest
            // 
            resources.ApplyResources(this.btnTest, "btnTest");
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTest.ForeColor = System.Drawing.Color.White;
            this.btnTest.Name = "btnTest";
            this.btnTest.UseCompatibleTextRendering = true;
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseCompatibleTextRendering = true;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnMaxDamages
            // 
            resources.ApplyResources(this.btnMaxDamages, "btnMaxDamages");
            this.btnMaxDamages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMaxDamages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMaxDamages.ForeColor = System.Drawing.Color.White;
            this.btnMaxDamages.IsFloatValue = false;
            this.btnMaxDamages.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnMaxDamages.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnMaxDamages.Name = "btnMaxDamages";
            this.btnMaxDamages.ShowSecondText = true;
            this.btnMaxDamages.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxDamages.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMaxDamages.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnNormalDamages
            // 
            resources.ApplyResources(this.btnNormalDamages, "btnNormalDamages");
            this.btnNormalDamages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnNormalDamages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnNormalDamages.ForeColor = System.Drawing.Color.White;
            this.btnNormalDamages.IsFloatValue = false;
            this.btnNormalDamages.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnNormalDamages.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnNormalDamages.Name = "btnNormalDamages";
            this.btnNormalDamages.ShowSecondText = true;
            this.btnNormalDamages.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNormalDamages.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnNormalDamages.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnMinorDamages
            // 
            resources.ApplyResources(this.btnMinorDamages, "btnMinorDamages");
            this.btnMinorDamages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMinorDamages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMinorDamages.ForeColor = System.Drawing.Color.White;
            this.btnMinorDamages.IsFloatValue = false;
            this.btnMinorDamages.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnMinorDamages.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnMinorDamages.Name = "btnMinorDamages";
            this.btnMinorDamages.ShowSecondText = true;
            this.btnMinorDamages.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinorDamages.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMinorDamages.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnMaxPenalityPower
            // 
            resources.ApplyResources(this.btnMaxPenalityPower, "btnMaxPenalityPower");
            this.btnMaxPenalityPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMaxPenalityPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMaxPenalityPower.ForeColor = System.Drawing.Color.White;
            this.btnMaxPenalityPower.IsFloatValue = false;
            this.btnMaxPenalityPower.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnMaxPenalityPower.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnMaxPenalityPower.Name = "btnMaxPenalityPower";
            this.btnMaxPenalityPower.ShowSecondText = true;
            this.btnMaxPenalityPower.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxPenalityPower.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMaxPenalityPower.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnMaxYFPower
            // 
            resources.ApplyResources(this.btnMaxYFPower, "btnMaxYFPower");
            this.btnMaxYFPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMaxYFPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMaxYFPower.ForeColor = System.Drawing.Color.White;
            this.btnMaxYFPower.IsFloatValue = false;
            this.btnMaxYFPower.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnMaxYFPower.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnMaxYFPower.Name = "btnMaxYFPower";
            this.btnMaxYFPower.ShowSecondText = true;
            this.btnMaxYFPower.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxYFPower.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMaxYFPower.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnZeroGaz
            // 
            resources.ApplyResources(this.btnZeroGaz, "btnZeroGaz");
            this.btnZeroGaz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnZeroGaz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnZeroGaz.ForeColor = System.Drawing.Color.White;
            this.btnZeroGaz.IsFloatValue = false;
            this.btnZeroGaz.MaxValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.btnZeroGaz.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnZeroGaz.Name = "btnZeroGaz";
            this.btnZeroGaz.ShowSecondText = true;
            this.btnZeroGaz.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroGaz.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnZeroGaz.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnAutoGreenFlag
            // 
            resources.ApplyResources(this.btnAutoGreenFlag, "btnAutoGreenFlag");
            this.btnAutoGreenFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnAutoGreenFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAutoGreenFlag.ForeColor = System.Drawing.Color.White;
            this.btnAutoGreenFlag.Name = "btnAutoGreenFlag";
            this.btnAutoGreenFlag.ShowSecondText = true;
            this.btnAutoGreenFlag.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoGreenFlag.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnAutoGreenFlag.SubTextSize = new System.Drawing.Size(138, 48);
            this.btnAutoGreenFlag.TextBoxHint = "";
            this.btnAutoGreenFlag.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoGreenFlag.Click += new System.EventHandler(this.btnAutoGreenFlag_Click);
            // 
            // btnMaxPitPower
            // 
            resources.ApplyResources(this.btnMaxPitPower, "btnMaxPitPower");
            this.btnMaxPitPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMaxPitPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMaxPitPower.ForeColor = System.Drawing.Color.White;
            this.btnMaxPitPower.IsFloatValue = false;
            this.btnMaxPitPower.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnMaxPitPower.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnMaxPitPower.Name = "btnMaxPitPower";
            this.btnMaxPitPower.ShowSecondText = true;
            this.btnMaxPitPower.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxPitPower.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMaxPitPower.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnPitStopMethod
            // 
            resources.ApplyResources(this.btnPitStopMethod, "btnPitStopMethod");
            this.btnPitStopMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnPitStopMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnPitStopMethod.ForeColor = System.Drawing.Color.White;
            this.btnPitStopMethod.Name = "btnPitStopMethod";
            this.btnPitStopMethod.ShowSecondText = true;
            this.btnPitStopMethod.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPitStopMethod.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnPitStopMethod.SubTextSize = new System.Drawing.Size(138, 48);
            this.btnPitStopMethod.TextBoxHint = "";
            this.btnPitStopMethod.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPitStopMethod.Click += new System.EventHandler(this.btnPitStopMethod_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // btnBreakdownAction
            // 
            resources.ApplyResources(this.btnBreakdownAction, "btnBreakdownAction");
            this.btnBreakdownAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnBreakdownAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnBreakdownAction.ForeColor = System.Drawing.Color.White;
            this.btnBreakdownAction.Name = "btnBreakdownAction";
            this.btnBreakdownAction.ShowSecondText = true;
            this.btnBreakdownAction.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBreakdownAction.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnBreakdownAction.SubTextSize = new System.Drawing.Size(138, 48);
            this.btnBreakdownAction.TextBoxHint = "";
            this.btnBreakdownAction.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBreakdownAction.Click += new System.EventHandler(this.btnBreakdownAction_Click);
            // 
            // btnAddLapOnPitStop
            // 
            resources.ApplyResources(this.btnAddLapOnPitStop, "btnAddLapOnPitStop");
            this.btnAddLapOnPitStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnAddLapOnPitStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddLapOnPitStop.ForeColor = System.Drawing.Color.White;
            this.btnAddLapOnPitStop.Name = "btnAddLapOnPitStop";
            this.btnAddLapOnPitStop.ShowSecondText = true;
            this.btnAddLapOnPitStop.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLapOnPitStop.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnAddLapOnPitStop.SubTextSize = new System.Drawing.Size(138, 48);
            this.btnAddLapOnPitStop.TextBoxHint = "";
            this.btnAddLapOnPitStop.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLapOnPitStop.Click += new System.EventHandler(this.btnAddLapOnPitStop_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // cbxComPorts
            // 
            resources.ApplyResources(this.cbxComPorts, "cbxComPorts");
            this.cbxComPorts.FormattingEnabled = true;
            this.cbxComPorts.Name = "cbxComPorts";
            // 
            // btnTestConnexion
            // 
            resources.ApplyResources(this.btnTestConnexion, "btnTestConnexion");
            this.btnTestConnexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTestConnexion.ForeColor = System.Drawing.Color.White;
            this.btnTestConnexion.Name = "btnTestConnexion";
            this.btnTestConnexion.UseCompatibleTextRendering = true;
            this.btnTestConnexion.UseVisualStyleBackColor = false;
            this.btnTestConnexion.Click += new System.EventHandler(this.btnTestConnexion_Click);
            // 
            // lblConnection
            // 
            resources.ApplyResources(this.lblConnection, "lblConnection");
            this.lblConnection.ForeColor = System.Drawing.Color.White;
            this.lblConnection.Name = "lblConnection";
            // 
            // panelGeneral
            // 
            resources.ApplyResources(this.panelGeneral, "panelGeneral");
            this.panelGeneral.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelGeneral.Controls.Add(this.btnTCDamages);
            this.panelGeneral.Controls.Add(this.edtPitPressDelay);
            this.panelGeneral.Controls.Add(this.edtTCPressDelay);
            this.panelGeneral.Controls.Add(this.groupBox1);
            this.panelGeneral.Controls.Add(this.btnPenalityOnTC);
            this.panelGeneral.Controls.Add(this.btnZeroGaz);
            this.panelGeneral.Controls.Add(this.btnMaxYFPower);
            this.panelGeneral.Controls.Add(this.btnAutoGreenFlag);
            this.panelGeneral.Controls.Add(this.btnMaxPenalityPower);
            this.panelGeneral.Controls.Add(this.label2);
            this.panelGeneral.Controls.Add(this.btnMaxPitPower);
            this.panelGeneral.Controls.Add(this.btnAddLapOnPitStop);
            this.panelGeneral.Controls.Add(this.btnMinorDamages);
            this.panelGeneral.Controls.Add(this.btnBreakdownAction);
            this.panelGeneral.Controls.Add(this.btnPitStopMethod);
            this.panelGeneral.Controls.Add(this.btnNormalDamages);
            this.panelGeneral.Controls.Add(this.label1);
            this.panelGeneral.Controls.Add(this.btnMaxDamages);
            this.panelGeneral.Controls.Add(this.btnTCMethod);
            this.panelGeneral.Name = "panelGeneral";
            // 
            // btnTCDamages
            // 
            resources.ApplyResources(this.btnTCDamages, "btnTCDamages");
            this.btnTCDamages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTCDamages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnTCDamages.ForeColor = System.Drawing.Color.White;
            this.btnTCDamages.IsFloatValue = false;
            this.btnTCDamages.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnTCDamages.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnTCDamages.Name = "btnTCDamages";
            this.btnTCDamages.ShowSecondText = true;
            this.btnTCDamages.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTCDamages.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnTCDamages.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // edtPitPressDelay
            // 
            resources.ApplyResources(this.edtPitPressDelay, "edtPitPressDelay");
            this.edtPitPressDelay.Name = "edtPitPressDelay";
            this.edtPitPressDelay.Properties.AccessibleDescription = resources.GetString("edtPitPressDelay.Properties.AccessibleDescription");
            this.edtPitPressDelay.Properties.AccessibleName = resources.GetString("edtPitPressDelay.Properties.AccessibleName");
            this.edtPitPressDelay.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("edtPitPressDelay.Properties.Appearance.BackColor")));
            this.edtPitPressDelay.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtPitPressDelay.Properties.Appearance.Font")));
            this.edtPitPressDelay.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("edtPitPressDelay.Properties.Appearance.FontSizeDelta")));
            this.edtPitPressDelay.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("edtPitPressDelay.Properties.Appearance.FontStyleDelta")));
            this.edtPitPressDelay.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("edtPitPressDelay.Properties.Appearance.ForeColor")));
            this.edtPitPressDelay.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("edtPitPressDelay.Properties.Appearance.GradientMode")));
            this.edtPitPressDelay.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("edtPitPressDelay.Properties.Appearance.Image")));
            this.edtPitPressDelay.Properties.Appearance.Options.UseBackColor = true;
            this.edtPitPressDelay.Properties.Appearance.Options.UseFont = true;
            this.edtPitPressDelay.Properties.Appearance.Options.UseForeColor = true;
            this.edtPitPressDelay.Properties.Appearance.Options.UseTextOptions = true;
            this.edtPitPressDelay.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtPitPressDelay.Properties.AutoHeight = ((bool)(resources.GetObject("edtPitPressDelay.Properties.AutoHeight")));
            this.edtPitPressDelay.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtPitPressDelay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtPitPressDelay.Properties.Buttons"))))});
            this.edtPitPressDelay.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.edtPitPressDelay.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.edtPitPressDelay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.edtPitPressDelay.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("edtPitPressDelay.Properties.Mask.AutoComplete")));
            this.edtPitPressDelay.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("edtPitPressDelay.Properties.Mask.BeepOnError")));
            this.edtPitPressDelay.Properties.Mask.EditMask = resources.GetString("edtPitPressDelay.Properties.Mask.EditMask");
            this.edtPitPressDelay.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("edtPitPressDelay.Properties.Mask.IgnoreMaskBlank")));
            this.edtPitPressDelay.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("edtPitPressDelay.Properties.Mask.MaskType")));
            this.edtPitPressDelay.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("edtPitPressDelay.Properties.Mask.PlaceHolder")));
            this.edtPitPressDelay.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("edtPitPressDelay.Properties.Mask.SaveLiteral")));
            this.edtPitPressDelay.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("edtPitPressDelay.Properties.Mask.ShowPlaceHolders")));
            this.edtPitPressDelay.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("edtPitPressDelay.Properties.Mask.UseMaskAsDisplayFormat")));
            this.edtPitPressDelay.Properties.NullValuePrompt = resources.GetString("edtPitPressDelay.Properties.NullValuePrompt");
            this.edtPitPressDelay.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("edtPitPressDelay.Properties.NullValuePromptShowForEmptyValue")));
            this.edtPitPressDelay.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // edtTCPressDelay
            // 
            resources.ApplyResources(this.edtTCPressDelay, "edtTCPressDelay");
            this.edtTCPressDelay.Name = "edtTCPressDelay";
            this.edtTCPressDelay.Properties.AccessibleDescription = resources.GetString("edtTCPressDelay.Properties.AccessibleDescription");
            this.edtTCPressDelay.Properties.AccessibleName = resources.GetString("edtTCPressDelay.Properties.AccessibleName");
            this.edtTCPressDelay.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("edtTCPressDelay.Properties.Appearance.BackColor")));
            this.edtTCPressDelay.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtTCPressDelay.Properties.Appearance.Font")));
            this.edtTCPressDelay.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("edtTCPressDelay.Properties.Appearance.FontSizeDelta")));
            this.edtTCPressDelay.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("edtTCPressDelay.Properties.Appearance.FontStyleDelta")));
            this.edtTCPressDelay.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("edtTCPressDelay.Properties.Appearance.ForeColor")));
            this.edtTCPressDelay.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("edtTCPressDelay.Properties.Appearance.GradientMode")));
            this.edtTCPressDelay.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("edtTCPressDelay.Properties.Appearance.Image")));
            this.edtTCPressDelay.Properties.Appearance.Options.UseBackColor = true;
            this.edtTCPressDelay.Properties.Appearance.Options.UseFont = true;
            this.edtTCPressDelay.Properties.Appearance.Options.UseForeColor = true;
            this.edtTCPressDelay.Properties.Appearance.Options.UseTextOptions = true;
            this.edtTCPressDelay.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtTCPressDelay.Properties.AutoHeight = ((bool)(resources.GetObject("edtTCPressDelay.Properties.AutoHeight")));
            this.edtTCPressDelay.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtTCPressDelay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtTCPressDelay.Properties.Buttons"))))});
            this.edtTCPressDelay.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.edtTCPressDelay.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.edtTCPressDelay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.edtTCPressDelay.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("edtTCPressDelay.Properties.Mask.AutoComplete")));
            this.edtTCPressDelay.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("edtTCPressDelay.Properties.Mask.BeepOnError")));
            this.edtTCPressDelay.Properties.Mask.EditMask = resources.GetString("edtTCPressDelay.Properties.Mask.EditMask");
            this.edtTCPressDelay.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("edtTCPressDelay.Properties.Mask.IgnoreMaskBlank")));
            this.edtTCPressDelay.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("edtTCPressDelay.Properties.Mask.MaskType")));
            this.edtTCPressDelay.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("edtTCPressDelay.Properties.Mask.PlaceHolder")));
            this.edtTCPressDelay.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("edtTCPressDelay.Properties.Mask.SaveLiteral")));
            this.edtTCPressDelay.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("edtTCPressDelay.Properties.Mask.ShowPlaceHolders")));
            this.edtTCPressDelay.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("edtTCPressDelay.Properties.Mask.UseMaskAsDisplayFormat")));
            this.edtTCPressDelay.Properties.NullValuePrompt = resources.GetString("edtTCPressDelay.Properties.NullValuePrompt");
            this.edtTCPressDelay.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("edtTCPressDelay.Properties.NullValuePromptShowForEmptyValue")));
            this.edtTCPressDelay.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.btnUsePitDetection);
            this.groupBox1.Controls.Add(this.btnConnectSL);
            this.groupBox1.Controls.Add(this.cbxComPortsForSL);
            this.groupBox1.Controls.Add(this.btnUseStartLight);
            this.groupBox1.Controls.Add(this.edtSensorsCount);
            this.groupBox1.Controls.Add(this.lblSensorsCount);
            this.groupBox1.Controls.Add(this.cbxComPorts);
            this.groupBox1.Controls.Add(this.lblConnection);
            this.groupBox1.Controls.Add(this.btnConnectPitSS);
            this.groupBox1.Controls.Add(this.btnTestConnexion);
            this.groupBox1.Controls.Add(this.cbxComPortsForPits);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnUsePitDetection
            // 
            resources.ApplyResources(this.btnUsePitDetection, "btnUsePitDetection");
            this.btnUsePitDetection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnUsePitDetection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnUsePitDetection.ForeColor = System.Drawing.Color.White;
            this.btnUsePitDetection.Name = "btnUsePitDetection";
            this.btnUsePitDetection.ShowSecondText = true;
            this.btnUsePitDetection.SubTextFont = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsePitDetection.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnUsePitDetection.SubTextSize = new System.Drawing.Size(138, 36);
            this.btnUsePitDetection.TextBoxHint = "";
            this.btnUsePitDetection.TextFont = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsePitDetection.Click += new System.EventHandler(this.btnUsePitDetection_Click);
            // 
            // btnConnectSL
            // 
            resources.ApplyResources(this.btnConnectSL, "btnConnectSL");
            this.btnConnectSL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnConnectSL.ForeColor = System.Drawing.Color.White;
            this.btnConnectSL.Name = "btnConnectSL";
            this.btnConnectSL.UseCompatibleTextRendering = true;
            this.btnConnectSL.UseVisualStyleBackColor = false;
            this.btnConnectSL.Click += new System.EventHandler(this.btnConnectSL_Click);
            // 
            // cbxComPortsForSL
            // 
            resources.ApplyResources(this.cbxComPortsForSL, "cbxComPortsForSL");
            this.cbxComPortsForSL.FormattingEnabled = true;
            this.cbxComPortsForSL.Name = "cbxComPortsForSL";
            // 
            // btnUseStartLight
            // 
            resources.ApplyResources(this.btnUseStartLight, "btnUseStartLight");
            this.btnUseStartLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnUseStartLight.ForeColor = System.Drawing.Color.White;
            this.btnUseStartLight.Name = "btnUseStartLight";
            this.btnUseStartLight.UseCompatibleTextRendering = true;
            this.btnUseStartLight.UseVisualStyleBackColor = false;
            this.btnUseStartLight.Click += new System.EventHandler(this.btnUseStartLight_Click);
            // 
            // edtSensorsCount
            // 
            resources.ApplyResources(this.edtSensorsCount, "edtSensorsCount");
            this.edtSensorsCount.Name = "edtSensorsCount";
            this.edtSensorsCount.Properties.AccessibleDescription = resources.GetString("edtSensorsCount.Properties.AccessibleDescription");
            this.edtSensorsCount.Properties.AccessibleName = resources.GetString("edtSensorsCount.Properties.AccessibleName");
            this.edtSensorsCount.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("edtSensorsCount.Properties.Appearance.BackColor")));
            this.edtSensorsCount.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtSensorsCount.Properties.Appearance.Font")));
            this.edtSensorsCount.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("edtSensorsCount.Properties.Appearance.FontSizeDelta")));
            this.edtSensorsCount.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("edtSensorsCount.Properties.Appearance.FontStyleDelta")));
            this.edtSensorsCount.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("edtSensorsCount.Properties.Appearance.ForeColor")));
            this.edtSensorsCount.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("edtSensorsCount.Properties.Appearance.GradientMode")));
            this.edtSensorsCount.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("edtSensorsCount.Properties.Appearance.Image")));
            this.edtSensorsCount.Properties.Appearance.Options.UseBackColor = true;
            this.edtSensorsCount.Properties.Appearance.Options.UseFont = true;
            this.edtSensorsCount.Properties.Appearance.Options.UseForeColor = true;
            this.edtSensorsCount.Properties.Appearance.Options.UseTextOptions = true;
            this.edtSensorsCount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.edtSensorsCount.Properties.AutoHeight = ((bool)(resources.GetObject("edtSensorsCount.Properties.AutoHeight")));
            this.edtSensorsCount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtSensorsCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtSensorsCount.Properties.Buttons"))))});
            this.edtSensorsCount.Properties.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.edtSensorsCount.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.edtSensorsCount.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.edtSensorsCount.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("edtSensorsCount.Properties.Mask.AutoComplete")));
            this.edtSensorsCount.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("edtSensorsCount.Properties.Mask.BeepOnError")));
            this.edtSensorsCount.Properties.Mask.EditMask = resources.GetString("edtSensorsCount.Properties.Mask.EditMask");
            this.edtSensorsCount.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("edtSensorsCount.Properties.Mask.IgnoreMaskBlank")));
            this.edtSensorsCount.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("edtSensorsCount.Properties.Mask.MaskType")));
            this.edtSensorsCount.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("edtSensorsCount.Properties.Mask.PlaceHolder")));
            this.edtSensorsCount.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("edtSensorsCount.Properties.Mask.SaveLiteral")));
            this.edtSensorsCount.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("edtSensorsCount.Properties.Mask.ShowPlaceHolders")));
            this.edtSensorsCount.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("edtSensorsCount.Properties.Mask.UseMaskAsDisplayFormat")));
            this.edtSensorsCount.Properties.NullValuePrompt = resources.GetString("edtSensorsCount.Properties.NullValuePrompt");
            this.edtSensorsCount.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("edtSensorsCount.Properties.NullValuePromptShowForEmptyValue")));
            this.edtSensorsCount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // lblSensorsCount
            // 
            resources.ApplyResources(this.lblSensorsCount, "lblSensorsCount");
            this.lblSensorsCount.ForeColor = System.Drawing.Color.White;
            this.lblSensorsCount.Name = "lblSensorsCount";
            // 
            // btnConnectPitSS
            // 
            resources.ApplyResources(this.btnConnectPitSS, "btnConnectPitSS");
            this.btnConnectPitSS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnConnectPitSS.ForeColor = System.Drawing.Color.White;
            this.btnConnectPitSS.Name = "btnConnectPitSS";
            this.btnConnectPitSS.UseCompatibleTextRendering = true;
            this.btnConnectPitSS.UseVisualStyleBackColor = false;
            this.btnConnectPitSS.Click += new System.EventHandler(this.btnConnectPitSS_Click);
            // 
            // cbxComPortsForPits
            // 
            resources.ApplyResources(this.cbxComPortsForPits, "cbxComPortsForPits");
            this.cbxComPortsForPits.FormattingEnabled = true;
            this.cbxComPortsForPits.Name = "cbxComPortsForPits";
            // 
            // btnPenalityOnTC
            // 
            resources.ApplyResources(this.btnPenalityOnTC, "btnPenalityOnTC");
            this.btnPenalityOnTC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnPenalityOnTC.ForeColor = System.Drawing.Color.White;
            this.btnPenalityOnTC.Name = "btnPenalityOnTC";
            this.btnPenalityOnTC.UseCompatibleTextRendering = true;
            this.btnPenalityOnTC.UseVisualStyleBackColor = false;
            this.btnPenalityOnTC.Click += new System.EventHandler(this.btnPenalityOnTC_Click);
            // 
            // panelHeader
            // 
            resources.ApplyResources(this.panelHeader, "panelHeader");
            this.panelHeader.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelHeader.Appearance.BackColor")));
            this.panelHeader.Appearance.FontSizeDelta = ((int)(resources.GetObject("panelHeader.Appearance.FontSizeDelta")));
            this.panelHeader.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("panelHeader.Appearance.FontStyleDelta")));
            this.panelHeader.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("panelHeader.Appearance.GradientMode")));
            this.panelHeader.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("panelHeader.Appearance.Image")));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Name = "panelHeader";
            // 
            // btnTiresConfig
            // 
            resources.ApplyResources(this.btnTiresConfig, "btnTiresConfig");
            this.btnTiresConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTiresConfig.ForeColor = System.Drawing.Color.DimGray;
            this.btnTiresConfig.Name = "btnTiresConfig";
            this.btnTiresConfig.UseCompatibleTextRendering = true;
            this.btnTiresConfig.UseVisualStyleBackColor = true;
            this.btnTiresConfig.Click += new System.EventHandler(this.btnbrakeParams_Click);
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
            // scalablePanel1
            // 
            resources.ApplyResources(this.scalablePanel1, "scalablePanel1");
            this.scalablePanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.scalablePanel1.Controls.Add(this.btnOk);
            this.scalablePanel1.Name = "scalablePanel1";
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
            this.panelHeaderButtons.Controls.Add(this.btnSounds);
            this.panelHeaderButtons.Controls.Add(this.btnAdvancedParams);
            this.panelHeaderButtons.Controls.Add(this.btnTiresConfig);
            this.panelHeaderButtons.Controls.Add(this.btnGlobalParams);
            this.panelHeaderButtons.Controls.Add(this.btnTest);
            this.panelHeaderButtons.Name = "panelHeaderButtons";
            // 
            // btnSounds
            // 
            resources.ApplyResources(this.btnSounds, "btnSounds");
            this.btnSounds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSounds.ForeColor = System.Drawing.Color.DimGray;
            this.btnSounds.Name = "btnSounds";
            this.btnSounds.UseCompatibleTextRendering = true;
            this.btnSounds.UseVisualStyleBackColor = true;
            this.btnSounds.Click += new System.EventHandler(this.btnSounds_Click);
            // 
            // btnAdvancedParams
            // 
            resources.ApplyResources(this.btnAdvancedParams, "btnAdvancedParams");
            this.btnAdvancedParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnAdvancedParams.ForeColor = System.Drawing.Color.DimGray;
            this.btnAdvancedParams.Name = "btnAdvancedParams";
            this.btnAdvancedParams.UseCompatibleTextRendering = true;
            this.btnAdvancedParams.UseVisualStyleBackColor = true;
            this.btnAdvancedParams.Click += new System.EventHandler(this.btnAdvancedParams_Click);
            // 
            // panelTires
            // 
            resources.ApplyResources(this.panelTires, "panelTires");
            this.panelTires.BackColor = System.Drawing.Color.Transparent;
            this.panelTires.ForeColor = System.Drawing.Color.White;
            this.panelTires.Name = "panelTires";
            // 
            // panelFiller
            // 
            resources.ApplyResources(this.panelFiller, "panelFiller");
            this.panelFiller.AllowTouchScroll = true;
            this.panelFiller.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFiller.Controls.Add(this.panelGeneral);
            this.panelFiller.Controls.Add(this.panelTires);
            this.panelFiller.Controls.Add(this.advancedParams);
            this.panelFiller.Controls.Add(this.soundsParams1);
            this.panelFiller.Name = "panelFiller";
            // 
            // advancedParams
            // 
            resources.ApplyResources(this.advancedParams, "advancedParams");
            this.advancedParams.BackColor = System.Drawing.Color.Transparent;
            this.advancedParams.ForeColor = System.Drawing.Color.White;
            this.advancedParams.Name = "advancedParams";
            // 
            // soundsParams1
            // 
            resources.ApplyResources(this.soundsParams1, "soundsParams1");
            this.soundsParams1.BackColor = System.Drawing.Color.Transparent;
            this.soundsParams1.ForeColor = System.Drawing.Color.White;
            this.soundsParams1.Name = "soundsParams1";
            // 
            // btnbrakeParams
            // 
            resources.ApplyResources(this.btnbrakeParams, "btnbrakeParams");
            this.btnbrakeParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnbrakeParams.ForeColor = System.Drawing.Color.DimGray;
            this.btnbrakeParams.Name = "btnbrakeParams";
            this.btnbrakeParams.UseCompatibleTextRendering = true;
            this.btnbrakeParams.UseVisualStyleBackColor = true;
            this.btnbrakeParams.Click += new System.EventHandler(this.btnbrakeParams_Click);
            // 
            // DigitalParamsPage
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::ESRM.Win.Images.background;
            this.Controls.Add(this.panelFiller);
            this.Controls.Add(this.panelHeaderButtons);
            this.Controls.Add(this.scalablePanel1);
            this.Name = "DigitalParamsPage";
            ((System.ComponentModel.ISupportInitialize)(this.panelGeneral)).EndInit();
            this.panelGeneral.ResumeLayout(false);
            this.panelGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPitPressDelay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTCPressDelay.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSensorsCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalablePanel1)).EndInit();
            this.scalablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelHeaderButtons)).EndInit();
            this.panelHeaderButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelFiller)).EndInit();
            this.panelFiller.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ESRMButtonSelect btnTCMethod;
        private System.Windows.Forms.Label label1;
        private ESRMButtonSelect btnAutoGreenFlag;
        private ESRMButtonForNumeric btnMaxPitPower;
        private ESRMButtonSelect btnPitStopMethod;
        private ESRMButtonForNumeric btnMinorDamages;
        private ESRMButtonForNumeric btnMaxPenalityPower;
        private ESRMButtonForNumeric btnMaxYFPower;
        private ESRMButtonForNumeric btnZeroGaz;
        private ESRMButtonForNumeric btnMaxDamages;
        private ESRMButtonForNumeric btnNormalDamages;
        private ESRMButton btnOk;
        private ESRMButton btnTest;
        private ESRMButtonSelect btnBreakdownAction;
        private ESRMButtonSelect btnAddLapOnPitStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxComPorts;
        private ESRMButton btnTestConnexion;
        private System.Windows.Forms.Label lblConnection;
        private ScalablePanel panelGeneral;
        private ScalablePanel panelHeader;
        private ESRMButton btnTiresConfig;
        private ESRMButton btnGlobalParams;
        private ScalablePanel scalablePanel1;
        private ScalablePanel panelHeaderButtons;
        private Panels.TiresParamsPanel panelTires;
        private ScalablePanel panelFiller;
        private ESRMButton btnbrakeParams;
        private ESRMButton btnPenalityOnTC;
        private ESRMButton btnConnectPitSS;
        private System.Windows.Forms.ComboBox cbxComPortsForPits;
        private System.Windows.Forms.Label lblSensorsCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SpinEdit edtPitPressDelay;
        private DevExpress.XtraEditors.SpinEdit edtTCPressDelay;
        private DevExpress.XtraEditors.SpinEdit edtSensorsCount;
        private ESRMButton btnAdvancedParams;
        private Panels.AdvancedDigitalParams advancedParams;
        private ESRMButton btnSounds;
        private Panels.SoundsParams soundsParams1;
        private ESRMButtonForNumeric btnTCDamages;
        private ESRMButtonSelect btnUsePitDetection;
        private ESRMButton btnConnectSL;
        private System.Windows.Forms.ComboBox cbxComPortsForSL;
        private ESRMButton btnUseStartLight;
    }
}
