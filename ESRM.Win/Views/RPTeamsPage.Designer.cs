using DevExpress.XtraEditors;
using ESRM.Win.Panels;

namespace ESRM.Win
{
    partial class RPTeamsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPTeamsPage));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.teamsPanel = new DevExpress.XtraEditors.PanelControl();
            this.panelSeparation = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearchGamePads = new ESRM.Win.ESRMButton();
            this.btnAddTeam = new ESRM.Win.ESRMButton();
            this.paramTeamPanel1 = new ESRM.Win.Panels.ParamTeamPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamsPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSeparation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("splitContainerControl1.Appearance.BackColor")));
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.splitContainerControl1, "splitContainerControl1");
            this.splitContainerControl1.FireScrollEventOnMouseWheel = true;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.IsSplitterFixed = true;
            this.splitContainerControl1.Name = "splitContainerControl1";
            resources.ApplyResources(this.splitContainerControl1.Panel1, "splitContainerControl1.Panel1");
            this.splitContainerControl1.Panel1.Controls.Add(this.teamsPanel);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelSeparation);
            this.splitContainerControl1.Panel1.Controls.Add(this.panel1);
            resources.ApplyResources(this.splitContainerControl1.Panel2, "splitContainerControl1.Panel2");
            this.splitContainerControl1.Panel2.Controls.Add(this.paramTeamPanel1);
            this.splitContainerControl1.SplitterPosition = 700;
            // 
            // teamsPanel
            // 
            this.teamsPanel.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("teamsPanel.Appearance.BackColor")));
            this.teamsPanel.Appearance.Options.UseBackColor = true;
            this.teamsPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.teamsPanel, "teamsPanel");
            this.teamsPanel.Name = "teamsPanel";
            this.teamsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.teamsPanel_Paint);
            // 
            // panelSeparation
            // 
            this.panelSeparation.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelSeparation.Appearance.BackColor")));
            this.panelSeparation.Appearance.Options.UseBackColor = true;
            this.panelSeparation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(this.panelSeparation, "panelSeparation");
            this.panelSeparation.Name = "panelSeparation";
            // 
            // panel1
            // 
            this.panel1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panel1.Appearance.BackColor")));
            this.panel1.Appearance.Options.UseBackColor = true;
            this.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel1.Controls.Add(this.btnSearchGamePads);
            this.panel1.Controls.Add(this.btnAddTeam);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnSearchGamePads
            // 
            this.btnSearchGamePads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnSearchGamePads, "btnSearchGamePads");
            this.btnSearchGamePads.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSearchGamePads.ForeColor = System.Drawing.Color.White;
            this.btnSearchGamePads.Name = "btnSearchGamePads";
            this.btnSearchGamePads.UseCompatibleTextRendering = true;
            this.btnSearchGamePads.UseVisualStyleBackColor = false;
            this.btnSearchGamePads.Click += new System.EventHandler(this.btnSearchGamePads_Click);
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnAddTeam, "btnAddTeam");
            this.btnAddTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnAddTeam.ForeColor = System.Drawing.Color.White;
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.UseCompatibleTextRendering = true;
            this.btnAddTeam.UseVisualStyleBackColor = false;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // paramTeamPanel1
            // 
            resources.ApplyResources(this.paramTeamPanel1, "paramTeamPanel1");
            this.paramTeamPanel1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.paramTeamPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.paramTeamPanel1.ForeColor = System.Drawing.Color.White;
            this.paramTeamPanel1.Name = "paramTeamPanel1";
            // 
            // RPTeamsPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = global::ESRM.Win.Images.background;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panel2);
            this.Name = "RPTeamsPage";
            this.SizeChanged += new System.EventHandler(this.RPTeamsPage_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teamsPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSeparation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelControl panel1;
        private PanelControl teamsPanel;
        private ESRMButton btnAddTeam;
        private PanelControl panelSeparation;
        private ParamTeamPanel paramTeamPanel1;
        private SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.Panel panel2;
        private ESRMButton btnSearchGamePads;
    }
}
