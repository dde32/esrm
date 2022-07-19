
using System.Drawing;
namespace ESRM.Win
{
    partial class ESRMButtonForNumeric
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ESRMButtonForNumeric));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblBtnText = new System.Windows.Forms.Label();
            this.lblSubText = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSubText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBtnText
            // 
            this.lblBtnText.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblBtnText, "lblBtnText");
            this.lblBtnText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblBtnText.Name = "lblBtnText";
            this.lblBtnText.MouseLeave += new System.EventHandler(this.lblBtnText_MouseLeave);
            this.lblBtnText.MouseHover += new System.EventHandler(this.lblBtnText_MouseHover);
            // 
            // lblSubText
            // 
            resources.ApplyResources(this.lblSubText, "lblSubText");
            this.lblSubText.Name = "lblSubText";
            this.lblSubText.Properties.AllowFocused = false;
            this.lblSubText.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lblSubText.Properties.Appearance.BackColor")));
            this.lblSubText.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblSubText.Properties.Appearance.Font")));
            this.lblSubText.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblSubText.Properties.Appearance.ForeColor")));
            this.lblSubText.Properties.Appearance.Options.UseBackColor = true;
            this.lblSubText.Properties.Appearance.Options.UseBorderColor = true;
            this.lblSubText.Properties.Appearance.Options.UseFont = true;
            this.lblSubText.Properties.Appearance.Options.UseForeColor = true;
            this.lblSubText.Properties.Appearance.Options.UseTextOptions = true;
            this.lblSubText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblSubText.Properties.AutoHeight = ((bool)(resources.GetObject("lblSubText.Properties.AutoHeight")));
            this.lblSubText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(serializableAppearanceObject1, "serializableAppearanceObject1");
            serializableAppearanceObject1.Options.UseFont = true;
            this.lblSubText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lblSubText.Properties.Buttons"))), resources.GetString("lblSubText.Properties.Buttons1"), ((int)(resources.GetObject("lblSubText.Properties.Buttons2"))), ((bool)(resources.GetObject("lblSubText.Properties.Buttons3"))), ((bool)(resources.GetObject("lblSubText.Properties.Buttons4"))), ((bool)(resources.GetObject("lblSubText.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("lblSubText.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("lblSubText.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("lblSubText.Properties.Buttons8"), ((object)(resources.GetObject("lblSubText.Properties.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("lblSubText.Properties.Buttons10"))), ((bool)(resources.GetObject("lblSubText.Properties.Buttons11"))))});
            this.lblSubText.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.lblSubText.Properties.IsFloatValue = false;
            this.lblSubText.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.lblSubText.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblSubText.Properties.Mask.EditMask = resources.GetString("lblSubText.Properties.Mask.EditMask");
            this.lblSubText.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.lblSubText.EditValueChanged += new System.EventHandler(this.lblSubText_EditValueChanged);
            // 
            // ESRMButtonForNumeric
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblSubText);
            this.Controls.Add(this.lblBtnText);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ESRMButtonForNumeric";
            ((System.ComponentModel.ISupportInitialize)(this.lblSubText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblBtnText;
        public DevExpress.XtraEditors.SpinEdit lblSubText;

    }
}
