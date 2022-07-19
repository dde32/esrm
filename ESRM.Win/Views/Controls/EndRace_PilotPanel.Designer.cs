using DevExpress.XtraEditors;

namespace ESRM.Win.Panels
{
    partial class EndRace_PilotPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndRace_PilotPanel));
            this.stateImages = new System.Windows.Forms.ImageList(this.components);
            this.incidentImages = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new ESRM.Win.ScalablePanel();
            this.lblTimeAttackResult = new System.Windows.Forms.Label();
            this.lblTrackCall = new System.Windows.Forms.Label();
            this.lblIncidents = new System.Windows.Forms.Label();
            this.lblAverage = new System.Windows.Forms.Label();
            this.lblBestLap = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.lblPitStops = new System.Windows.Forms.Label();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // stateImages
            // 
            this.stateImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateImages.ImageStream")));
            this.stateImages.TransparentColor = System.Drawing.Color.Transparent;
            this.stateImages.Images.SetKeyName(0, "empty.png");
            this.stateImages.Images.SetKeyName(1, "empty.png");
            this.stateImages.Images.SetKeyName(2, "empty.png");
            this.stateImages.Images.SetKeyName(3, "empty.png");
            this.stateImages.Images.SetKeyName(4, "empty.png");
            this.stateImages.Images.SetKeyName(5, "empty.png");
            this.stateImages.Images.SetKeyName(6, "empty.png");
            this.stateImages.Images.SetKeyName(7, "empty.png");
            this.stateImages.Images.SetKeyName(8, "empty.png");
            // 
            // incidentImages
            // 
            this.incidentImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            resources.ApplyResources(this.incidentImages, "incidentImages");
            this.incidentImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panel2.Appearance.BackColor")));
            this.panel2.Appearance.Options.UseBackColor = true;
            this.panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel2.Controls.Add(this.lblTimeAttackResult);
            this.panel2.Controls.Add(this.lblTrackCall);
            this.panel2.Controls.Add(this.lblIncidents);
            this.panel2.Controls.Add(this.lblAverage);
            this.panel2.Controls.Add(this.lblBestLap);
            this.panel2.Controls.Add(this.lblTotalTime);
            this.panel2.Controls.Add(this.lblPitStops);
            this.panel2.Controls.Add(this.lblTeam);
            this.panel2.Controls.Add(this.lblPosition);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // lblTimeAttackResult
            // 
            this.lblTimeAttackResult.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblTimeAttackResult, "lblTimeAttackResult");
            this.lblTimeAttackResult.ForeColor = System.Drawing.Color.YellowGreen;
            this.lblTimeAttackResult.Name = "lblTimeAttackResult";
            // 
            // lblTrackCall
            // 
            this.lblTrackCall.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblTrackCall, "lblTrackCall");
            this.lblTrackCall.ForeColor = System.Drawing.Color.Orange;
            this.lblTrackCall.Name = "lblTrackCall";
            // 
            // lblIncidents
            // 
            this.lblIncidents.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblIncidents, "lblIncidents");
            this.lblIncidents.ForeColor = System.Drawing.Color.Orange;
            this.lblIncidents.Name = "lblIncidents";
            // 
            // lblAverage
            // 
            this.lblAverage.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblAverage, "lblAverage");
            this.lblAverage.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblAverage.Name = "lblAverage";
            // 
            // lblBestLap
            // 
            this.lblBestLap.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblBestLap, "lblBestLap");
            this.lblBestLap.ForeColor = System.Drawing.Color.White;
            this.lblBestLap.Name = "lblBestLap";
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblTotalTime, "lblTotalTime");
            this.lblTotalTime.ForeColor = System.Drawing.Color.White;
            this.lblTotalTime.Name = "lblTotalTime";
            // 
            // lblPitStops
            // 
            this.lblPitStops.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblPitStops, "lblPitStops");
            this.lblPitStops.ForeColor = System.Drawing.Color.White;
            this.lblPitStops.Name = "lblPitStops";
            // 
            // lblTeam
            // 
            this.lblTeam.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblTeam, "lblTeam");
            this.lblTeam.ForeColor = System.Drawing.Color.White;
            this.lblTeam.Name = "lblTeam";
            // 
            // lblPosition
            // 
            this.lblPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.Name = "lblPosition";
            // 
            // EndRace_PilotPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(this.panel2);
            resources.ApplyResources(this, "$this");
            this.Name = "EndRace_PilotPanel";
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList stateImages;
        private System.Windows.Forms.ImageList incidentImages;
        private System.Windows.Forms.Label lblPitStops;
        private System.Windows.Forms.Label lblBestLap;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.Label lblTimeAttackResult;
        private System.Windows.Forms.Label lblIncidents;
        private System.Windows.Forms.Label lblTrackCall;
        private ScalablePanel panel2;
    }
}
