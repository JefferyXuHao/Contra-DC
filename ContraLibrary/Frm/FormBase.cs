using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.IO;

namespace ContraLibrary
{
    public partial class FormBase : XtraForm
    {
        public FormBase()
        {
            InitializeComponent();
            string overrideIconPath = Path.Combine(Application.StartupPath,"OverrideLogo.ico");
            if (File.Exists(overrideIconPath))
            {
                this.Icon = new Icon(overrideIconPath);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LanguageTransform(this, this.Name);
        }

        private void LanguageTransform(Control control, string parentName)
        {
            string controlName = parentName + "." + control.Name;
            Type type = control.GetType();
            string typeName = type.Name;
            if (control is Form)
            {
                typeName = "Form";
            }
            string text = string.Empty;
            switch (typeName)
            {
                case "Form":
                case "Button":
                case "CheckBox":
                case "Label":
                case "LabelControl":
                case "RadioButton":
                case "GroupBox":
                case "SimpleButton":
                case "GroupControl":
                case "XtraTabPage":
                case "LockCheckButton":
                case "StateButton":
                case "CheckEdit":
                case "LinkLabel":
                    text = LanguageHelper.GetText(controlName, control.Text);
                    if (text != null)
                    {
                        control.Text = text;
                    }
                    break;
                case "GridControl":
                    GridControl grid = control as GridControl;
                    GridView gv = grid.MainView as GridView;
                    foreach (GridColumn column in gv.Columns)
                    {
                        var columnName = controlName + "." + column.Name;
                        text = LanguageHelper.GetText(columnName, column.Caption);
                        if (text != null)
                        {
                            column.Caption = text;
                        }
                    }
                    break;
                case "RadioGroup":
                    RadioGroup rg = control as RadioGroup;
                    for (int i = 0; i < rg.Properties.Items.Count; i++)
                    {
                        RadioGroupItem item = rg.Properties.Items[i];
                        var columnName = controlName + ".item" + i;
                        text = LanguageHelper.GetText(columnName, item.Description);
                        if (text != null)
                        {
                            item.Description = text;
                        }
                    }
                    break;
                default:
                    break;
            }
            foreach (Control item in control.Controls)
            {
                LanguageTransform(item, parentName);
            }

        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if ((System.Windows.Forms.Control.ModifierKeys & Keys.Control) == Keys.Control
                && (System.Windows.Forms.Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ShowLanguageKeyValues();
            }
            else if ((System.Windows.Forms.Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ShowControlType();
            }
        }

        protected void ShowLanguageKeyValues()
        {
            Dictionary<String, String> dict = new Dictionary<string, string>();
            GetLanguageKeyValues(this, this.GetType().Name, dict);
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, string> item in dict)
            {
                builder.AppendLine(String.Format("<item name=\"{0}\">{1}</item>", item.Key, item.Value));
            }
            FormText formText = new FormText();
            formText.SetText(builder.ToString());
            formText.ShowDialog();
        }

        protected void ShowControlType()
        {
            List<String> list = new List<string>();
            GetControlType(this, list);
            StringBuilder builder = new StringBuilder();
            foreach (String item in list)
            {
                builder.AppendLine(item);
            }
            FormText formText = new FormText();
            formText.SetText(builder.ToString());
            formText.ShowDialog();
        }

        private void GetControlType(Control control, List<String> types)
        {
            Type type = control.GetType();
            if (!types.Contains(type.Name))
            {
                types.Add(type.Name);
            }
            foreach (Control item in control.Controls)
            {
                GetControlType(item, types);
            }
        }

        private void GetLanguageKeyValues(Control control, string parentName, Dictionary<String, String> dict)
        {
            string controlName = parentName + "." + control.Name;
            Type type = control.GetType();
            string typeName = type.Name;
            if (control is Form)
            {
                typeName = "Form";
            }
            switch (typeName)
            {
                case "Form":
                case "Button":
                case "CheckBox":
                case "Label":
                case "RadioButton":
                case "GroupBox":
                case "SimpleButton":
                case "LabelControl":
                case "GroupControl":
                case "XtraTabPage":
                case "LockCheckButton":
                case "StateButton":
                    AddLanguageValue(controlName, control.Text, dict);
                    break;
                case "GridControl":
                    GridControl grid = control as GridControl;
                    GridView gv = grid.MainView as GridView;
                    foreach (GridColumn column in gv.Columns)
                    {
                        var columnName = controlName + "." + column.Name;
                        AddLanguageValue(columnName, column.Caption, dict);
                    }
                    break;
                case "RadioGroup":
                    RadioGroup rg = control as RadioGroup;
                    for (int i = 0; i < rg.Properties.Items.Count; i++)
                    {
                        RadioGroupItem item = rg.Properties.Items[i];
                        var columnName = controlName + ".item" + i;
                        AddLanguageValue(columnName, item.Description, dict);
                    }
                    break;
                default:
                    break;
            }
            foreach (Control item in control.Controls)
            {
                GetLanguageKeyValues(item, parentName, dict);
            }
        }

        private void AddLanguageValue(string key, string value, Dictionary<string, string> dict)
        {
            if (LanguageHelper.IsContainsChinese(value))
                dict.Add(key, value);
        }
    }
}
