namespace ESRM.Win
{
    partial class StartLightDlg
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
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pb3 = new System.Windows.Forms.PictureBox();
            this.pb4 = new System.Windows.Forms.PictureBox();
            this.pb5 = new System.Windows.Forms.PictureBox();
            this.lblPaceCar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).BeginInit();
            this.SuspendLayout();
            // 
            // pb1
            // 
            this.pb1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pb1.Image = global::ESRM.Win.Images.DisabledLight;
            this.pb1.Location = new System.Drawing.Point(27, 11);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(180, 180);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb1.TabIndex = 0;
            this.pb1.TabStop = false;
            // 
            // pb2
            // 
            this.pb2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pb2.Image = global::ESRM.Win.Images.DisabledLight;
            this.pb2.Location = new System.Drawing.Point(239, 12);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(180, 180);
            this.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb2.TabIndex = 5;
            this.pb2.TabStop = false;
            // 
            // pb3
            // 
            this.pb3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pb3.Image = global::ESRM.Win.Images.DisabledLight;
            this.pb3.Location = new System.Drawing.Point(451, 12);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(180, 180);
            this.pb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb3.TabIndex = 6;
            this.pb3.TabStop = false;
            // 
            // pb4
            // 
            this.pb4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pb4.Image = global::ESRM.Win.Images.DisabledLight;
            this.pb4.Location = new System.Drawing.Point(663, 12);
            this.pb4.Name = "pb4";
            this.pb4.Size = new System.Drawing.Size(180, 180);
            this.pb4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb4.TabIndex = 7;
            this.pb4.TabStop = false;
            // 
            // pb5
            // 
            this.pb5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pb5.Image = global::ESRM.Win.Images.DisabledLight;
            this.pb5.Location = new System.Drawing.Point(856, 12);
            this.pb5.Name = "pb5";
            this.pb5.Size = new System.Drawing.Size(180, 180);
            this.pb5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb5.TabIndex = 8;
            this.pb5.TabStop = false;
            // 
            // lblPaceCar
            // 
            this.lblPaceCar.BackColor = System.Drawing.Color.Transparent;
            this.lblPaceCar.Font = new System.Drawing.Font("Impact", 32.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaceCar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPaceCar.Location = new System.Drawing.Point(195, 184);
            this.lblPaceCar.Name = "lblPaceCar";
            this.lblPaceCar.Size = new System.Drawing.Size(696, 55);
            this.lblPaceCar.TabIndex = 76;
            this.lblPaceCar.Text = "Fin de voiture de sécurité dans ce tour";
            this.lblPaceCar.Visible = false;
            // 
            // StartLightDlg
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1087, 237);
            this.ControlBox = false;
            this.Controls.Add(this.lblPaceCar);
            this.Controls.Add(this.pb5);
            this.Controls.Add(this.pb4);
            this.Controls.Add(this.pb3);
            this.Controls.Add(this.pb2);
            this.Controls.Add(this.pb1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartLightDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.PictureBox pb3;
        private System.Windows.Forms.PictureBox pb4;
        private System.Windows.Forms.PictureBox pb5;
        private System.Windows.Forms.Label lblPaceCar;
    }
}