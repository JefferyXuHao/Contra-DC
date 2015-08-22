using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contra
{
    public class OtherSetInfo : BaseSetInfo
    {
        public OtherSetInfo()
        {
            JiagongErrorWaitTime = 10;
            LanguageType = "zh-CN";
            LNSAllowValue = 0.1m;
        }

        public string LanguageType { get; set; }

        /// <summary>
        /// 回升余量
        /// </summary>
        public decimal ZUpLeft { get; set; }

        public bool SlowZero { get; set; }

        public bool PositionCheck { get; set; }

        public int PositionCheckCount { get; set; }

        public decimal PositionCheckLeft { get; set; }

        public bool IgnoreShuibeng { get; set; }

        public bool IgnoreShifuBaojing { get; set; }

        public decimal FusiLocation { get; set; }

        public decimal ChangePoleHeight { get; set; }

        public bool ShowStartZeroForm { get; set; }

        public int JiagongErrorWaitTime { get; set; }

        //使用自动分中
        public bool UseAutoCenter { get; set; }

        //加工延时
        public int ShuibengDelay { get; set; }

        #region 刀库控制
        public decimal DaoXSafeHeight { get; set; }
        public decimal DaoYSafeHeight { get; set; }
        public decimal DaoWSafeHeight { get; set; }
        #endregion

        public decimal ChangeDaoFailureHeight { get; set; }

        public bool UseChangeDao { get; set; }

        public int LNSDownSpeed1 { get; set; }

        public int LNSDownSpeed2 { get; set; }

        public int LNSBackSpeed { get; set; }

        public int LNSBackHeight { get; set; }

        public decimal LNSAllowValue { get; set; }

        public decimal BackHeightRate { get; set; }

        public string ScriptMode { get; set; }
    }
}
