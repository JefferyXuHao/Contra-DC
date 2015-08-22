using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace ContraLibrary
{
    public class PortHelper
    {
        public const string PortCheck = "0500FFBW0M019901";

        public const string ZUpOn = "0500FFBW0M0215011";
        public const string ZUpOff = "0500FFBW0M0215010";

        public const string ZDownOn = "0500FFBW0M0216011";
        public const string ZDownOff = "0500FFBW0M0216010";

        public const string ZUpOn2 = "0500FFBW0M0225011";
        public const string ZUpOff2 = "0500FFBW0M0225010";

        public const string ZDownOn2 = "0500FFBW0M0226011";
        public const string ZDownOff2 = "0500FFBW0M0226010";

        public const string SUpOn = "0500FFBW0M0215011";
        public const string SUpOff = "0500FFBW0M0215010";

        public const string SDownOn = "0500FFBW0M0216011";
        public const string SDownOff = "0500FFBW0M0216010";

        public const string LightOn = "0500FFBW0M0111011";
        public const string LightOff = "0500FFBW0M0111010";

        public const string ShinengOn = "0500FFBW0M0103011";
        public const string ShinengOff = "0500FFBW0M0103010";

        public const string DuidaoOn = "0500FFBW0M0211011";
        public const string DuidaoOff = "0500FFBW0M0211010";

        public const string ThrowOff = "0500FFBW0M02000200";
        public const string ThrowMode1 = "0500FFBW0M02000210";
        public const string ThrowMode2 = "0500FFBW0M02000201";

        public const string ThrowResponse = "0500FFWW0D010501";

        public const string _201On = "0500FFBW0M0201011";
        public const string _201Off = "0500FFBW0M0201010";

        public const string BuzzingOn = "0500FFBW0M0112011";
        public const string BuzzingOff = "0500FFBW0M0112010";

        public const string JiagongOn = "0500FFBW0M0102011";
        public const string JiagongOff = "0500FFBW0M0102010";

        public const string FanjixingOn = "0500FFBW0M0120011";
        public const string FanjixingOff = "0500FFBW0M0120010";

        public const string ShuibengOn = "0500FFBW0M0101011";
        public const string ShuibengOff = "0500FFBW0M0101010";

        public const string Duanlu = "0500FFBW0M0104010";

        public const string RotateOn = "0500FFBW0M0100011";
        public const string RotateOff = "0500FFBW0M0100010";

        public const string FushiOn = "0500FFBW0M0107011";
        public const string FushiOff = "0500FFBW0M0107010";

        public const string SpeedTitle = "0500FFWW0D010001000";

        public const string VTitle = "0500FFWW0D010201";

        public const string Wheel = "0500FFBR0M020113";

        public const string WheelReturn = "0500FFBW0M02100A0000000000";

        public const string ChangePie = "0500FFBW0M0150011";

        public const string DaoRotate = "0500FFBW0M0160011";

        public const string ChangeDaoXiangOn = "0500FFBW0M0161011";

        public const string ChangeDaoXiangOff = "0500FFBW0M0161010";

        public const string Zero = "0500FFBR0M030001";

        public const string Throw = "0500FFBR0M030101";

        public const string HasSignal = "00FF1";
        public const string NotHasSignal = "00FF0";

        public const string Signal1 = "0000D22E";
        public const string Signal2 = "0001D22D";
        public const string Signal3 = "0002D22C";
        public const string Signal4 = "0003D22B";

        public const string BSignal = "0000D22E";
        public const string CSignal = "0001D22D";

        public const string FushiPartXNo = "01031006000220CA";
        public const string FushiPartYNo = "02031006000220F9";
        public const string FushiPartWNo = "0303100600022128";
        public const string FushiPartBNo = "040310060002209F";
        public const string FushiPartCNo = "050310060002214E";

        public const string LNSOn = "0500FFBW0M0122011";
        public const string LNSOff = "0500FFBW0M0122010";


        protected string msg0 = ((char)0).ToString();
        protected string msgEnd = ((char)3).ToString();
        protected string msgStart = ((char)2).ToString();
        protected string msg5 = ((char)5).ToString();
        protected string msgReceive = ((char)4).ToString();
        protected string msgStart2 = ((char)6).ToString();

        protected SerialPort port;
        protected AutoResetEvent ar;
        protected int sleep;
        protected string strMsg;

        public PortHelper(string portName)
            : this(portName, 0)
        {

        }

        public void SetSleepTime(int sleep)
        {
            this.sleep = sleep;
        }

        public PortHelper(string portName, int sleep)
        {
            try
            {
                this.sleep = sleep;
                port = new SerialPort(portName);
                ar = new AutoResetEvent(false);
                port.BaudRate = 19200;
                port.DataBits = 8; //数据位
                port.Parity = System.IO.Ports.Parity.None;//校验位　无校验
                port.StopBits = System.IO.Ports.StopBits.One;//停止位１位
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                port.WriteBufferSize = 1024;
                port.Open();
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.ErrorReceived += new SerialErrorReceivedEventHandler(port_ErrorReceived);
                port.ReceivedBytesThreshold = 1; //设置引发OnComm事件的字节长度
            }
            catch (Exception ex)
            {
                LogHelper.LogError(ex);
                ContraHelper.ShowMessage(string.Format(L.R("PortHelper.InitPortFailure", "初始化{0}口失败!"), portName));
            }
        }

        void port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            ar.Set();
        }

        protected virtual void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string strReceive = null;
            SerialPort comPort = sender as SerialPort;
            if (comPort.BytesToRead >= comPort.ReceivedBytesThreshold)
            {
                try
                {
                    strReceive = comPort.ReadExisting();
                    if (strReceive != null)
                    {
                        for (int i = 0; i < strReceive.Length; i++)
                        {
                            strMsg += ((int)strReceive[i]).ToString("X2");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(L.R("PortHelper.DataError", "接收数据错误!"));
                }
                finally
                {
                    ar.Set();
                }
            }
        }

        public string SendMsg(string msg)
        {
            return SendMsg(msg, 1, 1);
        }

        public string SendMsg(string msg, int receiverBytesCount, int attemp)
        {
            if (port != null && port.IsOpen && msg.Length >= 2)
            {
                var bytes = ConvertToBytes(msg);
                strMsg = "";
                ar.Reset();
                port.ReceivedBytesThreshold = receiverBytesCount < 1 ? 1 : receiverBytesCount;
                port.Write(bytes, 0, bytes.Length);
                if (bytes[0] != (byte)06)
                {
                    bool flag = ar.WaitOne(50);
                    if (!flag)
                    {
                        if (attemp == 2)
                        {
                            return strMsg;
                        }
                        return SendMsg(msg, receiverBytesCount, attemp + 1);
                    }
                }
                return strMsg;
            }
            return null;
        }


        public string SendMsg3(string msg, int receiverBytesCount)
        {
            return SendMsg3(msg, receiverBytesCount, 1);
        }

        public string SendMsg3(string msg, int receiverBytesCount, int attemp)
        {
            if (port != null && port.IsOpen && msg.Length >= 2)
            {
                var bytes = ConvertToBytes2(msg);
                strMsg = "";
                ar.Reset();
                port.ReceivedBytesThreshold = receiverBytesCount < 1 ? 1 : receiverBytesCount;
                port.Write(bytes, 0, bytes.Length);
                bool flag = ar.WaitOne(1000);
                if (!flag)
                {
                    if (attemp == 5)
                    {
                        throw new WarningException(L.R("PortHelper.PLCError", "PLC读取错误"));
                    }
                    return SendMsg3(msg, receiverBytesCount, attemp + 1);
                }
                return strMsg;
            }
            return null;
        }

        public string SendMsg2(string msg)
        {
            string result = SendMsg("05", 1, 1);
            if (result != null && result.StartsWith("04"))
            {
                result = SendMsg(msg, 2, 1);
                if (result != null && result.StartsWith("0605"))
                {
                    result = SendMsg("04", 15, 1);
                    if (result != null)
                    {
                        SendMsg("06");
                        return result;
                    }
                }
            }
            return null;
        }

        protected byte[] ConvertToBytes(string msg)
        {
            var text1 = msg.Substring(0, 2);
            if (text1 == "00")
            {
                byte[] bytes = new byte[msg.Length / 2];
                for (int i = 0; i < msg.Length; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(msg.Substring(i, 2), 16);
                }
                return bytes;
            }
            else
            {
                var a = Encoding.GetEncodings();

                var text2 = msg.Substring(2);
                var bytes = Encoding.ASCII.GetBytes(text2);
                var bytes2 = new byte[bytes.Length + 1];
                bytes2[0] = Convert.ToByte(text1);
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes2[i + 1] = bytes[i];
                }
                return bytes2;
                //byte[] bytes = Encoding.UTF8.GetBytes(text1);
                //return bytes;
            }
        }

        protected byte[] ConvertToBytes2(string msg)
        {
            byte[] bytes = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(msg.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}
