using DevExpress.XtraEditors;
namespace ESRM.Win.Panels
{
    partial class MonitoringTeamPanel1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitoringTeamPanel1));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.panelPilotes = new DevExpress.XtraEditors.PanelControl();
            this.btnApplyPenality = new ESRM.Win.ESRMButton();
            this.btnStopPenality = new ESRM.Win.ESRMButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.edtPacerVMax = new DevExpress.XtraEditors.SpinEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPacerOnOrOff = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.edtBrake = new DevExpress.XtraEditors.SpinEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panelP1Name = new DevExpress.XtraEditors.PanelControl();
            this.edtVMax = new DevExpress.XtraEditors.SpinEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lblTeamId = new System.Windows.Forms.Label();
            this.panelTitle = new DevExpress.XtraEditors.PanelControl();
            this.lblPos = new System.Windows.Forms.Label();
            this.lblTeamPos = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelPilotes)).BeginInit();
            this.panelPilotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPacerVMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBrake.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelP1Name)).BeginInit();
            this.panelP1Name.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.SolidColorOnly = true;
            // 
            // panelPilotes
            // 
            this.panelPilotes.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelPilotes.Appearance.BackColor")));
            this.panelPilotes.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.panelPilotes, "panelPilotes");
            this.panelPilotes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelPilotes.Controls.Add(this.btnApplyPenality);
            this.panelPilotes.Controls.Add(this.btnStopPenality);
            this.panelPilotes.Controls.Add(this.panelControl2);
            this.panelPilotes.Controls.Add(this.panelControl1);
            this.panelPilotes.Controls.Add(this.panelP1Name);
            this.panelPilotes.Name = "panelPilotes";
            // 
            // btnApplyPenality
            // 
            this.btnApplyPenality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnApplyPenality, "btnApplyPenality");
            this.btnApplyPenality.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnApplyPenality.ForeColor = System.Drawing.Color.White;
            this.btnApplyPenality.Name = "btnApplyPenality";
            this.btnApplyPenality.UseCompatibleTextRendering = true;
            this.btnApplyPenality.UseVisualStyleBackColor = false;
            this.btnApplyPenality.Click += new System.EventHandler(this.btnApplyPenality_Click);
            // 
            // btnStopPenality
            // 
            this.btnStopPenality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnStopPenality, "btnStopPenality");
            this.btnStopPenality.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnStopPenality.ForeColor = System.Drawing.Color.White;
            this.btnStopPenality.Name = "btnStopPenality";
            this.btnStopPenality.UseCompatibleTextRendering = true;
            this.btnStopPenality.UseVisualStyleBackColor = false;
            this.btnStopPenality.Click += new System.EventHandler(this.btnStopPenality_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl2.Appearance.BackColor")));
            this.panelControl2.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("panelControl2.Appearance.ForeColor")));
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Appearance.Options.UseForeColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.edtPacerVMax);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.lblPacerOnOrOff);
            this.panelControl2.Controls.Add(this.label3);
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Name = "panelControl2";
            // 
            // edtPacerVMax
            // 
            resources.ApplyResources(this.edtPacerVMax, "edtPacerVMax");
            this.edtPacerVMax.Name = "edtPacerVMax";
            this.edtPacerVMax.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("edtPacerVMax.Properties.Appearance.BackColor")));
            this.edtPacerVMax.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtPacerVMax.Properties.Appearance.Font")));
            this.edtPacerVMax.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("edtPacerVMax.Properties.Appearance.ForeColor")));
            this.edtPacerVMax.Properties.Appearance.Options.UseBackColor = true;
            this.edtPacerVMax.Properties.Appearance.Options.UseFont = true;
            this.edtPacerVMax.Properties.Appearance.Options.UseForeColor = true;
            this.edtPacerVMax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtPacerVMax.Properties.Buttons"))), resources.GetString("edtPacerVMax.Properties.Buttons1"), ((int)(resources.GetObject("edtPacerVMax.Properties.Buttons2"))), ((bool)(resources.GetObject("edtPacerVMax.Properties.Buttons3"))), ((bool)(resources.GetObject("edtPacerVMax.Properties.Buttons4"))), ((bool)(resources.GetObject("edtPacerVMax.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("edtPacerVMax.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("edtPacerVMax.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("edtPacerVMax.Properties.Buttons8"), ((object)(resources.GetObject("edtPacerVMax.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("edtPacerVMax.Properties.Buttons10"))), ((bool)(resources.GetObject("edtPacerVMax.Properties.Buttons11"))))});
            this.edtPacerVMax.EditValueChanged += new System.EventHandler(this.edtPacerVMax_EditValueChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lblPacerOnOrOff
            // 
            this.lblPacerOnOrOff.BackColor = System.Drawing.Color.Transparent;
            this.lblPacerOnOrOff.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblPacerOnOrOff, "lblPacerOnOrOff");
            this.lblPacerOnOrOff.ForeColor = System.Drawing.Color.Green;
            this.lblPacerOnOrOff.Name = "lblPacerOnOrOff";
            this.lblPacerOnOrOff.Click += new System.EventHandler(this.lblPacerOnOrOff_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl1.Appearance.BackColor")));
            this.panelControl1.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("panelControl1.Appearance.ForeColor")));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseForeColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.edtBrake);
            this.panelControl1.Controls.Add(this.label2);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // edtBrake
            // 
            resources.ApplyResources(this.edtBrake, "edtBrake");
            this.edtBrake.Name = "edtBrake";
            this.edtBrake.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("edtBrake.Properties.Appearance.BackColor")));
            this.edtBrake.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtBrake.Properties.Appearance.Font")));
            this.edtBrake.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("edtBrake.Properties.Appearance.ForeColor")));
            this.edtBrake.Properties.Appearance.Options.UseBackColor = true;
            this.edtBrake.Properties.Appearance.Options.UseFont = true;
            this.edtBrake.Properties.Appearance.Options.UseForeColor = true;
            this.edtBrake.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtBrake.Properties.Buttons"))), resources.GetString("edtBrake.Properties.Buttons1"), ((int)(resources.GetObject("edtBrake.Properties.Buttons2"))), ((bool)(resources.GetObject("edtBrake.Properties.Buttons3"))), ((bool)(resources.GetObject("edtBrake.Properties.Buttons4"))), ((bool)(resources.GetObject("edtBrake.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("edtBrake.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("edtBrake.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("edtBrake.Properties.Buttons8"), ((object)(resources.GetObject("edtBrake.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("edtBrake.Properties.Buttons10"))), ((bool)(resources.GetObject("edtBrake.Properties.Buttons11"))))});
            this.edtBrake.EditValueChanged += new System.EventHandler(this.edtBrake_EditValueChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panelP1Name
            // 
            this.panelP1Name.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelP1Name.Appearance.BackColor")));
            this.panelP1Name.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("panelP1Name.Appearance.ForeColor")));
            this.panelP1Name.Appearance.Options.UseBackColor = true;
            this.panelP1Name.Appearance.Options.UseForeColor = true;
            this.panelP1Name.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelP1Name.Controls.Add(this.edtVMax);
            this.panelP1Name.Controls.Add(this.label1);
            resources.ApplyResources(this.panelP1Name, "panelP1Name");
            this.panelP1Name.Name = "panelP1Name";
            // 
            // edtVMax
            // 
            resources.ApplyResources(this.edtVMax, "edtVMax");
            this.edtVMax.Name = "edtVMax";
            this.edtVMax.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("edtVMax.Properties.Appearance.BackColor")));
            this.edtVMax.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtVMax.Properties.Appearance.Font")));
            this.edtVMax.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("edtVMax.Properties.Appearance.ForeColor")));
            this.edtVMax.Properties.Appearance.Options.UseBackColor = true;
            this.edtVMax.Properties.Appearance.Options.UseFont = true;
            this.edtVMax.Properties.Appearance.Options.UseForeColor = true;
            this.edtVMax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtVMax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtVMax.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.edtVMax.EditValueChanged += new System.EventHandler(this.edtVMax_EditValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblTeam
            // 
            this.lblTeam.BackColor = System.Drawing.Color.Transparent;
            this.lblTeam.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblTeam, "lblTeam");
            this.lblTeam.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTeam.Name = "lblTeam";
            // 
            // lblTeamId
            // 
            this.lblTeamId.BackColor = System.Drawing.Color.Transparent;
            this.lblTeamId.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblTeamId, "lblTeamId");
            this.lblTeamId.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTeamId.Name = "lblTeamId";
            // 
            // panelTitle
            // 
            this.panelTitle.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelTitle.Appearance.BackColor")));
            this.panelTitle.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("panelTitle.Appearance.ForeColor")));
            this.panelTitle.Appearance.Options.UseBackColor = true;
            this.panelTitle.Appearance.Options.UseForeColor = true;
            this.panelTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTitle.Controls.Add(this.lblTeam);
            this.panelTitle.Controls.Add(this.lblPos);
            this.panelTitle.Controls.Add(this.lblTeamPos);
            this.panelTitle.Controls.Add(this.lblTeamId);
            this.panelTitle.Controls.Add(this.lblId);
            resources.ApplyResources(this.panelTitle, "panelTitle");
            this.panelTitle.Name = "panelTitle";
            // 
            // lblPos
            // 
            this.lblPos.BackColor = System.Drawing.Color.Transparent;
            this.lblPos.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblPos, "lblPos");
            this.lblPos.ForeColor = System.Drawing.Color.DarkGray;
            this.lblPos.Name = "lblPos";
            // 
            // lblTeamPos
            // 
            this.lblTeamPos.BackColor = System.Drawing.Color.Transparent;
            this.lblTeamPos.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblTeamPos, "lblTeamPos");
            this.lblTeamPos.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTeamPos.Name = "lblTeamPos";
            // 
            // lblId
            // 
            this.lblId.BackColor = System.Drawing.Color.Transparent;
            this.lblId.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblId, "lblId");
            this.lblId.ForeColor = System.Drawing.Color.DarkGray;
            this.lblId.Name = "lblId";
            // 
            // MonitoringTeamPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelPilotes);
            this.Controls.Add(this.panelTitle);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MonitoringTeamPanel";
            ((System.ComponentModel.ISupportInitialize)(this.panelPilotes)).EndInit();
            this.panelPilotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPacerVMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBrake.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelP1Name)).EndInit();
            this.panelP1Name.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtVMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Label lblTeamId;
        private PanelControl panelTitle;
        public System.Windows.Forms.ColorDialog colorDialog;
        private PanelControl panelP1Name;
        private PanelControl panelPilotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label lblTeamPos;
        private PanelControl panelControl1;
        private SpinEdit edtBrake;
        private System.Windows.Forms.Label label2;
        private SpinEdit edtVMax;
        private ESRMButton btnApplyPenality;
        private ESRMButton btnStopPenality;
        private PanelControl panelControl2;
        private SpinEdit edtPacerVMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPacerOnOrOff;
        private System.Windows.Forms.Label label3;
    }
}
