namespace ESRM.Win
{
    partial class SecondRaceView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondRaceView));
            this.racePage2 = new ESRM.Win.Views.RacePage();
            this.endracePage = new ESRM.Win.Views.EndRacePage();
            this.SuspendLayout();
            // 
            // racePage2
            // 
            //resources.ApplyResources(this.racePage2, "racePage2");
            this.racePage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.racePage2.BackColor = System.Drawing.Color.Transparent;
            this.racePage2.Name = "racePage2";
            // 
            // endracePage
            // 
            this.endracePage.BackColor = System.Drawing.Color.Transparent;
            //resources.ApplyResources(this.endracePage, "endracePage");
            this.endracePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endracePage.Name = "endracePage";
            // 
            // SecondRaceView
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.racePage2);
            this.Controls.Add(this.endracePage);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "SecondRaceView";
            this.ResumeLayout(false);

        }

        #endregion
        private Views.RacePage racePage2;
        private Views.EndRacePage endracePage;
    }
}