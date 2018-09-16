using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Analysis_String_Xml
{
    class Method
    {
        public void Insert_Text(TextBox textBox,string content)
        {
            int count = textBox.Text.Length;
            string get_box_text = textBox.Text;
            textBox.Text = get_box_text.Insert(count, content + "\r\n");
            //////自動卷軸到最底下
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
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
    }
}
