
using System.Drawing;
namespace ESRM.Win
{
    partial class ESRMButtonSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ESRMButtonSelect));
            this.lblBtnText = new System.Windows.Forms.Label();
            this.lblSubText = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblBtnText
            // 
            this.lblBtnText.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblBtnText, "lblBtnText");
            this.lblBtnText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBtnText.Name = "lblBtnText";
            this.lblBtnText.Click += new System.EventHandler(this.pbBtnImage_Click);
            this.lblBtnText.MouseLeave += new System.EventHandler(this.lblBtnText_MouseLeave);
            this.lblBtnText.MouseHover += new System.EventHandler(this.lblBtnText_MouseHover);
            // 
            // lblSubText
            // 
            this.lblSubText.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblSubText, "lblSubText");
            this.lblSubText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubText.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblSubText.Name = "lblSubText";
            this.lblSubText.Click += new System.EventHandler(this.pbBtnImage_Click);
            this.lblSubText.MouseLeave += new System.EventHandler(this.lblSubText_MouseLeave);
            this.lblSubText.MouseHover += new System.EventHandler(this.lblSubText_MouseHover);
            // 
            // ESRMButtonSelect
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.Controls.Add(this.lblBtnText);
            this.Controls.Add(this.lblSubText);
            resources.ApplyResources(this, "$this");
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ESRMButtonSelect";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblBtnText;
        public System.Windows.Forms.Label lblSubText;
        public System.Windows.Forms.ToolTip toolTip1;
    }
}
