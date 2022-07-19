using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;
using DevExpress.XtraEditors;

namespace ESRM.Win.Panels
{
    public partial class ESRMPanel : PanelControl
    {

        #region BINDING

        static public void ClearBindings(Control control)
        {
            control.DataBindings.Clear();

            foreach (Control ctrl in control.Controls)
            {
                ctrl.DataBindings.Clear();
                ClearBindings(ctrl);
            }
        }

        protected virtual void DeepRefresh()
        {
            DeepRefresh(this);
        }

        protected virtual void DeepRefresh(Control control)
        {
            foreach (Binding db in control.DataBindings)
                db.ReadValue();


            foreach (Control ctrl in control.Controls)
            {
                DeepRefresh(ctrl);
            }
        }

        protected virtual void DoBinding()
        {
            ClearBindings(this);
        }

        #endregion

    }
    

}
