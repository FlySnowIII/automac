using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoMacroRun
{
    partial class AboutMe : Form
    {
        public AboutMe()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = @"Windows自動操作ツール

コマンドフォマット: 「コマンド」 + 「:」 + 「バリュー」

コマンド一覧:
INPUT                     文字列入力(日本語可)
RUN                       コマンド実行(Win+R相当)
KEY                        キー操作
SLEEP                     一時停止
MOUSE_MOVE          マウス移動
MOUSE_LEFT_CLICK   マウス左クリック
MOUSE_RIGHT_CLICK  マウス右クリック
MOUSE_DBCLICK       マウスダブルクリック

キー操作説明(C# SendKeys.Send同様):
一般キー    a-z A-Z 0-9
Alt         %
Ctrl        ^
Shift       +
上向き矢印   {UP} 
下向き矢印   {DOWN}  
左向き矢印   {LEFT}  
右向き矢印   {RIGHT}  
Enter       {ENTER}
Backspace   {BACKSPACE}
Break       {BREAK}  
Caps Lock   {CAPSLOCK}  
Scroll Lock {SCROLLLOCK}  
Delete      {DELETE}
End         {END}  
Esc         {ESC}  
Help        {HELP}  
Home        {HOME}  
Insert      {INSERT}
Num Lock    {NUMLOCK}  
Page Down   {PGDN}  
Page Up     {PGUP}  
Tab         {TAB}  
F1-F16      {F1-F16} 
+           {ADD}  
-           {SUBTRACT} 
*           {MULTIPLY}  
/           {DIVIDE} 
重複キー {h 10}

湯　鵬飛 2016-3-11";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
