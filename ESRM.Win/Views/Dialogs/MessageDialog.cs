using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

namespace ESRM.Win
{
    public partial class MessageDialog : Form
    {
    
        public MessageDialog(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //public static void Show(string text)
        //{
        //    MessageDialog dlg = new MessageDialog(text);
        //    dlg.Show();
        //}
    }

 
}
