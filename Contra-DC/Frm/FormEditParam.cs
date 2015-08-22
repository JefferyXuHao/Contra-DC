using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContraLibrary;
using DevExpress.XtraEditors;

namespace Contra
{
    public partial class FormEditParam : FormBase
    {
        private IOHelper ioHelper;
        private object title;
        private int oldValue;
        public FormEditParam(object title, object value, decimal minValue, decimal maxValue, IOHelper ioHelper)
        {
            InitializeComponent();
            this.label1.Text = string.Format("{0}", title);
            this.Text = string.Format(L.R("FormEditParam.Text", "{0}修改"), title);
            this.spinEdit1.EditValue = value;
            this.spinEdit1.Properties.MaxValue = maxValue;
            this.spinEdit1.Properties.MinValue = minValue;
            this.ioHelper = ioHelper;
            this.title = title;
            this.oldValue = Convert.ToInt32(value);
        }

        public object EditValue { get { return this.spinEdit1.EditValue; } }

        private void spinEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var spinEdit = sender as SpinEdit;
            var value = Convert.ToInt32(spinEdit.EditValue);
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                if (value < spinEdit.Properties.MaxValue)
                    spinEdit.EditValue = ++value;
            }
            else
            {
                if (value > spinEdit.Properties.MinValue)
                    spinEdit.EditValue = --value;
            }
            SetByValue(value);
        }

        private void SetByValue(int value)
        {
            if (object.Equals(title, L.R("FormEditParam.MainKuan", "脉宽")))
            {
                ioHelper.SetTOn(value);
            }
            else if (object.Equals(title, L.R("FormEditParam.MainJian", "脉间")))
            {
                ioHelper.SetTOff(value);
            }
            else if (object.Equals(title, L.R("FormEditParam.DianLiu", "电流")))
            {
                ioHelper.SetI(value);
            }
            else if (object.Equals(title, L.R("FormEditParam.DianRong", "电容")))
            {
                ioHelper.SetI2(value);
            }
            else if (object.Equals(title, L.R("FormEditParam.XiuZheng", "修整")))
            {
                ioHelper.SetSpeed(value);
            }
            else if (object.Equals(title, L.R("FormEditParam.DianYa", "电压")))
            {
                ioHelper.SetV(value);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetByValue(oldValue);
        }
    }
}
