using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Contra
{
    public partial class CncListControl : ListBoxControl
    {
        public CncListControl()
        {
            InitializeComponent();
            this.DisplayMember = "Text";
            this.ValueMember = "Value";
            this.DataSource = Collection;
            this.ItemHeight = 20;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private BaseInfoCollection collection;
        public BaseInfoCollection Collection
        {
            get
            {
                if (collection == null) collection = new BaseInfoCollection();
                return collection;
            }
            set
            {
                this.collection = value;
                this.DataSource = collection;
            }
        }

        public int Count
        {
            get { return this.Collection.Count; }
        }

        private int Index
        {
            get
            {
                if (this.SelectedIndex >= 0)
                {
                    return this.SelectedIndex;
                }
                return 0;
            }
        }

        //public void Add(params string[] items)
        //{
        //    BaseInfo info = this.Collection.Add(items);
        //    if (info != null)
        //        this.SelectedItem = info;
        //    this.Refresh();
        //}

        //public void Add(BaseInfo info)
        //{
        //    this.Collection.Add(info);
        //    if (info != null)
        //        this.SelectedItem = info;
        //    this.Refresh();
        //}

        public void Insert(params string[] items)
        {
            BaseInfo info = null;
            if (this.Index == this.Collection.Count)
            {
                info = this.Collection.Add(items);
            }
            else
            {
                info = this.Collection.Insert(this.Index + 1, items);
            }
            if (info != null)
                this.SelectedItem = info;
            this.Refresh();
        }

        public void Insert(BaseInfo info)
        {
            Insert(Index, info);
            if (info != null)
                this.SelectedItem = info;
        }

        public void Insert(int index, BaseInfo info)
        {
            this.Collection.Insert(index, info);
            this.Refresh();
        }

        public void Delete()
        {
            if (this.SelectedItem != null && this.Collection.Count > 0)
            {
                BaseInfo info = this.SelectedItem as BaseInfo;
                int index = this.SelectedIndex;
                this.Collection.Remove(info);
                if (this.Collection.Count > 0)
                {
                    if (index < this.collection.Count)
                        this.SelectedItem = this.Collection[index];
                    else
                    {
                        this.SelectedItem = this.Collection[this.Collection.Count - 1];
                    }
                }
                this.Collection.Calclate();
                this.Refresh();
            }
        }

        public void RemoveAt(int i)
        {
            this.collection.RemoveAt(i);
        }

        public void DeleteAll()
        {
            this.SelectedItem = null;
            this.Collection.Clear();
            this.Refresh();
        }

        public void AddStart()
        {
            this.SelectedItem = this.Collection.Insert(0, HeadType.Start);
            this.Collection.Calclate();
            this.Refresh();
        }

        public void AddEnd()
        {
            this.SelectedItem = this.Collection.Insert(this.Collection.Count, HeadType.M30);
            this.Collection.Calclate();
            this.Refresh();
        }        

        public void LoadFromFile(string fileName)
        {
            this.Collection = new BaseInfoCollection(fileName);
            this.Refresh();
        }

        public void LoadList(BaseInfoCollection collection)
        {
            this.Collection = collection;
            this.Refresh();
        }

    }
}
