using DevExpress.XtraEditors;
namespace ESRM.Win.Panels
{
    partial class SmallParamTeamPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmallParamTeamPanel));
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.panelPilotes = new DevExpress.XtraEditors.PanelControl();
            this.panelP2Name = new DevExpress.XtraEditors.PanelControl();
            this.lblTeamId = new System.Windows.Forms.Label();
            this.btnDownId = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpId = new DevExpress.XtraEditors.SimpleButton();
            this.lblId = new System.Windows.Forms.Label();
            this.lblPos = new System.Windows.Forms.Label();
            this.btnPosPlus = new DevExpress.XtraEditors.SimpleButton();
            this.btnPosMoins = new DevExpress.XtraEditors.SimpleButton();
            this.lblTeamPos = new System.Windows.Forms.Label();
            this.panelP1Name = new DevExpress.XtraEditors.PanelControl();
            this.lblPilot1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTeam = new System.Windows.Forms.Label();
            this.panelTitle = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelPilotes)).BeginInit();
            this.panelPilotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelP2Name)).BeginInit();
            this.panelP2Name.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelP1Name)).BeginInit();
            this.panelP1Name.SuspendLayout();
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
            resources.ApplyResources(this.panelPilotes, "panelPilotes");
            this.panelPilotes.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelPilotes.Appearance.BackColor")));
            this.panelPilotes.Appearance.FontSizeDelta = ((int)(resources.GetObject("panelPilotes.Appearance.FontSizeDelta")));
            this.panelPilotes.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("panelPilotes.Appearance.FontStyleDelta")));
            this.panelPilotes.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("panelPilotes.Appearance.GradientMode")));
            this.panelPilotes.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("panelPilotes.Appearance.Image")));
            this.panelPilotes.Appearance.Options.UseBackColor = true;
            this.panelPilotes.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelPilotes.Controls.Add(this.panelP2Name);
            this.panelPilotes.Controls.Add(this.panelP1Name);
            this.panelPilotes.Name = "panelPilotes";
            this.panelPilotes.Click += new System.EventHandler(this.SmallParamTeamPanel_Click);
            // 
            // panelP2Name
            // 
            resources.ApplyResources(this.panelP2Name, "panelP2Name");
            this.panelP2Name.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelP2Name.Appearance.BackColor")));
            this.panelP2Name.Appearance.FontSizeDelta = ((int)(resources.GetObject("panelP2Name.Appearance.FontSizeDelta")));
            this.panelP2Name.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("panelP2Name.Appearance.FontStyleDelta")));
            this.panelP2Name.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("panelP2Name.Appearance.ForeColor")));
            this.panelP2Name.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("panelP2Name.Appearance.GradientMode")));
            this.panelP2Name.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("panelP2Name.Appearance.Image")));
            this.panelP2Name.Appearance.Options.UseBackColor = true;
            this.panelP2Name.Appearance.Options.UseForeColor = true;
            this.panelP2Name.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelP2Name.Controls.Add(this.lblTeamId);
            this.panelP2Name.Controls.Add(this.btnDownId);
            this.panelP2Name.Controls.Add(this.btnUpId);
            this.panelP2Name.Controls.Add(this.lblId);
            this.panelP2Name.Controls.Add(this.lblPos);
            this.panelP2Name.Controls.Add(this.btnPosPlus);
            this.panelP2Name.Controls.Add(this.btnPosMoins);
            this.panelP2Name.Controls.Add(this.lblTeamPos);
            this.panelP2Name.Name = "panelP2Name";
            this.panelP2Name.Click += new System.EventHandler(this.panelP2Name_Click);
            // 
            // lblTeamId
            // 
            resources.ApplyResources(this.lblTeamId, "lblTeamId");
            this.lblTeamId.BackColor = System.Drawing.Color.Transparent;
            this.lblTeamId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTeamId.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTeamId.Name = "lblTeamId";
            // 
            // btnDownId
            // 
            resources.ApplyResources(this.btnDownId, "btnDownId");
            this.btnDownId.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("btnDownId.Appearance.BackColor")));
            this.btnDownId.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnDownId.Appearance.Font")));
            this.btnDownId.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnDownId.Appearance.FontSizeDelta")));
            this.btnDownId.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnDownId.Appearance.FontStyleDelta")));
            this.btnDownId.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnDownId.Appearance.ForeColor")));
            this.btnDownId.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnDownId.Appearance.GradientMode")));
            this.btnDownId.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnDownId.Appearance.Image")));
            this.btnDownId.Appearance.Options.UseBackColor = true;
            this.btnDownId.Appearance.Options.UseFont = true;
            this.btnDownId.Appearance.Options.UseForeColor = true;
            this.btnDownId.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnDownId.Name = "btnDownId";
            this.btnDownId.Click += new System.EventHandler(this.btnDownId_Click);
            // 
            // btnUpId
            // 
            resources.ApplyResources(this.btnUpId, "btnUpId");
            this.btnUpId.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("btnUpId.Appearance.BackColor")));
            this.btnUpId.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnUpId.Appearance.Font")));
            this.btnUpId.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnUpId.Appearance.FontSizeDelta")));
            this.btnUpId.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnUpId.Appearance.FontStyleDelta")));
            this.btnUpId.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnUpId.Appearance.ForeColor")));
            this.btnUpId.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnUpId.Appearance.GradientMode")));
            this.btnUpId.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnUpId.Appearance.Image")));
            this.btnUpId.Appearance.Options.UseBackColor = true;
            this.btnUpId.Appearance.Options.UseFont = true;
            this.btnUpId.Appearance.Options.UseForeColor = true;
            this.btnUpId.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnUpId.Name = "btnUpId";
            this.btnUpId.Click += new System.EventHandler(this.btnUpId_Click);
            // 
            // lblId
            // 
            resources.ApplyResources(this.lblId, "lblId");
            this.lblId.BackColor = System.Drawing.Color.Transparent;
            this.lblId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblId.ForeColor = System.Drawing.Color.DarkGray;
            this.lblId.Name = "lblId";
            // 
            // lblPos
            // 
            resources.ApplyResources(this.lblPos, "lblPos");
            this.lblPos.BackColor = System.Drawing.Color.Transparent;
            this.lblPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPos.ForeColor = System.Drawing.Color.DarkGray;
            this.lblPos.Name = "lblPos";
            // 
            // btnPosPlus
            // 
            resources.ApplyResources(this.btnPosPlus, "btnPosPlus");
            this.btnPosPlus.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("btnPosPlus.Appearance.BackColor")));
            this.btnPosPlus.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnPosPlus.Appearance.Font")));
            this.btnPosPlus.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnPosPlus.Appearance.FontSizeDelta")));
            this.btnPosPlus.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnPosPlus.Appearance.FontStyleDelta")));
            this.btnPosPlus.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnPosPlus.Appearance.ForeColor")));
            this.btnPosPlus.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnPosPlus.Appearance.GradientMode")));
            this.btnPosPlus.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnPosPlus.Appearance.Image")));
            this.btnPosPlus.Appearance.Options.UseBackColor = true;
            this.btnPosPlus.Appearance.Options.UseFont = true;
            this.btnPosPlus.Appearance.Options.UseForeColor = true;
            this.btnPosPlus.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPosPlus.Name = "btnPosPlus";
            this.btnPosPlus.Click += new System.EventHandler(this.btnPosPlus_Click);
            // 
            // btnPosMoins
            // 
            resources.ApplyResources(this.btnPosMoins, "btnPosMoins");
            this.btnPosMoins.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("btnPosMoins.Appearance.BackColor")));
            this.btnPosMoins.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnPosMoins.Appearance.Font")));
            this.btnPosMoins.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnPosMoins.Appearance.FontSizeDelta")));
            this.btnPosMoins.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnPosMoins.Appearance.FontStyleDelta")));
            this.btnPosMoins.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnPosMoins.Appearance.ForeColor")));
            this.btnPosMoins.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnPosMoins.Appearance.GradientMode")));
            this.btnPosMoins.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnPosMoins.Appearance.Image")));
            this.btnPosMoins.Appearance.Options.UseBackColor = true;
            this.btnPosMoins.Appearance.Options.UseFont = true;
            this.btnPosMoins.Appearance.Options.UseForeColor = true;
            this.btnPosMoins.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnPosMoins.Name = "btnPosMoins";
            this.btnPosMoins.Click += new System.EventHandler(this.btnPosMoins_Click);
            // 
            // lblTeamPos
            // 
            resources.ApplyResources(this.lblTeamPos, "lblTeamPos");
            this.lblTeamPos.BackColor = System.Drawing.Color.Transparent;
            this.lblTeamPos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTeamPos.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTeamPos.Name = "lblTeamPos";
            // 
            // panelP1Name
            // 
            resources.ApplyResources(this.panelP1Name, "panelP1Name");
            this.panelP1Name.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelP1Name.Appearance.BackColor")));
            this.panelP1Name.Appearance.FontSizeDelta = ((int)(resources.GetObject("panelP1Name.Appearance.FontSizeDelta")));
            this.panelP1Name.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("panelP1Name.Appearance.FontStyleDelta")));
            this.panelP1Name.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("panelP1Name.Appearance.ForeColor")));
            this.panelP1Name.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("panelP1Name.Appearance.GradientMode")));
            this.panelP1Name.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("panelP1Name.Appearance.Image")));
            this.panelP1Name.Appearance.Options.UseBackColor = true;
            this.panelP1Name.Appearance.Options.UseForeColor = true;
            this.panelP1Name.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelP1Name.Controls.Add(this.lblPilot1);
            this.panelP1Name.Controls.Add(this.label1);
            this.panelP1Name.Name = "panelP1Name";
            this.panelP1Name.Click += new System.EventHandler(this.panelP1Name_Click);
            // 
            // lblPilot1
            // 
            resources.ApplyResources(this.lblPilot1, "lblPilot1");
            this.lblPilot1.BackColor = System.Drawing.Color.Transparent;
            this.lblPilot1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPilot1.Name = "lblPilot1";
            this.lblPilot1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblTeam
            // 
            resources.ApplyResources(this.lblTeam, "lblTeam");
            this.lblTeam.BackColor = System.Drawing.Color.Transparent;
            this.lblTeam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTeam.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Click += new System.EventHandler(this.lblTeam_Click);
            // 
            // panelTitle
            // 
            resources.ApplyResources(this.panelTitle, "panelTitle");
            this.panelTitle.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelTitle.Appearance.BackColor")));
            this.panelTitle.Appearance.FontSizeDelta = ((int)(resources.GetObject("panelTitle.Appearance.FontSizeDelta")));
            this.panelTitle.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("panelTitle.Appearance.FontStyleDelta")));
            this.panelTitle.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("panelTitle.Appearance.ForeColor")));
            this.panelTitle.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("panelTitle.Appearance.GradientMode")));
            this.panelTitle.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("panelTitle.Appearance.Image")));
            this.panelTitle.Appearance.Options.UseBackColor = true;
            this.panelTitle.Appearance.Options.UseForeColor = true;
            this.panelTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelTitle.Controls.Add(this.lblTeam);
            this.panelTitle.Controls.Add(this.btnDelete2);
            this.panelTitle.Name = "panelTitle";
            // 
            // btnDelete2
            // 
            resources.ApplyResources(this.btnDelete2, "btnDelete2");
            this.btnDelete2.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("btnDelete2.Appearance.BackColor")));
            this.btnDelete2.Appearance.FontSizeDelta = ((int)(resources.GetObject("btnDelete2.Appearance.FontSizeDelta")));
            this.btnDelete2.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnDelete2.Appearance.FontStyleDelta")));
            this.btnDelete2.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnDelete2.Appearance.GradientMode")));
            this.btnDelete2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete2.Appearance.Image")));
            this.btnDelete2.Appearance.Options.UseBackColor = true;
            this.btnDelete2.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete2.Image")));
            this.btnDelete2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnDelete2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // SmallParamTeamPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.panelPilotes);
            this.Controls.Add(this.panelTitle);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "SmallParamTeamPanel";
            this.Click += new System.EventHandler(this.SmallParamTeamPanel_Click);
            ((System.ComponentModel.ISupportInitialize)(this.panelPilotes)).EndInit();
            this.panelPilotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelP2Name)).EndInit();
            this.panelP2Name.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelP1Name)).EndInit();
            this.panelP1Name.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelTitle)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Label lblPilot1;
        private PanelControl panelTitle;
        private DevExpress.XtraEditors.SimpleButton btnDelete2;
        public System.Windows.Forms.ColorDialog colorDialog;
        private PanelControl panelP1Name;
        private PanelControl panelPilotes;
        private System.Windows.Forms.Label label1;
        private PanelControl panelP2Name;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label lblTeamPos;
        private SimpleButton btnPosPlus;
        private SimpleButton btnPosMoins;
        private SimpleButton btnDownId;
        private SimpleButton btnUpId;
        private System.Windows.Forms.Label lblTeamId;
        private System.Windows.Forms.Label lblId;
    }
}
