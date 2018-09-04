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

namespace Analysis_String_Xml
{
    public partial class Form1 : Form
    {
        string English_Xml_Path = "";
        string Chinese_Xml_Path = "";
        string Api_Key = "";
        public class SearchResult
        {
            public string text { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }
        public void Insert_Text(string content)
        {
            int count = textBox1.Text.Length;
            string get_box_text = textBox1.Text;
            textBox1.Text = get_box_text.Insert(count, content + "\r\n");
            //////自動卷軸到最底下
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }
        public string Taiwan_transle_api(string Context)
        {
            string Api_Url = @"https://api.zhconvert.org/convert?";
            string Converter_Parameter = @"converter=" + "Taiwan";
            string Json_Format = @"&prettify=" + "1";
            string Translate_Text = @"&text=" + Context;
            string Full_Url = Api_Url + Converter_Parameter + Json_Format + Translate_Text;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Full_Url);
            request.Timeout = 10000;
            request.Method = "GET";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Windows NT 5.2; Windows NT 6.0; Windows NT 6.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; MS-RTC LM 8; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET CLR 4.0C; .NET CLR 4.0E)";
            HttpWebResponse webresponse = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(webresponse.GetResponseStream(), Encoding.UTF8);
            string retString = streamReader.ReadToEnd();
            webresponse.Close();
            streamReader.Close();

            JObject Search_Json = JObject.Parse(retString);
            string Chinese_Text = (string)Search_Json["data"]["text"];
            return Chinese_Text;
        }
        public async void Translate_Xml()
        {
            YandexTranslateSdk wrapper = new YandexTranslateSdk();
            wrapper.ApiKey = Api_Key;
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(English_Xml_Path);
            XmlNodeList NodeLists = XmlDoc.SelectNodes("resources/string");
            Insert_Text("<?xml" + @" " + @"version=" + @"""" + "1.0" + @"""" + @" " + "encoding =" + @"""" + "utf-8" + @"""" + "?>");
            Insert_Text("<resources>");
            foreach (XmlNode OneNode in NodeLists)
            {
                string English_Xml_Value = OneNode.InnerText;
                string English_Xml_Name = OneNode.Attributes["name"].Value;
                Regex Find_String_Variable = new Regex(@"(\$|%)[0-9A-Za-z]");
                Match m = Find_String_Variable.Match(English_Xml_Value);
                if (m.Success)
                {
                    Insert_Text("<string" + @" " + "name" + @" " + "=" + @"""" + English_Xml_Name + @"""" + ">" + English_Xml_Value + @"</string>");
                }
                else
                {
                    string TranslatedText = await wrapper.TranslateText(English_Xml_Value, "zh");
                    Insert_Text("<string" + @" " + "name" + @" " + "=" + @"""" + English_Xml_Name + @"""" + ">" + Taiwan_transle_api(TranslatedText) + @"</string>");
                }
            }
            Insert_Text("</resources>");
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
