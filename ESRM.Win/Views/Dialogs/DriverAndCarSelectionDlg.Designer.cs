namespace ESRM.Win
{
    partial class DriverAndCarSelectionDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverAndCarSelectionDlg));
            this.driverAndCarSelectionPage = new ESRM.Win.Views.DriverAndCarSelectionPage();
            this.SuspendLayout();
            // 
            // driverAndCarSelectionPage1
            // 
            resources.ApplyResources(this.driverAndCarSelectionPage, "driverAndCarSelectionPage1");
            this.driverAndCarSelectionPage.Name = "driverAndCarSelectionPage1";
            // 
            // DriverAndCarSelectionDlg
            // 
            this.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(driverAndCarSelectionPage);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "DriverAndCarSelectionDlg";
            this.ResumeLayout(false);

        }

        #endregion
        private Views.DriverAndCarSelectionPage driverAndCarSelectionPage;
    }
}