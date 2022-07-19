namespace ESRM.Win.Views
{
    partial class TimeAttackRaceParamsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeAttackRaceParamsPage));
            this.btnTrackSelect = new ESRM.Win.ESRMButton();
            this.btnGoRacing = new ESRM.Win.ESRMButton();
            this.btnTeams = new ESRM.Win.ESRMButtonSelect();
            this.btnPilotPerTeams = new ESRM.Win.ESRMButtonSelect();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBonusPlus = new ESRM.Win.ESRMButton();
            this.btnBonusMoins = new ESRM.Win.ESRMButton();
            this.edtBonus = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTargetPlus = new ESRM.Win.ESRMButton();
            this.btnTargetMoins = new ESRM.Win.ESRMButton();
            this.edtLapTarget = new System.Windows.Forms.MaskedTextBox();
            this.btnTrack = new ESRM.Win.ESRMButtonSelect();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTrackSelect
            // 
            this.btnTrackSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnTrackSelect, "btnTrackSelect");
            this.btnTrackSelect.ForeColor = System.Drawing.Color.White;
            this.btnTrackSelect.Name = "btnTrackSelect";
            this.btnTrackSelect.UseCompatibleTextRendering = true;
            this.btnTrackSelect.UseVisualStyleBackColor = false;
            // 
            // btnGoRacing
            // 
            resources.ApplyResources(this.btnGoRacing, "btnGoRacing");
            this.btnGoRacing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnGoRacing.ForeColor = System.Drawing.Color.White;
            this.btnGoRacing.Name = "btnGoRacing";
            this.btnGoRacing.UseCompatibleTextRendering = true;
            this.btnGoRacing.UseVisualStyleBackColor = true;
            this.btnGoRacing.Click += new System.EventHandler(this.btnGoRacing_Click);
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
            this.btnTeams.SubTextForeColor = System.Drawing.Color.LightSkyBlue;
            this.btnTeams.TextBoxHint = "";
            this.btnTeams.TextFont = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeams.Click += new System.EventHandler(this.btnTeams_Click);
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
            this.btnPilotPerTeams.SubTextForeColor = System.Drawing.Color.LightSkyBlue;
            this.btnPilotPerTeams.TextBoxHint = "";
            this.btnPilotPerTeams.TextFont = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPilotPerTeams.Click += new System.EventHandler(this.btnPilotPerTeams_Click);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.label2);
            this.panelPrincipal.Controls.Add(this.btnBonusPlus);
            this.panelPrincipal.Controls.Add(this.btnBonusMoins);
            this.panelPrincipal.Controls.Add(this.edtBonus);
            this.panelPrincipal.Controls.Add(this.label1);
            this.panelPrincipal.Controls.Add(this.btnTargetPlus);
            this.panelPrincipal.Controls.Add(this.btnTargetMoins);
            this.panelPrincipal.Controls.Add(this.edtLapTarget);
            this.panelPrincipal.Controls.Add(this.btnGoRacing);
            this.panelPrincipal.Controls.Add(this.btnTrack);
            this.panelPrincipal.Controls.Add(this.btnPilotPerTeams);
            this.panelPrincipal.Controls.Add(this.btnTeams);
            resources.ApplyResources(this.panelPrincipal, "panelPrincipal");
            this.panelPrincipal.Name = "panelPrincipal";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // btnBonusPlus
            // 
            resources.ApplyResources(this.btnBonusPlus, "btnBonusPlus");
            this.btnBonusPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnBonusPlus.ForeColor = System.Drawing.Color.White;
            this.btnBonusPlus.Name = "btnBonusPlus";
            this.btnBonusPlus.UseCompatibleTextRendering = true;
            this.btnBonusPlus.UseVisualStyleBackColor = true;
            this.btnBonusPlus.Click += new System.EventHandler(this.btnBonusPlus_Click);
            // 
            // btnBonusMoins
            // 
            resources.ApplyResources(this.btnBonusMoins, "btnBonusMoins");
            this.btnBonusMoins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnBonusMoins.ForeColor = System.Drawing.Color.White;
            this.btnBonusMoins.Name = "btnBonusMoins";
            this.btnBonusMoins.UseCompatibleTextRendering = true;
            this.btnBonusMoins.UseVisualStyleBackColor = true;
            this.btnBonusMoins.Click += new System.EventHandler(this.btnBonusMoins_Click);
            // 
            // edtBonus
            // 
            resources.ApplyResources(this.edtBonus, "edtBonus");
            this.edtBonus.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.edtBonus.Name = "edtBonus";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // btnTargetPlus
            // 
            resources.ApplyResources(this.btnTargetPlus, "btnTargetPlus");
            this.btnTargetPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTargetPlus.ForeColor = System.Drawing.Color.White;
            this.btnTargetPlus.Name = "btnTargetPlus";
            this.btnTargetPlus.UseCompatibleTextRendering = true;
            this.btnTargetPlus.UseVisualStyleBackColor = true;
            this.btnTargetPlus.Click += new System.EventHandler(this.btnTargetPlus_Click);
            // 
            // btnTargetMoins
            // 
            resources.ApplyResources(this.btnTargetMoins, "btnTargetMoins");
            this.btnTargetMoins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTargetMoins.ForeColor = System.Drawing.Color.White;
            this.btnTargetMoins.Name = "btnTargetMoins";
            this.btnTargetMoins.UseCompatibleTextRendering = true;
            this.btnTargetMoins.UseVisualStyleBackColor = true;
            this.btnTargetMoins.Click += new System.EventHandler(this.btnTargetMoins_Click);
            // 
            // edtLapTarget
            // 
            resources.ApplyResources(this.edtLapTarget, "edtLapTarget");
            this.edtLapTarget.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.edtLapTarget.Name = "edtLapTarget";
            // 
            // btnTrack
            // 
            resources.ApplyResources(this.btnTrack, "btnTrack");
            this.btnTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnTrack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnTrack.ForeColor = System.Drawing.Color.White;
            this.btnTrack.Name = "btnTrack";
            this.btnTrack.ShowSecondText = true;
            this.btnTrack.SubTextFont = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrack.SubTextForeColor = System.Drawing.Color.LightSkyBlue;
            this.btnTrack.TextBoxHint = "";
            this.btnTrack.TextFont = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrack.Click += new System.EventHandler(this.btnTrackSelect_Click);
            // 
            // TimeAttackRaceParamsPage
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.btnTrackSelect);
            this.Name = "TimeAttackRaceParamsPage";
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRMButton btnTrackSelect;
        private ESRMButton btnGoRacing;
        private ESRMButtonSelect btnTeams;
        private ESRMButtonSelect btnPilotPerTeams;
        private System.Windows.Forms.Panel panelPrincipal;
        private ESRMButtonSelect btnTrack;
        private System.Windows.Forms.MaskedTextBox edtLapTarget;
        private ESRMButton btnTargetPlus;
        private ESRMButton btnTargetMoins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ESRMButton btnBonusPlus;
        private ESRMButton btnBonusMoins;
        private System.Windows.Forms.MaskedTextBox edtBonus;
    }
}
