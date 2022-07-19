namespace ESRM.Win
{
    partial class MonitoringDlg
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitoringDlg));
            this.btnSTOP = new ESRM.Win.ESRMButton();
            this.btnClose = new ESRM.Win.ESRMButton();
            this.btnStartPause = new ESRM.Win.ESRMButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TeamsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnYellowFlag = new ESRM.Win.ESRMButton();
            this.btnGreenFlag = new ESRM.Win.ESRMButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnGP = new ESRM.Win.ESRMButton();
            this.btnRedo = new ESRM.Win.ESRMButton();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.pbFlag = new DevExpress.XtraEditors.PictureEdit();
            this.btnReaffectGamePads = new ESRM.Win.ESRMButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSTOP
            // 
            this.btnSTOP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSTOP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnSTOP, "btnSTOP");
            this.btnSTOP.ForeColor = System.Drawing.Color.White;
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.UseCompatibleTextRendering = true;
            this.btnSTOP.UseVisualStyleBackColor = false;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseCompatibleTextRendering = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStartPause
            // 
            this.btnStartPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnStartPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnStartPause, "btnStartPause");
            this.btnStartPause.ForeColor = System.Drawing.Color.White;
            this.btnStartPause.Name = "btnStartPause";
            this.btnStartPause.UseCompatibleTextRendering = true;
            this.btnStartPause.UseVisualStyleBackColor = false;
            this.btnStartPause.Click += new System.EventHandler(this.btnStartPause_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TeamsPanel
            // 
            resources.ApplyResources(this.TeamsPanel, "TeamsPanel");
            this.TeamsPanel.Name = "TeamsPanel";
            // 
            // btnYellowFlag
            // 
            this.btnYellowFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnYellowFlag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnYellowFlag, "btnYellowFlag");
            this.btnYellowFlag.ForeColor = System.Drawing.Color.White;
            this.btnYellowFlag.Name = "btnYellowFlag";
            this.btnYellowFlag.UseCompatibleTextRendering = true;
            this.btnYellowFlag.UseVisualStyleBackColor = false;
            this.btnYellowFlag.Click += new System.EventHandler(this.btnYellowFlag_Click);
            // 
            // btnGreenFlag
            // 
            this.btnGreenFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnGreenFlag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnGreenFlag, "btnGreenFlag");
            this.btnGreenFlag.ForeColor = System.Drawing.Color.White;
            this.btnGreenFlag.Name = "btnGreenFlag";
            this.btnGreenFlag.UseCompatibleTextRendering = true;
            this.btnGreenFlag.UseVisualStyleBackColor = false;
            this.btnGreenFlag.Click += new System.EventHandler(this.btnGreenFlag_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl1.Appearance.BackColor")));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnStartPause);
            this.panelControl1.Controls.Add(this.btnSTOP);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl2.Appearance.BackColor")));
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnGreenFlag);
            this.panelControl2.Controls.Add(this.btnYellowFlag);
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Name = "panelControl2";
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl3.Appearance.BackColor")));
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.btnReaffectGamePads);
            this.panelControl3.Controls.Add(this.btnGP);
            this.panelControl3.Controls.Add(this.btnRedo);
            resources.ApplyResources(this.panelControl3, "panelControl3");
            this.panelControl3.Name = "panelControl3";
            // 
            // btnGP
            // 
            this.btnGP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnGP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnGP, "btnGP");
            this.btnGP.ForeColor = System.Drawing.Color.White;
            this.btnGP.Name = "btnGP";
            this.btnGP.UseCompatibleTextRendering = true;
            this.btnGP.UseVisualStyleBackColor = false;
            // 
            // btnRedo
            // 
            this.btnRedo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnRedo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnRedo, "btnRedo");
            this.btnRedo.ForeColor = System.Drawing.Color.White;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.UseCompatibleTextRendering = true;
            this.btnRedo.UseVisualStyleBackColor = false;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.panelControl3);
            this.panelButtons.Controls.Add(this.panelControl2);
            this.panelButtons.Controls.Add(this.panelControl1);
            this.panelButtons.Controls.Add(this.pbFlag);
            this.panelButtons.Controls.Add(this.btnClose);
            resources.ApplyResources(this.panelButtons, "panelButtons");
            this.panelButtons.Name = "panelButtons";
            // 
            // pbFlag
            // 
            resources.ApplyResources(this.pbFlag, "pbFlag");
            this.pbFlag.EditValue = global::ESRM.Win.Images.RedFlag;
            this.pbFlag.Name = "pbFlag";
            this.pbFlag.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pbFlag.Properties.Appearance.BackColor")));
            this.pbFlag.Properties.Appearance.Options.UseBackColor = true;
            this.pbFlag.Properties.Appearance.Options.UseFont = true;
            this.pbFlag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pbFlag.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pbFlag.Properties.ZoomAccelerationFactor = 1D;
            // 
            // btnReaffectGamePads
            // 
            this.btnReaffectGamePads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnReaffectGamePads.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnReaffectGamePads, "btnReaffectGamePads");
            this.btnReaffectGamePads.ForeColor = System.Drawing.Color.White;
            this.btnReaffectGamePads.Name = "btnReaffectGamePads";
            this.btnReaffectGamePads.UseCompatibleTextRendering = true;
            this.btnReaffectGamePads.UseVisualStyleBackColor = false;
            this.btnReaffectGamePads.Click += new System.EventHandler(this.btnReaffectGamePads_Click);
            // 
            // MonitoringDlg
            // 
            this.AcceptButton = this.btnSTOP;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnClose;
            this.Controls.Add(this.TeamsPanel);
            this.Controls.Add(this.panelButtons);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MonitoringDlg";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ESRMButton btnSTOP;
        private ESRMButton btnClose;
        private ESRMButton btnStartPause;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel TeamsPanel;
        private ESRMButton btnYellowFlag;
        private ESRMButton btnGreenFlag;
        private DevExpress.XtraEditors.PictureEdit pbFlag;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private ESRMButton btnGP;
        private ESRMButton btnRedo;
        private System.Windows.Forms.Panel panelButtons;
        private ESRMButton btnReaffectGamePads;
    }
}