using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ContraLibrary
{
    public class ButtonWatchInfo
    {
        public bool IsHode
        {
            get;
            internal set;
        }

        public Nullable<DateTime> HodeStart
        {
            get;
            internal set;
        }

        public bool IsCause
        {
            get;
            set;

        }

        public bool IsLastHode
        {
            get;
            internal set;
        }
    }

    public class ButtonWatchEventArgs
    {
        public int State
        {
            get;
            private set;
        }

        public int ButtonNum
        {
            get;
            private set;
        }

        public ButtonWatchEventArgs(int buttonNum, int state)
        {
            State = state;
            ButtonNum = buttonNum;
        }
    }

    public class ButtonWatch
    {
        private Timer timer;
        private Dictionary<int, ButtonWatchInfo> dict;
        public event Action<ButtonWatchEventArgs> ButtonEvent;
        public ButtonWatch()
        {
            this.timer = new Timer();
            this.timer.Interval = 20;
            this.LongHodeSecond = 600;
            this.dict = new Dictionary<int, ButtonWatchInfo>();
            this.timer.Tick += new EventHandler(ButtonWatch_Tick);
            this.timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Enabled = false;
        }

        public int LongHodeSecond
        {
            get;
            set;
        }

        public int WatchButtons
        {
            get { return dict.Count; }
            set
            {
                if (value > 0 && value != dict.Count)
                {
                    dict.Clear();
                    for (int i = 0; i < value; i++)
                    {
                        dict.Add(i, new ButtonWatchInfo());
                    }
                }
            }
        }

        void ButtonWatch_Tick(object sender, EventArgs e)
        {
            DateTime timeS = DateTime.Now;
            foreach (KeyValuePair<int, ButtonWatchInfo> item in dict)
            {
                if (item.Value.IsLastHode && !item.Value.IsHode && !item.Value.IsCause)
                {
                    item.Value.IsCause = true;
                    bool isShort = true;
                    if (item.Value.HodeStart.HasValue && (DateTime.Now - item.Value.HodeStart.Value).TotalMilliseconds > LongHodeSecond)
                    {
                        isShort = false;
                    }
                    if (ButtonEvent != null)
                    {
                        ButtonEvent(new ButtonWatchEventArgs(item.Key, isShort ? 1 : 2));
                    }
                }
                else if (item.Value.IsLastHode && item.Value.IsHode && !item.Value.HodeStart.HasValue)
                {
                    item.Value.HodeStart = DateTime.Now;
                }
                else if (item.Value.IsLastHode
                    && item.Value.IsHode
                    && item.Value.HodeStart.HasValue
                    && (DateTime.Now - item.Value.HodeStart.Value).TotalMilliseconds > LongHodeSecond
                    && !item.Value.IsCause)
                {
                    item.Value.IsCause = true;
                    if (ButtonEvent != null)
                        ButtonEvent(new ButtonWatchEventArgs(item.Key, 2));
                }
                if (!item.Value.IsHode)
                {
                    item.Value.HodeStart = null;
                    item.Value.IsCause = false;
                    if (ButtonEvent != null)
                    {
                        ButtonEvent(new ButtonWatchEventArgs(item.Key, 0));
                    }
                }
                item.Value.IsLastHode = item.Value.IsHode;
            }
            var i = (DateTime.Now - timeS).TotalMilliseconds;
        }

        public void SetOn(int buttonNum)
        {
            if (dict.ContainsKey(buttonNum))
            {
                dict[buttonNum].IsHode = true;
            }
        }

        public void SetOff(int buttonNum)
        {
            if (dict.ContainsKey(buttonNum))
            {
                dict[buttonNum].IsHode = false;
            }
        }

        public void SetState(int buttonNum, bool state)
        {
            if (dict.ContainsKey(buttonNum))
            {
                dict[buttonNum].IsHode = state;
            }
        }
    }
}
