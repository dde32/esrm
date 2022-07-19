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
    public partial class TextBoxDlg : Form
    {
        public string EditValue
        {
            get { return textBox1.Text; }
        }
    
        public TextBoxDlg(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
        }
    }

 
}
