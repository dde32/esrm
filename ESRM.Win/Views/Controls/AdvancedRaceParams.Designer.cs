using DevExpress.XtraEditors;

namespace ESRM.Win.Panels
{
    partial class AdvancedRaceParams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedRaceParams));
            this.panelFill = new ESRM.Win.ScalablePanel();
            this.btnEnablePauseByPilot = new ESRM.Win.ESRMButtonSelectBool();
            this.btnEnablePowerAdjustemen = new ESRM.Win.ESRMButtonSelectBool();
            this.btnMaxPower = new ESRM.Win.ESRMButtonForNumeric();
            this.btnOneByOneRace = new ESRM.Win.ESRMButtonSelectBool();
            this.btnMultiCarTeams = new ESRM.Win.ESRMButtonSelectBool();
            this.btnJokerLapCount = new ESRM.Win.ESRMButtonForNumeric();
            this.btnDeslotAutoDetect2 = new ESRM.Win.ESRMButtonForNumeric();
            this.btnRepairSpeed = new ESRM.Win.ESRMButtonForNumeric();
            this.btnFuelSpeed = new ESRM.Win.ESRMButtonForNumeric();
            this.btnMaxRepair = new ESRM.Win.ESRMButtonForNumeric();
            this.btnMinLapTime = new ESRM.Win.ESRMButtonForNumeric();
            this.btnMandatoryPitStops = new ESRM.Win.ESRMButtonForNumeric();
            this.btnRollingStart = new ESRM.Win.ESRMButtonSelect();
            this.btnAutoRefuel = new ESRM.Win.ESRMButtonSelect();
            this.btnEndRace = new ESRM.Win.ESRMButtonSelect();
            ((System.ComponentModel.ISupportInitialize)(this.panelFill)).BeginInit();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFill
            // 
            resources.ApplyResources(this.panelFill, "panelFill");
            this.panelFill.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelFill.Appearance.BackColor")));
            this.panelFill.Appearance.FontSizeDelta = ((int)(resources.GetObject("panelFill.Appearance.FontSizeDelta")));
            this.panelFill.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("panelFill.Appearance.FontStyleDelta")));
            this.panelFill.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("panelFill.Appearance.GradientMode")));
            this.panelFill.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("panelFill.Appearance.Image")));
            this.panelFill.Appearance.Options.UseBackColor = true;
            this.panelFill.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFill.Controls.Add(this.btnEnablePauseByPilot);
            this.panelFill.Controls.Add(this.btnEnablePowerAdjustemen);
            this.panelFill.Controls.Add(this.btnMaxPower);
            this.panelFill.Controls.Add(this.btnOneByOneRace);
            this.panelFill.Controls.Add(this.btnMultiCarTeams);
            this.panelFill.Controls.Add(this.btnJokerLapCount);
            this.panelFill.Controls.Add(this.btnDeslotAutoDetect2);
            this.panelFill.Controls.Add(this.btnRepairSpeed);
            this.panelFill.Controls.Add(this.btnFuelSpeed);
            this.panelFill.Controls.Add(this.btnMaxRepair);
            this.panelFill.Controls.Add(this.btnMinLapTime);
            this.panelFill.Controls.Add(this.btnMandatoryPitStops);
            this.panelFill.Controls.Add(this.btnRollingStart);
            this.panelFill.Controls.Add(this.btnAutoRefuel);
            this.panelFill.Controls.Add(this.btnEndRace);
            this.panelFill.Name = "panelFill";
            // 
            // btnEnablePauseByPilot
            // 
            resources.ApplyResources(this.btnEnablePauseByPilot, "btnEnablePauseByPilot");
            this.btnEnablePauseByPilot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnEnablePauseByPilot.BoolValue = false;
            this.btnEnablePauseByPilot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEnablePauseByPilot.ForeColor = System.Drawing.Color.White;
            this.btnEnablePauseByPilot.Name = "btnEnablePauseByPilot";
            this.btnEnablePauseByPilot.ShowSecondText = true;
            this.btnEnablePauseByPilot.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnablePauseByPilot.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnEnablePauseByPilot.SubTextSize = new System.Drawing.Size(138, 46);
            this.btnEnablePauseByPilot.TextBoxHint = "";
            this.btnEnablePauseByPilot.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnablePauseByPilot.Click += new System.EventHandler(this.btnEnablePauseByPilot_Click);
            // 
            // btnEnablePowerAdjustemen
            // 
            resources.ApplyResources(this.btnEnablePowerAdjustemen, "btnEnablePowerAdjustemen");
            this.btnEnablePowerAdjustemen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnEnablePowerAdjustemen.BoolValue = false;
            this.btnEnablePowerAdjustemen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEnablePowerAdjustemen.ForeColor = System.Drawing.Color.White;
            this.btnEnablePowerAdjustemen.Name = "btnEnablePowerAdjustemen";
            this.btnEnablePowerAdjustemen.ShowSecondText = true;
            this.btnEnablePowerAdjustemen.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnablePowerAdjustemen.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnEnablePowerAdjustemen.SubTextSize = new System.Drawing.Size(138, 47);
            this.btnEnablePowerAdjustemen.TextBoxHint = "";
            this.btnEnablePowerAdjustemen.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnablePowerAdjustemen.Click += new System.EventHandler(this.btnEnablePowerAdjustemen_Click);
            // 
            // btnMaxPower
            // 
            resources.ApplyResources(this.btnMaxPower, "btnMaxPower");
            this.btnMaxPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMaxPower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMaxPower.ForeColor = System.Drawing.Color.White;
            this.btnMaxPower.IsFloatValue = false;
            this.btnMaxPower.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnMaxPower.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnMaxPower.Name = "btnMaxPower";
            this.btnMaxPower.ShowSecondText = true;
            this.btnMaxPower.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxPower.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMaxPower.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnOneByOneRace
            // 
            resources.ApplyResources(this.btnOneByOneRace, "btnOneByOneRace");
            this.btnOneByOneRace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOneByOneRace.BoolValue = false;
            this.btnOneByOneRace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnOneByOneRace.ForeColor = System.Drawing.Color.White;
            this.btnOneByOneRace.Name = "btnOneByOneRace";
            this.btnOneByOneRace.ShowSecondText = true;
            this.btnOneByOneRace.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOneByOneRace.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnOneByOneRace.SubTextSize = new System.Drawing.Size(138, 44);
            this.btnOneByOneRace.TextBoxHint = "";
            this.btnOneByOneRace.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOneByOneRace.Click += new System.EventHandler(this.btnOneByOneRace_Click);
            // 
            // btnMultiCarTeams
            // 
            resources.ApplyResources(this.btnMultiCarTeams, "btnMultiCarTeams");
            this.btnMultiCarTeams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMultiCarTeams.BoolValue = false;
            this.btnMultiCarTeams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMultiCarTeams.ForeColor = System.Drawing.Color.White;
            this.btnMultiCarTeams.Name = "btnMultiCarTeams";
            this.btnMultiCarTeams.ShowSecondText = true;
            this.btnMultiCarTeams.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiCarTeams.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMultiCarTeams.SubTextSize = new System.Drawing.Size(138, 44);
            this.btnMultiCarTeams.TextBoxHint = "";
            this.btnMultiCarTeams.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiCarTeams.Click += new System.EventHandler(this.btnMultiCarTeams_Click);
            // 
            // btnJokerLapCount
            // 
            resources.ApplyResources(this.btnJokerLapCount, "btnJokerLapCount");
            this.btnJokerLapCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnJokerLapCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnJokerLapCount.ForeColor = System.Drawing.Color.White;
            this.btnJokerLapCount.IsFloatValue = false;
            this.btnJokerLapCount.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnJokerLapCount.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnJokerLapCount.Name = "btnJokerLapCount";
            this.btnJokerLapCount.ShowSecondText = true;
            this.btnJokerLapCount.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJokerLapCount.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnJokerLapCount.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnDeslotAutoDetect2
            // 
            resources.ApplyResources(this.btnDeslotAutoDetect2, "btnDeslotAutoDetect2");
            this.btnDeslotAutoDetect2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnDeslotAutoDetect2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDeslotAutoDetect2.ForeColor = System.Drawing.Color.White;
            this.btnDeslotAutoDetect2.IsFloatValue = true;
            this.btnDeslotAutoDetect2.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.btnDeslotAutoDetect2.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnDeslotAutoDetect2.Name = "btnDeslotAutoDetect2";
            this.btnDeslotAutoDetect2.ShowSecondText = true;
            this.btnDeslotAutoDetect2.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeslotAutoDetect2.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnDeslotAutoDetect2.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnRepairSpeed
            // 
            resources.ApplyResources(this.btnRepairSpeed, "btnRepairSpeed");
            this.btnRepairSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnRepairSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRepairSpeed.ForeColor = System.Drawing.Color.White;
            this.btnRepairSpeed.IsFloatValue = false;
            this.btnRepairSpeed.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnRepairSpeed.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnRepairSpeed.Name = "btnRepairSpeed";
            this.btnRepairSpeed.ShowSecondText = true;
            this.btnRepairSpeed.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepairSpeed.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnRepairSpeed.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnFuelSpeed
            // 
            resources.ApplyResources(this.btnFuelSpeed, "btnFuelSpeed");
            this.btnFuelSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnFuelSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnFuelSpeed.ForeColor = System.Drawing.Color.White;
            this.btnFuelSpeed.IsFloatValue = false;
            this.btnFuelSpeed.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnFuelSpeed.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnFuelSpeed.Name = "btnFuelSpeed";
            this.btnFuelSpeed.ShowSecondText = true;
            this.btnFuelSpeed.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuelSpeed.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnFuelSpeed.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnMaxRepair
            // 
            resources.ApplyResources(this.btnMaxRepair, "btnMaxRepair");
            this.btnMaxRepair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMaxRepair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMaxRepair.ForeColor = System.Drawing.Color.White;
            this.btnMaxRepair.IsFloatValue = false;
            this.btnMaxRepair.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnMaxRepair.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnMaxRepair.Name = "btnMaxRepair";
            this.btnMaxRepair.ShowSecondText = true;
            this.btnMaxRepair.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxRepair.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMaxRepair.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // btnMandatoryPitStops
            // 
            resources.ApplyResources(this.btnMandatoryPitStops, "btnMandatoryPitStops");
            this.btnMandatoryPitStops.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMandatoryPitStops.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMandatoryPitStops.ForeColor = System.Drawing.Color.White;
            this.btnMandatoryPitStops.IsFloatValue = false;
            this.btnMandatoryPitStops.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnMandatoryPitStops.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnMandatoryPitStops.Name = "btnMandatoryPitStops";
            this.btnMandatoryPitStops.ShowSecondText = true;
            this.btnMandatoryPitStops.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMandatoryPitStops.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMandatoryPitStops.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnRollingStart
            // 
            resources.ApplyResources(this.btnRollingStart, "btnRollingStart");
            this.btnRollingStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnRollingStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRollingStart.ForeColor = System.Drawing.Color.White;
            this.btnRollingStart.Name = "btnRollingStart";
            this.btnRollingStart.ShowSecondText = true;
            this.btnRollingStart.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollingStart.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnRollingStart.SubTextSize = new System.Drawing.Size(138, 46);
            this.btnRollingStart.TextBoxHint = "Choix du mode de fin de course. Standard : Le premier termine les suivants termin" +
    "ent le tour en cours. Tout le monde : Tous les pilotes doivent parcourir le nomb" +
    "re de tour";
            this.btnRollingStart.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollingStart.Click += new System.EventHandler(this.btnRollingStart_Click);
            // 
            // btnAutoRefuel
            // 
            resources.ApplyResources(this.btnAutoRefuel, "btnAutoRefuel");
            this.btnAutoRefuel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnAutoRefuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAutoRefuel.ForeColor = System.Drawing.Color.White;
            this.btnAutoRefuel.Name = "btnAutoRefuel";
            this.btnAutoRefuel.ShowSecondText = true;
            this.btnAutoRefuel.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoRefuel.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnAutoRefuel.SubTextSize = new System.Drawing.Size(138, 46);
            this.btnAutoRefuel.TextBoxHint = "";
            this.btnAutoRefuel.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoRefuel.Click += new System.EventHandler(this.btnAutoRefuel_Click);
            // 
            // btnEndRace
            // 
            resources.ApplyResources(this.btnEndRace, "btnEndRace");
            this.btnEndRace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnEndRace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEndRace.ForeColor = System.Drawing.Color.White;
            this.btnEndRace.Name = "btnEndRace";
            this.btnEndRace.ShowSecondText = true;
            this.btnEndRace.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndRace.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnEndRace.SubTextSize = new System.Drawing.Size(138, 46);
            this.btnEndRace.TextBoxHint = "Choice of type of race end. Standard: When the winner has finished, the others ju" +
    "st complete their ";
            this.btnEndRace.TextFont = new System.Drawing.Font("Impact", 18.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndRace.Click += new System.EventHandler(this.btnEndRace_Click);
            // 
            // AdvancedRaceParams
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(this.panelFill);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "AdvancedRaceParams";
            ((System.ComponentModel.ISupportInitialize)(this.panelFill)).EndInit();
            this.panelFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ScalablePanel panelFill;
        private ESRMButtonSelect btnAutoRefuel;
        private ESRMButtonSelect btnEndRace;
        private ESRMButtonSelect btnRollingStart;
        private ESRMButtonForNumeric btnMandatoryPitStops;
        private ESRMButtonForNumeric btnMinLapTime;
        private ESRMButtonForNumeric btnRepairSpeed;
        private ESRMButtonForNumeric btnFuelSpeed;
        private ESRMButtonForNumeric btnMaxRepair;
        private ESRMButtonForNumeric btnDeslotAutoDetect2;
        private ESRMButtonForNumeric btnJokerLapCount;
        private ESRMButtonSelectBool btnMultiCarTeams;
        private ESRMButtonSelectBool btnEnablePowerAdjustemen;
        private ESRMButtonForNumeric btnMaxPower;
        private ESRMButtonSelectBool btnOneByOneRace;
        private ESRMButtonSelectBool btnEnablePauseByPilot;
    }
}
