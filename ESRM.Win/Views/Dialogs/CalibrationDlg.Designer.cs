namespace ESRM.Win
{
    partial class CalibrationDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationDialog));
            this.btnOk = new ESRM.Win.ESRMButton();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.BrakeCurvePanel = new ESRM.Win.GamePadCurvePanel();
            this.ThrottleCurvePanel = new ESRM.Win.GamePadCurvePanel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.esrmButton1 = new ESRM.Win.ESRMButton();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccelParams = new ESRM.Win.ESRMButton();
            this.btnbrakeParams = new ESRM.Win.ESRMButton();
            this.edtItemName = new System.Windows.Forms.TextBox();
            this.panelSelect.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
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
            // panelSelect
            // 
            resources.ApplyResources(this.panelSelect, "panelSelect");
            this.panelSelect.Controls.Add(this.BrakeCurvePanel);
            this.panelSelect.Controls.Add(this.ThrottleCurvePanel);
            this.panelSelect.Name = "panelSelect";
            // 
            // BrakeCurvePanel
            // 
            resources.ApplyResources(this.BrakeCurvePanel, "BrakeCurvePanel");
            this.BrakeCurvePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BrakeCurvePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BrakeCurvePanel.ForeColor = System.Drawing.Color.White;
            this.BrakeCurvePanel.Name = "BrakeCurvePanel";
            // 
            // ThrottleCurvePanel
            // 
            resources.ApplyResources(this.ThrottleCurvePanel, "ThrottleCurvePanel");
            this.ThrottleCurvePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ThrottleCurvePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThrottleCurvePanel.ForeColor = System.Drawing.Color.White;
            this.ThrottleCurvePanel.Name = "ThrottleCurvePanel";
            // 
            // panelButtons
            // 
            resources.ApplyResources(this.panelButtons, "panelButtons");
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Controls.Add(this.esrmButton1);
            this.panelButtons.Controls.Add(this.btnOk);
            this.panelButtons.Name = "panelButtons";
            // 
            // esrmButton1
            // 
            resources.ApplyResources(this.esrmButton1, "esrmButton1");
            this.esrmButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.esrmButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.esrmButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.esrmButton1.ForeColor = System.Drawing.Color.White;
            this.esrmButton1.Name = "esrmButton1";
            this.esrmButton1.UseCompatibleTextRendering = true;
            this.esrmButton1.UseVisualStyleBackColor = false;
            this.esrmButton1.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelHeader
            // 
            resources.ApplyResources(this.panelHeader, "panelHeader");
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.btnAccelParams);
            this.panelHeader.Controls.Add(this.btnbrakeParams);
            this.panelHeader.Name = "panelHeader";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // btnAccelParams
            // 
            resources.ApplyResources(this.btnAccelParams, "btnAccelParams");
            this.btnAccelParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnAccelParams.ForeColor = System.Drawing.Color.YellowGreen;
            this.btnAccelParams.Name = "btnAccelParams";
            this.btnAccelParams.UseCompatibleTextRendering = true;
            this.btnAccelParams.UseVisualStyleBackColor = true;
            this.btnAccelParams.Click += new System.EventHandler(this.btnAccelParams_Click);
            // 
            // btnbrakeParams
            // 
            resources.ApplyResources(this.btnbrakeParams, "btnbrakeParams");
            this.btnbrakeParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnbrakeParams.ForeColor = System.Drawing.Color.DimGray;
            this.btnbrakeParams.Name = "btnbrakeParams";
            this.btnbrakeParams.UseCompatibleTextRendering = true;
            this.btnbrakeParams.UseVisualStyleBackColor = true;
            this.btnbrakeParams.Click += new System.EventHandler(this.btnbrakeParams_Click);
            // 
            // edtItemName
            // 
            resources.ApplyResources(this.edtItemName, "edtItemName");
            this.edtItemName.Name = "edtItemName";
            // 
            // CalibrationDialog
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.btnOk;
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelButtons);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "CalibrationDialog";
            this.panelSelect.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRMButton btnOk;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.TextBox edtItemName;
        private ESRMButton esrmButton1;
        private ESRMButton btnAccelParams;
        private ESRMButton btnbrakeParams;
        private GamePadCurvePanel ThrottleCurvePanel;
        private System.Windows.Forms.Label label1;
        private GamePadCurvePanel BrakeCurvePanel;
    }
}