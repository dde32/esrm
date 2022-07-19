namespace ESRM.LicenceGenerator
{
    partial class Form1
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
            this.edtId = new System.Windows.Forms.TextBox();
            this.btnSaveLicenceFile = new System.Windows.Forms.Button();
            this.LapCountMax = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TeamsCountMax = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.TimeLimitMax = new System.Windows.Forms.NumericUpDown();
            this.TAMaxLevel = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edtEmail = new System.Windows.Forms.TextBox();
            this.btnSaveTrialLicence = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.LapCountMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamsCountMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeLimitMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TAMaxLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // edtId
            // 
            this.edtId.Location = new System.Drawing.Point(212, 57);
            this.edtId.Name = "edtId";
            this.edtId.Size = new System.Drawing.Size(316, 26);
            this.edtId.TabIndex = 1;
            // 
            // btnSaveLicenceFile
            // 
            this.btnSaveLicenceFile.Location = new System.Drawing.Point(649, 60);
            this.btnSaveLicenceFile.Name = "btnSaveLicenceFile";
            this.btnSaveLicenceFile.Size = new System.Drawing.Size(274, 45);
            this.btnSaveLicenceFile.TabIndex = 4;
            this.btnSaveLicenceFile.Text = "Standard Licence";
            this.btnSaveLicenceFile.UseVisualStyleBackColor = true;
            this.btnSaveLicenceFile.Click += new System.EventHandler(this.btnSaveLicenceFile_Click);
            // 
            // LapCountMax
            // 
            this.LapCountMax.Location = new System.Drawing.Point(212, 166);
            this.LapCountMax.Name = "LapCountMax";
            this.LapCountMax.Size = new System.Drawing.Size(120, 26);
            this.LapCountMax.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre de tours max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nombre d\'équipe max";
            // 
            // TeamsCountMax
            // 
            this.TeamsCountMax.Location = new System.Drawing.Point(212, 211);
            this.TeamsCountMax.Name = "TeamsCountMax";
            this.TeamsCountMax.Size = new System.Drawing.Size(120, 26);
            this.TeamsCountMax.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Durée max (min)";
            // 
            // TimeLimitMax
            // 
            this.TimeLimitMax.Location = new System.Drawing.Point(212, 260);
            this.TimeLimitMax.Name = "TimeLimitMax";
            this.TimeLimitMax.Size = new System.Drawing.Size(120, 26);
            this.TimeLimitMax.TabIndex = 10;
            // 
            // TAMaxLevel
            // 
            this.TAMaxLevel.Location = new System.Drawing.Point(212, 312);
            this.TAMaxLevel.Name = "TAMaxLevel";
            this.TAMaxLevel.Size = new System.Drawing.Size(120, 26);
            this.TAMaxLevel.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Time Attack max level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Identifiant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Email";
            // 
            // edtEmail
            // 
            this.edtEmail.Location = new System.Drawing.Point(212, 89);
            this.edtEmail.Name = "edtEmail";
            this.edtEmail.Size = new System.Drawing.Size(316, 26);
            this.edtEmail.TabIndex = 14;
            // 
            // btnSaveTrialLicence
            // 
            this.btnSaveTrialLicence.Location = new System.Drawing.Point(649, 111);
            this.btnSaveTrialLicence.Name = "btnSaveTrialLicence";
            this.btnSaveTrialLicence.Size = new System.Drawing.Size(274, 45);
            this.btnSaveTrialLicence.TabIndex = 16;
            this.btnSaveTrialLicence.Text = "Trial Licence";
            this.btnSaveTrialLicence.UseVisualStyleBackColor = true;
            this.btnSaveTrialLicence.Click += new System.EventHandler(this.btnSaveTrialLicence_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 540);
            this.Controls.Add(this.btnSaveTrialLicence);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.edtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TAMaxLevel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TimeLimitMax);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TeamsCountMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LapCountMax);
            this.Controls.Add(this.btnSaveLicenceFile);
            this.Controls.Add(this.edtId);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LapCountMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamsCountMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeLimitMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TAMaxLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtId;
        private System.Windows.Forms.Button btnSaveLicenceFile;
        private System.Windows.Forms.NumericUpDown LapCountMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown TeamsCountMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown TimeLimitMax;
        private System.Windows.Forms.NumericUpDown TAMaxLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtEmail;
        private System.Windows.Forms.Button btnSaveTrialLicence;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

