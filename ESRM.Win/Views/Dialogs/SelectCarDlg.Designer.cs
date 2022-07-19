namespace ESRM.Win
{
    partial class SelectCarDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCarDlg));
            this.panelSelect = new System.Windows.Forms.Panel();
            this.garagePage1 = new ESRM.Win.Views.GaragePage();
            this.panelNew = new System.Windows.Forms.Panel();
            this.edtItemName = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCancel = new ESRM.Win.ESRMButton();
            this.btnOk = new ESRM.Win.ESRMButton();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelSelect.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSelect
            // 
            this.panelSelect.Controls.Add(this.garagePage1);
            resources.ApplyResources(this.panelSelect, "panelSelect");
            this.panelSelect.Name = "panelSelect";
            // 
            // garagePage1
            // 
            resources.ApplyResources(this.garagePage1, "garagePage1");
            this.garagePage1.Car = null;
            this.garagePage1.currentSelectedImage = null;
            this.garagePage1.Name = "garagePage1";
            // 
            // panelNew
            // 
            resources.ApplyResources(this.panelNew, "panelNew");
            this.panelNew.Name = "panelNew";
            // 
            // edtItemName
            // 
            resources.ApplyResources(this.edtItemName, "edtItemName");
            this.edtItemName.Name = "edtItemName";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseCompatibleTextRendering = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseCompatibleTextRendering = true;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnOk);
            this.panelButtons.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.panelButtons, "panelButtons");
            this.panelButtons.Name = "panelButtons";
            // 
            // SelectCarDlg
            // 
            this.AcceptButton = this.btnOk;
            this.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.panelNew);
            this.Controls.Add(this.panelButtons);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectCarDlg";
            this.panelSelect.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Panel panelNew;
        private System.Windows.Forms.TextBox edtItemName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ESRMButton btnCancel;
        private ESRMButton btnOk;
        private System.Windows.Forms.Panel panelButtons;
        private Views.GaragePage garagePage1;
    }
}