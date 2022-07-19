
using System.Drawing;
namespace ESRM.Win
{
    partial class ESRMButtonForTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ESRMButtonForTime));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblBtnText = new System.Windows.Forms.Label();
            this.lblSubText = new DevExpress.XtraEditors.TimeSpanEdit();
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
            this.lblSubText.Properties.AllowEditDays = false;
            this.lblSubText.Properties.AllowEditSeconds = false;
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
            this.lblSubText.Properties.AutoHeight = ((bool)(resources.GetObject("timeSpanEdit1.Properties.AutoHeight")));
            this.lblSubText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            resources.ApplyResources(serializableAppearanceObject1, "serializableAppearanceObject1");
            serializableAppearanceObject1.Options.UseFont = true;
            resources.ApplyResources(serializableAppearanceObject2, "serializableAppearanceObject2");
            serializableAppearanceObject2.Options.UseFont = true;
            resources.ApplyResources(serializableAppearanceObject3, "serializableAppearanceObject3");
            serializableAppearanceObject3.Options.UseFont = true;
            resources.ApplyResources(serializableAppearanceObject4, "serializableAppearanceObject4");
            serializableAppearanceObject4.Options.UseFont = true;
            this.lblSubText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("timeSpanEdit1.Properties.Buttons"))), resources.GetString("timeSpanEdit1.Properties.Buttons1"), ((int)(resources.GetObject("timeSpanEdit1.Properties.Buttons2"))), ((bool)(resources.GetObject("timeSpanEdit1.Properties.Buttons3"))), ((bool)(resources.GetObject("timeSpanEdit1.Properties.Buttons4"))), ((bool)(resources.GetObject("timeSpanEdit1.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("timeSpanEdit1.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("timeSpanEdit1.Properties.Buttons7"))), resources.GetString("timeSpanEdit1.Properties.Buttons8"), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, resources.GetString("timeSpanEdit1.Properties.Buttons9"), ((object)(resources.GetObject("timeSpanEdit1.Properties.Buttons10"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("timeSpanEdit1.Properties.Buttons11"))), ((bool)(resources.GetObject("timeSpanEdit1.Properties.Buttons12"))))});
            this.lblSubText.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.lblSubText.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.lblSubText.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblSubText.Properties.Mask.EditMask = resources.GetString("timeSpanEdit1.Properties.Mask.EditMask");
            this.lblSubText.Properties.MaxDays = 1;
            this.lblSubText.Properties.MaxMilliseconds = 0;
            this.lblSubText.Properties.MaxSeconds = 0;
            this.lblSubText.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.SpinButtons;
            this.lblSubText.EditValueChanged += new System.EventHandler(this.lblSubText_EditValueChanged);
            // 
            // ESRMButtonForTime
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblBtnText);
            this.Controls.Add(this.lblSubText);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ESRMButtonForTime";
            ((System.ComponentModel.ISupportInitialize)(this.lblSubText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblBtnText;
        private DevExpress.XtraEditors.TimeSpanEdit lblSubText;
    }
}
