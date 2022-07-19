using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRM.Entities;

namespace ESRM.Win.Panels
{
    public partial class ESRMControl : UserControl
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

        public virtual void DeepRefresh()
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
