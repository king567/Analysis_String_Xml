using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using YandexTranslateCSharpSdk;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace Analysis_String_Xml
{
    public partial class Form1 : Form
    {
        string English_Xml_Path = "";
        string Chinese_Xml_Path = "";
        string Api_Key = "";
        Method method = new Method();
        public class SearchResult
        {
            public string text { get; set; }
        }
        //region 無邊框拖動效果
        [DllImport("user32.dll")]//拖動無窗體的控件
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        public void Start_MouseDown(object sender, MouseEventArgs e)
        {
            //拖動窗體
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        //endregion
        public Form1()
        {
            InitializeComponent();
        }

        public async void Translate_Xml()
        {
            YandexTranslateSdk wrapper = new YandexTranslateSdk
            {
                ApiKey = Api_Key
            };
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(English_Xml_Path);
            XmlNodeList NodeLists = XmlDoc.SelectNodes("resources/string");
            method.Insert_Text(textBox1,"<?xml" + @" " + @"version=" + @"""" + "1.0" + @"""" + @" " + "encoding =" + @"""" + "utf-8" + @"""" + "?>");
            method.Insert_Text(textBox1, "<resources>");
            foreach (XmlNode OneNode in NodeLists)
            {
                string English_Xml_Value = OneNode.InnerText;
                string English_Xml_Name = OneNode.Attributes["name"].Value;
                Regex Find_String_Variable = new Regex(@"(\$|%)[0-9A-Za-z]");
                Match m = Find_String_Variable.Match(English_Xml_Value);
                try
                { 
                    if (m.Success)
                    {
                        method.Insert_Text(textBox1, "<string" + @" " + "name" + @" " + "=" + @"""" + English_Xml_Name + @"""" + ">" + English_Xml_Value + @"</string>");
                    }
                    else if (English_Xml_Value == null)
                    {
                        method.Insert_Text(textBox1, "<string" + @" " + "name" + @" " + "=" + @"""" + English_Xml_Name + @"""" + ">" + English_Xml_Value + @"</string>");
                    }
                    else
                    {
                        string TranslatedText = await wrapper.TranslateText(English_Xml_Value, "zh");
                        method.Insert_Text(textBox1, "<string" + @" " + "name" + @" " + "=" + @"""" + English_Xml_Name + @"""" + ">" + method.Taiwan_transle_api(TranslatedText) + @"</string>");
                    }
                }
                catch
                {
                    method.Insert_Text(textBox1, "<string" + @" " + "name" + @" " + "=" + @"""" + English_Xml_Name + @"""" + ">" + English_Xml_Value + @"</string>");
                }
            }
            method.Insert_Text(textBox1, "</resources>");
        }
        private void Get_Content_Bt_ClickAsync(object sender, EventArgs e)
        {
            Translate_Xml();
        }

        private void Save_To_Xml_Click(object sender, EventArgs e)
        {
            
            // This text is added only once to the file.
            if (!File.Exists(Chinese_Xml_Path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(Chinese_Xml_Path))
                {
                    sw.WriteLine(textBox1.Text);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(Chinese_Xml_Path, false))
                {
                    writer.WriteLine(textBox1.Text);
                }
            }
        }

        private void File_Path_Box_TextChanged(object sender, EventArgs e)
        {
            English_Xml_Path = File_Path_Box.Text;
        }

        private void Save_Path_Box_TextChanged(object sender, EventArgs e)
        {
            Chinese_Xml_Path = Save_Path_Box.Text;
        }

        private void Select_File_Path_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "strings|*.xml"
            };
            file.ShowDialog();
            if (file.FileName.ToString() == "")
            { }
            else
            {
                File_Path_Box.Text = file.FileName.ToString();
            }
        }

        private void Select_Save_Path_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "strings_chinese|*.xml"
            };
            file.ShowDialog();
            if (file.FileName.ToString() == "")
            { }
            else
            {
                Save_Path_Box.Text = file.FileName.ToString();
            }
        }

        private void Api_Key_Box_TextChanged(object sender, EventArgs e)
        {
            Api_Key = Api_Key_Box.Text;
        }
    }
}
