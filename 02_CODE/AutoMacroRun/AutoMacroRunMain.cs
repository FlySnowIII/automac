﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoMacroRun
{
    public partial class AutoMacroRunMain : Form
    {
        private IList<string> codeList = null;
        private int codeIndex = 0;
        private int RUN_WAIT = 100;
        private int StartIndex = 5;
        private AboutMe aboutMeWin = null;

        public AutoMacroRunMain()
        {
            InitializeComponent();
            aboutMeWin = new AboutMe();
            aboutMeWin.Hide();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            StartIndex--;
            if (StartIndex <= 0)
            {
                timer2.Stop();
                timer1.Interval = RUN_WAIT;
                timer1.Start();
            }
            else
            {
                lblInfo.Text = StartIndex.ToString() + "秒後起動!";
            }
        }

        private void AutoMacroRunMain_Load(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void textBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            tbox.Text = e.KeyData.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1Key1.Text = "";
            textBox2Key2.Text = "";
            textBox3Key3.Text = "";
            textBox4Run.Text = "";
            textBox5Sleep.Text = "";
            textBox6MouseX.Text = "";
            textBox7MouseY.Text = "";
            textBox8Input.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox4Run.Text.Equals("") == false)
            { 
                textBoxCmd.AppendText("RUN:" + textBox4Run.Text + "\r\n");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox8Input.Text.Equals("") == false)
            {
                textBoxCmd.AppendText("INPUT:" + textBox8Input.Text + "\r\n");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxCmd.AppendText("MOUSE_LEFT_CLICK" + "\r\n");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxCmd.AppendText("MOUSE_DBCLICK" + "\r\n");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxCmd.AppendText("MOUSE_RIGHT_CLICK" + "\r\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5Sleep.Text.Equals("") == false)
            {
                float f = float.Parse(textBox5Sleep.Text);
                f = f * 1000;
                textBoxCmd.AppendText("SLEEP:" + f.ToString() + "\r\n");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6MouseX.Text.Equals("") == false && textBox7MouseY.Text.Equals("") == false)
            {
                int x = int.Parse(textBox6MouseX.Text);
                int y = int.Parse(textBox7MouseY.Text);
                textBoxCmd.AppendText(string.Format("MOUSE_MOVE:{0},{1}\r\n", x,y));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String keyStr1 = this.turnKeyWord(textBox1Key1.Text);
            String keyStr2 = this.turnKeyWord(textBox2Key2.Text);
            String keyStr3 = this.turnKeyWord(textBox3Key3.Text);
            if (keyStr1.Equals("") == false ||
                keyStr2.Equals("") == false ||
                keyStr3.Equals("") == false)
            {
                textBoxCmd.AppendText(string.Format("KEY:{0}{1}{2}\r\n", keyStr1, keyStr2, keyStr3));
            }
        }

        private string turnKeyWord(string strKey)
        {
            string returnWord = strKey;

            if (Enum.IsDefined(typeof(KEYCODETYPE), strKey) == false)
            {
                return returnWord.Trim();
            }

            KEYCODETYPE cmdType = (KEYCODETYPE)Enum.Parse(typeof(KEYCODETYPE), strKey);
            

            switch (cmdType)
            {
                case KEYCODETYPE.ControlKey:
                    returnWord = "^";
                    break;
                case KEYCODETYPE.LWin:
                    returnWord = "";
                    break;
                case KEYCODETYPE.RWin:
                    returnWord = "";
                    break;
                case KEYCODETYPE.ShiftKey:
                    returnWord = "+";
                    break;
                case KEYCODETYPE.Menu:
                    returnWord = "%";
                    break;
                case KEYCODETYPE.Tab:
                    returnWord = "{TAB}";
                    break;
                case KEYCODETYPE.Escape:
                    returnWord = "{ESC}";
                    break;
                case KEYCODETYPE.Space:
                    returnWord = "";
                    break;
                case KEYCODETYPE.Return:
                    returnWord = "{ENTER}";
                    break;
                case KEYCODETYPE.Up:
                    returnWord = "{UP}";
                    break;
                case KEYCODETYPE.Down:
                    returnWord = "{DOWN}";
                    break;
                case KEYCODETYPE.Left:
                    returnWord = "{LEFT}";
                    break;
                case KEYCODETYPE.Right:
                    returnWord = "{RIGHT}";
                    break;
                case KEYCODETYPE.F1:
                    returnWord = "{F1}";
                    break;
                case KEYCODETYPE.F2:
                    returnWord = "{F2}";
                    break;
                case KEYCODETYPE.F3:
                    returnWord = "{F3}";
                    break;
                case KEYCODETYPE.F4:
                    returnWord = "{F4}";
                    break;
                case KEYCODETYPE.F5:
                    returnWord = "{F5}";
                    break;
                case KEYCODETYPE.F6:
                    returnWord = "{F6}";
                    break;
                case KEYCODETYPE.F7:
                    returnWord = "{F7}";
                    break;
                case KEYCODETYPE.F8:
                    returnWord = "{F8}";
                    break;
                case KEYCODETYPE.F9:
                    returnWord = "{F9}";
                    break;
                case KEYCODETYPE.F10:
                    returnWord = "{F10}";
                    break;
                case KEYCODETYPE.F11:
                    returnWord = "{F11}";
                    break;
                case KEYCODETYPE.F12:
                    returnWord = "{F12}";
                    break;
                case KEYCODETYPE.Home:
                    returnWord = "{HOME}";
                    break;
                case KEYCODETYPE.End:
                    returnWord = "{END}";
                    break;
                case KEYCODETYPE.PageUp:
                    returnWord = "{PGUP}";
                    break;
                case KEYCODETYPE.Next:
                    returnWord = "{PGDN}";
                    break;
                case KEYCODETYPE.Back:
                    returnWord = "{BKSP}";
                    break;
                case KEYCODETYPE.Delete:
                    returnWord = "{DEL}";
                    break;
                case KEYCODETYPE.Capital:
                    returnWord = "{CAPSLOCK}";
                    break;
                case KEYCODETYPE.ADD:
                    returnWord = "{ADD}";
                    break;
                case KEYCODETYPE.SUBTRACT:
                    returnWord = "{SUBTRACT}";
                    break;
                case KEYCODETYPE.MULTIPLY:
                    returnWord = "{MULTIPLY}";
                    break;
                case KEYCODETYPE.DIVIDE:
                    returnWord = "{DIVIDE}";
                    break;
            }

            return returnWord.Trim(); 
        }

        private enum KEYCODETYPE
        {
            ControlKey,
            LWin,
            RWin,
            ShiftKey,
            Menu,
            Tab,
            Escape,
            Space,
            Return,
            Up,
            Down,
            Left,
            Right,
            F1,
            F2,
            F3,
            F4,
            F5,
            F6,
            F7,
            F8,
            F9,
            F10,
            F11,
            F12,
            Home,
            End,
            PageUp,
            Next,
            Back,
            Delete,
            Capital,
            ADD,
            SUBTRACT,
            MULTIPLY,
            DIVIDE
        }
        private enum CmdType
        {
            /// <summary>
            /// 输入
            /// </summary>
            INPUT,

            /// <summary>
            /// 运行
            /// </summary>
            RUN,

            /// <summary>
            /// 按键
            /// </summary>
            KEY,

            /// <summary>
            /// 暂停
            /// </summary>
            SLEEP,

            /// <summary>
            /// 鼠标移动
            /// </summary>
            MOUSE_MOVE,

            /// <summary>
            /// 鼠标单击
            /// </summary>
            MOUSE_LEFT_CLICK,
            MOUSE_RIGHT_CLICK,

            /// <summary>
            /// 鼠标双击
            /// </summary>
            MOUSE_DBCLICK,

            /// <summary>
            /// 窗口截屏
            /// </summary>
            SCREEN,

            /// <summary>
            /// 全屏截屏
            /// </summary>
            ALL_SCREEN
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = RUN_WAIT;
            lblInfo.Text = string.Format("{0}/{1} {2}", codeIndex + 1, codeList.Count, codeList[codeIndex]);
            string code = codeList[codeIndex];
            int split = code.IndexOf(':');
            string codeType = "";
            string codeContent = "";
            if (split > 0)
            {
                codeType = code.Substring(0, split);
                codeContent = code.Substring(split + 1);
            }
            else
            {
                codeType = code;
            }
            codeType = codeType.Trim().ToUpper();
            if (Enum.IsDefined(typeof(CmdType), codeType))
            {
                try
                {
                    CmdType cmdType = (CmdType)Enum.Parse(typeof(CmdType), codeType);
                    switch (cmdType)
                    {
                        case CmdType.INPUT:
                            cmdInput(codeContent);
                            break;
                        case CmdType.RUN:
                            cmdRun(codeContent);
                            break;
                        case CmdType.KEY:
                            cmdKey(codeContent);
                            break;
                        case CmdType.SLEEP:
                            cmdSleep(codeContent);
                            break;
                        case CmdType.MOUSE_MOVE:
                            cmdMouseMove(codeContent);
                            break;
                        case CmdType.MOUSE_LEFT_CLICK:
                            cmdMouseClick(1);
                            break;
                        case CmdType.MOUSE_RIGHT_CLICK:
                            cmdMouseClick(2);
                            break;
                        case CmdType.MOUSE_DBCLICK:
                            cmdMouseDBClick();
                            break;
                        case CmdType.SCREEN:
                            cmdScreen();
                            break;
                        case CmdType.ALL_SCREEN:
                            cmdAllScreen();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    button11_Click(null, null);
                    MessageBox.Show("Code[" + code + "]が失敗\r\n\r\n失敗原因：" + ex.Message, "失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            codeIndex++;
            if (codeIndex == codeList.Count)
            {
                if(labelRunTimesCount.Text.Equals(textBoxRunTimes.Text) == true)
                {
                    button11_Click(null, null);
                }
                else
                {
                    button8_Click(null, null);
                }
            }
            else
            {
                timer1.Start();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            labelRunTimesCount.Text = (int.Parse(labelRunTimesCount.Text) + 1).ToString();

            RUN_WAIT = (int)(float.Parse(this.textBoxOnceTime.Text) * 1000);

            if (textBoxCmd.Text == "")
            {
                return;
            }
            codeList = new List<string>();
            codeIndex = 0;
            foreach (string r in textBoxCmd.Text.Split('\r'))
            {
                if (r.Trim() != "")
                {
                    codeList.Add(r.Trim());
                }
            }

            if(StartIndex >0)
            {
                lblInfo.Text = StartIndex.ToString() + "秒後起動!";
            }
            
            timer2.Interval = 1000;
            timer2.Start();
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            int x = Control.MousePosition.X;
            int y = Control.MousePosition.Y;
            labelMouse.Text = string.Format("({0},{1})", x, y);

            Rectangle rect = Screen.PrimaryScreen.Bounds;
            using (Bitmap bmp = new Bitmap(1, 1))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(x, y, 0, 0, new Size(1, 1));
                }
                labelColor.BackColor = bmp.GetPixel(0, 0);
                labelRGB.Text = string.Format("(RGB:{0},{1},{2})", labelColor.BackColor.R, labelColor.BackColor.G, labelColor.BackColor.B);
            }

            timer3.Start();
        }


        #region 命令
        private void cmdInput(string str)
        {
            Clipboard.Clear();
            Clipboard.SetText(str);
            SendKeys.SendWait("^v");
        }
        private void cmdRun(string str)
        {
            Process.Start(str);
        }
        private void cmdKey(string str)
        {
            SendKeys.SendWait(str);
        }
        private void cmdSleep(string str)
        {
            int t = 0;
            if (int.TryParse(str, out t))
            {
                if (t > RUN_WAIT)
                {
                    timer1.Interval = t;
                }
            }
        }
        private void cmdScreen()
        {
            Clipboard.Clear();
            SendKeys.SendWait("{PRTSC}");
            if (Clipboard.ContainsImage())
            {
                Image img = Clipboard.GetImage();
                savePic(img);
                img.Dispose();
                Clipboard.Clear();
            }
        }
        private void cmdAllScreen()
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            using (Bitmap bmp = new Bitmap(rect.Width, rect.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(0, 0, 0, 0, new Size(rect.Width, rect.Height));
                }
                savePic(bmp);
            }
        }
        private void savePic(Image img)
        {
            string strScreenPath = Application.StartupPath + "\\SCREEN\\";
            if (!System.IO.Directory.Exists(strScreenPath))
            {
                System.IO.Directory.CreateDirectory(strScreenPath);
            }
            img.Save(strScreenPath + Guid.NewGuid().ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }

        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000,
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr ext);

        private void cmdMouseMove(string str)
        {
            string[] strs = str.Split(',');
            if (strs.Length == 2)
            {
                int x = int.Parse(strs[0]);
                int y = int.Parse(strs[1]);
                Cursor.Position = new Point(x, y);
            }
        }
        private void cmdMouseClick(int leftOrRight)
        {
            if (leftOrRight == 1)
            {
                mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
                mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
            }
            else
            {
                mouse_event(MouseEventFlag.RightDown, 0, 0, 0, UIntPtr.Zero);
                mouse_event(MouseEventFlag.RightUp, 0, 0, 0, UIntPtr.Zero);
            }
            
        }
        private void cmdMouseDBClick()
        {
            cmdMouseClick(1);
            cmdMouseClick(1);
        }
        #endregion

        private void button11_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            labelRunTimesCount.Text = "0";
            StartIndex = 5;
            button8.Enabled = true;
            lblInfo.Text = "About Me";
            MessageBox.Show("実行完成しました!", "AutoMarcoRunMain");
        }

        private void listBoxCmd_DoubleClick(object sender, EventArgs e)
        {
            string[] strCmdList = listBoxCmd.SelectedItem.ToString().Split('-');

            if(strCmdList.Length >= 2)
            {
                string strCmd = strCmdList[1].Trim();
                textBoxCmd.AppendText(strCmd + "\r\n");
            }
            
        }

        private void AutoMacroRunMain_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("AAA:" +e.KeyData);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Equals("A, Control") == true)
            {
                int x = Control.MousePosition.X;
                int y = Control.MousePosition.Y;
                textBox6MouseX.Text = x.ToString();
                textBox7MouseY.Text = y.ToString();
            }

            //F2, Controlを押した場合、強制停止
            if (keyData.ToString().Equals("F2, Control") == true)
            {
                button11_Click(null, null);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lblInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(null == aboutMeWin)
            {
                aboutMeWin = new AboutMe();
            }
            aboutMeWin.ShowDialog();
        }
    }
}
