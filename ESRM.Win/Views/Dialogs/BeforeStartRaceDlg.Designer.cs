namespace ESRM.Win
{
    partial class BeforeStartRaceDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeforeStartRaceDlg));
            this.lblConsign = new System.Windows.Forms.Label();
            this.btnNotShowAgain = new ESRM.Win.ESRMButton();
            this.btnOk = new ESRM.Win.ESRMButton();
            this.SuspendLayout();
            // 
            // lblConsign
            // 
            resources.ApplyResources(this.lblConsign, "lblConsign");
            this.lblConsign.Name = "lblConsign";
            // 
            // btnNotShowAgain
            // 
            resources.ApplyResources(this.btnNotShowAgain, "btnNotShowAgain");
            this.btnNotShowAgain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnNotShowAgain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnNotShowAgain.ForeColor = System.Drawing.Color.White;
            this.btnNotShowAgain.Name = "btnNotShowAgain";
            this.btnNotShowAgain.UseCompatibleTextRendering = true;
            this.btnNotShowAgain.UseVisualStyleBackColor = false;
            this.btnNotShowAgain.Click += new System.EventHandler(this.btnNotShowAgain_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseCompatibleTextRendering = true;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // BeforeStartRaceDlg
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnNotShowAgain);
            this.Controls.Add(this.lblConsign);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BeforeStartRaceDlg";
            this.Opacity = 0.9D;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblConsign;
        private ESRMButton btnNotShowAgain;
        private ESRMButton btnOk;
    }
}