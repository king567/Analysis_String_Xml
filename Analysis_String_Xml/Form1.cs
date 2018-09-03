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

namespace Analysis_String_Xml
{
    public partial class Form1 : Form
    {
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
        private async void Get_Content_Bt_ClickAsync(object sender, EventArgs e)
        {
            YandexTranslateSdk wrapper = new YandexTranslateSdk();
            wrapper.ApiKey = "trnsl.1.1.20180826T084827Z.54e49a82ea8c2f4d.3459b97eef4275c517282942408b6e377c9bee8b";
            string xml_path = @"C:\Users\king0\Desktop\test\strings.xml";
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(xml_path);
            XmlNodeList NodeLists = XmlDoc.SelectNodes("resources/string");
            foreach (XmlNode OneNode in NodeLists)
            {
                String StrAttrValue = OneNode.InnerText;
                Regex regex = new Regex(@"(\$|%)[0-9A-Za-z]");
                Match m = regex.Match(StrAttrValue);
                if (m.Success)
                {
                    Insert_Text(StrAttrValue);
                }
                else
                {
                    string translatedText = await wrapper.TranslateText(StrAttrValue, "zh");
                    Insert_Text(translatedText);
                }
            }
        }
    }
}
