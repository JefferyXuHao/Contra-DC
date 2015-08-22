using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Contra
{
    public partial class FormOutTest : XtraForm
    {
        public FormOutTest()
        {
            InitializeComponent();

            CtrlCard.Init_Board();
            CtrlCard.SetIOMmode(0, 1);

            this.chkOut16.DataBindings.Add("EditValue", this.bindingSource1, "Out16", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut17.DataBindings.Add("EditValue", this.bindingSource1, "Out17", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut18.DataBindings.Add("EditValue", this.bindingSource1, "Out18", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut19.DataBindings.Add("EditValue", this.bindingSource1, "Out19", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut20.DataBindings.Add("EditValue", this.bindingSource1, "Out20", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut21.DataBindings.Add("EditValue", this.bindingSource1, "Out21", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut22.DataBindings.Add("EditValue", this.bindingSource1, "Out22", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut23.DataBindings.Add("EditValue", this.bindingSource1, "Out23", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut24.DataBindings.Add("EditValue", this.bindingSource1, "Out24", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut25.DataBindings.Add("EditValue", this.bindingSource1, "Out25", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut26.DataBindings.Add("EditValue", this.bindingSource1, "Out26", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut27.DataBindings.Add("EditValue", this.bindingSource1, "Out27", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut28.DataBindings.Add("EditValue", this.bindingSource1, "Out28", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut29.DataBindings.Add("EditValue", this.bindingSource1, "Out29", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut30.DataBindings.Add("EditValue", this.bindingSource1, "Out30", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkOut31.DataBindings.Add("EditValue", this.bindingSource1, "Out31", true, DataSourceUpdateMode.OnPropertyChanged);


            this.chkInput32.DataBindings.Add("EditValue", this.bindingSource1, "Input32", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput33.DataBindings.Add("EditValue", this.bindingSource1, "Input33", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput34.DataBindings.Add("EditValue", this.bindingSource1, "Input34", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput35.DataBindings.Add("EditValue", this.bindingSource1, "Input35", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput36.DataBindings.Add("EditValue", this.bindingSource1, "Input36", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput37.DataBindings.Add("EditValue", this.bindingSource1, "Input37", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput38.DataBindings.Add("EditValue", this.bindingSource1, "Input38", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput39.DataBindings.Add("EditValue", this.bindingSource1, "Input39", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput44.DataBindings.Add("EditValue", this.bindingSource1, "Input44", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput45.DataBindings.Add("EditValue", this.bindingSource1, "Input45", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput46.DataBindings.Add("EditValue", this.bindingSource1, "Input46", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput47.DataBindings.Add("EditValue", this.bindingSource1, "Input47", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput48.DataBindings.Add("EditValue", this.bindingSource1, "Input48", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput49.DataBindings.Add("EditValue", this.bindingSource1, "Input49", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput50.DataBindings.Add("EditValue", this.bindingSource1, "Input50", true, DataSourceUpdateMode.OnPropertyChanged);
            this.chkInput51.DataBindings.Add("EditValue", this.bindingSource1, "Input51", true, DataSourceUpdateMode.OnPropertyChanged);


            this.bindingSource1.DataSource = new OutTestInfo();

            this.chkOut16.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut17.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut18.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut19.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut20.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut21.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut22.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut23.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut24.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut25.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut26.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut27.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut28.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut29.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut30.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
            this.chkOut31.CheckedChanged += new EventHandler(chkOut_CheckedChanged);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            timer1.Enabled = true;
        }

        void chkOut_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            CheckEdit edit = sender as CheckEdit;
            string name = edit.Name;
            name = name.Replace("chkOut", "");
            int outOut = Convert.ToInt32(name);
            SetOutPut(outOut, edit.Checked ? 1 : 0);
            timer1.Enabled = true;
        }

        private CCtrlCard ctrlCard;
        public CCtrlCard CtrlCard
        {
            get
            {
                if (ctrlCard == null) ctrlCard = new CCtrlCard();
                return ctrlCard;
            }
        }

        public OutTestInfo OutTest
        {
            get { return this.bindingSource1.DataSource as OutTestInfo; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OutTest.Out16 = GetOutPutState(16);
            OutTest.Out17 = GetOutPutState(17);
            OutTest.Out18 = GetOutPutState(18);
            OutTest.Out19 = GetOutPutState(19);
            OutTest.Out20 = GetOutPutState(20);
            OutTest.Out21 = GetOutPutState(21);
            OutTest.Out22 = GetOutPutState(22);
            OutTest.Out23 = GetOutPutState(23);
            OutTest.Out24 = GetOutPutState(24);
            OutTest.Out25 = GetOutPutState(25);
            OutTest.Out26 = GetOutPutState(26);
            OutTest.Out27 = GetOutPutState(27);
            OutTest.Out28 = GetOutPutState(28);
            OutTest.Out29 = GetOutPutState(29);
            OutTest.Out30 = GetOutPutState(30);
            OutTest.Out31 = GetOutPutState(31);

            OutTest.Input32 = GetInputState(32);
            OutTest.Input33 = GetInputState(33);
            OutTest.Input34 = GetInputState(34);
            OutTest.Input35 = GetInputState(35);
            OutTest.Input36 = GetInputState(36);
            OutTest.Input37 = GetInputState(37);
            OutTest.Input38 = GetInputState(38);
            OutTest.Input39 = GetInputState(39);

            OutTest.Input44 = GetInputState(44);
            OutTest.Input45 = GetInputState(45);
            OutTest.Input46 = GetInputState(46);
            OutTest.Input47 = GetInputState(47);
            OutTest.Input48 = GetInputState(48);
            OutTest.Input49 = GetInputState(49);
            OutTest.Input50 = GetInputState(50);
            OutTest.Input51 = GetInputState(51);

            this.bindingSource1.ResetBindings(false);
        }

        private bool GetOutPutState(int number)
        {
            return CtrlCard.Get_OutNum(number) == 1;
        }

        private bool GetInputState(int number)
        {
            return CtrlCard.Read_Input(number) == 0;
        }

        /// <summary>
        /// 设置输出点状态
        /// </summary>
        private void SetOutPut(int number, int value)
        {
            CtrlCard.Write_Output(number, value);
        }
    }
}
