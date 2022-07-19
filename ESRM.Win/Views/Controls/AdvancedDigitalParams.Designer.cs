using DevExpress.XtraEditors;

namespace ESRM.Win.Panels
{
    partial class AdvancedDigitalParams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedDigitalParams));
            this.scalablePanel1 = new ESRM.Win.ScalablePanel();
            this.lblConsigne = new System.Windows.Forms.Label();
            this.panelFill = new ESRM.Win.ScalablePanel();
            this.cbxCarIdProgrammerComPorts = new System.Windows.Forms.ComboBox();
            this.btnTestCarIdProgrammerConnexion = new ESRM.Win.ESRMButton();
            this.btnHighSpeedRumbles = new ESRM.Win.ESRMButtonSelect();
            this.btnVibrationsStrongBrakes = new ESRM.Win.ESRMButtonSelect();
            this.btnLowHealthLevel = new ESRM.Win.ESRMButtonForNumeric();
            this.btnLowFuelLevel = new ESRM.Win.ESRMButtonForNumeric();
            this.btnLowTiresLevel = new ESRM.Win.ESRMButtonForNumeric();
            this.btnMaxAccelerationDelta = new ESRM.Win.ESRMButtonForNumeric();
            this.btnTimeBetweenData = new ESRM.Win.ESRMButtonForNumeric();
            this.btnMaxBrakeIntervals = new ESRM.Win.ESRMButtonForNumeric();
            this.btnUseCarIdProgrammer = new ESRM.Win.ESRMButton();
            ((System.ComponentModel.ISupportInitialize)(this.scalablePanel1)).BeginInit();
            this.scalablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFill)).BeginInit();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // scalablePanel1
            // 
            this.scalablePanel1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("scalablePanel1.Appearance.BackColor")));
            this.scalablePanel1.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.scalablePanel1, "scalablePanel1");
            this.scalablePanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.scalablePanel1.Controls.Add(this.lblConsigne);
            this.scalablePanel1.Name = "scalablePanel1";
            // 
            // lblConsigne
            // 
            resources.ApplyResources(this.lblConsigne, "lblConsigne");
            this.lblConsigne.BackColor = System.Drawing.Color.Transparent;
            this.lblConsigne.ForeColor = System.Drawing.Color.White;
            this.lblConsigne.Name = "lblConsigne";
            // 
            // panelFill
            // 
            this.panelFill.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelFill.Appearance.BackColor")));
            this.panelFill.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.panelFill, "panelFill");
            this.panelFill.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFill.Controls.Add(this.btnUseCarIdProgrammer);
            this.panelFill.Controls.Add(this.cbxCarIdProgrammerComPorts);
            this.panelFill.Controls.Add(this.btnTestCarIdProgrammerConnexion);
            this.panelFill.Controls.Add(this.btnHighSpeedRumbles);
            this.panelFill.Controls.Add(this.btnVibrationsStrongBrakes);
            this.panelFill.Controls.Add(this.btnLowHealthLevel);
            this.panelFill.Controls.Add(this.btnLowFuelLevel);
            this.panelFill.Controls.Add(this.btnLowTiresLevel);
            this.panelFill.Controls.Add(this.btnMaxAccelerationDelta);
            this.panelFill.Controls.Add(this.btnTimeBetweenData);
            this.panelFill.Controls.Add(this.btnMaxBrakeIntervals);
            this.panelFill.Name = "panelFill";
            // 
            // cbxComPorts
            // 
            resources.ApplyResources(this.cbxCarIdProgrammerComPorts, "cbxComPorts");
            this.cbxCarIdProgrammerComPorts.FormattingEnabled = true;
            this.cbxCarIdProgrammerComPorts.Name = "cbxComPorts";
            // 
            // btnTestConnexion
            // 
            resources.ApplyResources(this.btnTestCarIdProgrammerConnexion, "btnTestConnexion");
            this.btnTestCarIdProgrammerConnexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTestCarIdProgrammerConnexion.ForeColor = System.Drawing.Color.White;
            this.btnTestCarIdProgrammerConnexion.Name = "btnTestConnexion";
            this.btnTestCarIdProgrammerConnexion.UseCompatibleTextRendering = true;
            this.btnTestCarIdProgrammerConnexion.UseVisualStyleBackColor = false;
            this.btnTestCarIdProgrammerConnexion.Click += new System.EventHandler(this.btnTestConnexion_Click);
            // 
            // btnHighSpeedRumbles
            // 
            resources.ApplyResources(this.btnHighSpeedRumbles, "btnHighSpeedRumbles");
            this.btnHighSpeedRumbles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnHighSpeedRumbles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnHighSpeedRumbles.ForeColor = System.Drawing.Color.White;
            this.btnHighSpeedRumbles.Name = "btnHighSpeedRumbles";
            this.btnHighSpeedRumbles.ShowSecondText = true;
            this.btnHighSpeedRumbles.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighSpeedRumbles.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnHighSpeedRumbles.SubTextSize = new System.Drawing.Size(138, 48);
            this.btnHighSpeedRumbles.TextBoxHint = "";
            this.btnHighSpeedRumbles.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHighSpeedRumbles.Click += new System.EventHandler(this.btnHighSpeedRumbles_Click);
            // 
            // btnVibrationsStrongBrakes
            // 
            resources.ApplyResources(this.btnVibrationsStrongBrakes, "btnVibrationsStrongBrakes");
            this.btnVibrationsStrongBrakes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnVibrationsStrongBrakes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnVibrationsStrongBrakes.ForeColor = System.Drawing.Color.White;
            this.btnVibrationsStrongBrakes.Name = "btnVibrationsStrongBrakes";
            this.btnVibrationsStrongBrakes.ShowSecondText = true;
            this.btnVibrationsStrongBrakes.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVibrationsStrongBrakes.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnVibrationsStrongBrakes.SubTextSize = new System.Drawing.Size(138, 48);
            this.btnVibrationsStrongBrakes.TextBoxHint = "";
            this.btnVibrationsStrongBrakes.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVibrationsStrongBrakes.Click += new System.EventHandler(this.btnVibrationsStrongBrakes_Click);
            // 
            // btnLowHealthLevel
            // 
            resources.ApplyResources(this.btnLowHealthLevel, "btnLowHealthLevel");
            this.btnLowHealthLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnLowHealthLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLowHealthLevel.ForeColor = System.Drawing.Color.White;
            this.btnLowHealthLevel.IsFloatValue = false;
            this.btnLowHealthLevel.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnLowHealthLevel.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnLowHealthLevel.Name = "btnLowHealthLevel";
            this.btnLowHealthLevel.ShowSecondText = true;
            this.btnLowHealthLevel.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLowHealthLevel.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnLowHealthLevel.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnLowFuelLevel
            // 
            resources.ApplyResources(this.btnLowFuelLevel, "btnLowFuelLevel");
            this.btnLowFuelLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnLowFuelLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLowFuelLevel.ForeColor = System.Drawing.Color.White;
            this.btnLowFuelLevel.IsFloatValue = false;
            this.btnLowFuelLevel.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnLowFuelLevel.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnLowFuelLevel.Name = "btnLowFuelLevel";
            this.btnLowFuelLevel.ShowSecondText = true;
            this.btnLowFuelLevel.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLowFuelLevel.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnLowFuelLevel.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnLowTiresLevel
            // 
            resources.ApplyResources(this.btnLowTiresLevel, "btnLowTiresLevel");
            this.btnLowTiresLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnLowTiresLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnLowTiresLevel.ForeColor = System.Drawing.Color.White;
            this.btnLowTiresLevel.IsFloatValue = false;
            this.btnLowTiresLevel.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.btnLowTiresLevel.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnLowTiresLevel.Name = "btnLowTiresLevel";
            this.btnLowTiresLevel.ShowSecondText = true;
            this.btnLowTiresLevel.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLowTiresLevel.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnLowTiresLevel.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnMaxAccelerationDelta
            // 
            resources.ApplyResources(this.btnMaxAccelerationDelta, "btnMaxAccelerationDelta");
            this.btnMaxAccelerationDelta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMaxAccelerationDelta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMaxAccelerationDelta.ForeColor = System.Drawing.Color.White;
            this.btnMaxAccelerationDelta.IsFloatValue = false;
            this.btnMaxAccelerationDelta.MaxValue = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.btnMaxAccelerationDelta.MinValue = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.btnMaxAccelerationDelta.Name = "btnMaxAccelerationDelta";
            this.btnMaxAccelerationDelta.ShowSecondText = true;
            this.btnMaxAccelerationDelta.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxAccelerationDelta.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMaxAccelerationDelta.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnTimeBetweenData
            // 
            resources.ApplyResources(this.btnTimeBetweenData, "btnTimeBetweenData");
            this.btnTimeBetweenData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTimeBetweenData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnTimeBetweenData.ForeColor = System.Drawing.Color.White;
            this.btnTimeBetweenData.IsFloatValue = false;
            this.btnTimeBetweenData.MaxValue = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.btnTimeBetweenData.MinValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.btnTimeBetweenData.Name = "btnTimeBetweenData";
            this.btnTimeBetweenData.ShowSecondText = true;
            this.btnTimeBetweenData.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeBetweenData.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnTimeBetweenData.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnMaxBrakeIntervals
            // 
            resources.ApplyResources(this.btnMaxBrakeIntervals, "btnMaxBrakeIntervals");
            this.btnMaxBrakeIntervals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMaxBrakeIntervals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMaxBrakeIntervals.ForeColor = System.Drawing.Color.White;
            this.btnMaxBrakeIntervals.IsFloatValue = false;
            this.btnMaxBrakeIntervals.MaxValue = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.btnMaxBrakeIntervals.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.btnMaxBrakeIntervals.Name = "btnMaxBrakeIntervals";
            this.btnMaxBrakeIntervals.ShowSecondText = true;
            this.btnMaxBrakeIntervals.SubTextFont = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaxBrakeIntervals.SubTextForeColor = System.Drawing.Color.YellowGreen;
            this.btnMaxBrakeIntervals.TextFont = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnUseCarIdProgrammer
            // 
            resources.ApplyResources(this.btnUseCarIdProgrammer, "btnUseCarIdProgrammer");
            this.btnUseCarIdProgrammer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnUseCarIdProgrammer.ForeColor = System.Drawing.Color.White;
            this.btnUseCarIdProgrammer.Name = "btnUseCarIdProgrammer";
            this.btnUseCarIdProgrammer.UseCompatibleTextRendering = true;
            this.btnUseCarIdProgrammer.UseVisualStyleBackColor = false;
            this.btnUseCarIdProgrammer.Click += new System.EventHandler(this.btnUseCarIdProgrammer_Click);
            // 
            // AdvancedDigitalParams
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.scalablePanel1);
            this.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.Name = "AdvancedDigitalParams";
            ((System.ComponentModel.ISupportInitialize)(this.scalablePanel1)).EndInit();
            this.scalablePanel1.ResumeLayout(false);
            this.scalablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFill)).EndInit();
            this.panelFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ScalablePanel scalablePanel1;
        private System.Windows.Forms.Label lblConsigne;
        private ScalablePanel panelFill;
        private ESRMButtonForNumeric btnLowHealthLevel;
        private ESRMButtonForNumeric btnLowFuelLevel;
        private ESRMButtonForNumeric btnLowTiresLevel;
        private ESRMButtonForNumeric btnMaxAccelerationDelta;
        private ESRMButtonForNumeric btnTimeBetweenData;
        private ESRMButtonForNumeric btnMaxBrakeIntervals;
        private ESRMButtonSelect btnHighSpeedRumbles;
        private ESRMButtonSelect btnVibrationsStrongBrakes;
        private System.Windows.Forms.ComboBox cbxCarIdProgrammerComPorts;
        private ESRMButton btnTestCarIdProgrammerConnexion;
        private ESRMButton btnUseCarIdProgrammer;
    }
}
