namespace ESRM.Win.Views
{
    partial class DriverAndCarSelectionPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverAndCarSelectionPage));
            this.btnDeleteAll = new ESRM.Win.ESRMButton();
            this.panelTeam = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.btnDeleteAll, "btnDeleteAll");
            this.btnDeleteAll.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.UseCompatibleTextRendering = true;
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // panelTeam
            // 
            this.panelTeam.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.panelTeam, "panelTeam");
            this.panelTeam.Name = "panelTeam";
            // 
            // DriverAndCarSelectionPage
            // 
            this.BackgroundImage = global::ESRM.Win.Images.background;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panelTeam);
            this.Controls.Add(this.btnDeleteAll);
            this.Name = "DriverAndCarSelectionPage";
            this.ResumeLayout(false);

        }

        #endregion

        private ESRMButton btnDeleteAll;
        private System.Windows.Forms.Panel panelTeam;
    }
}
