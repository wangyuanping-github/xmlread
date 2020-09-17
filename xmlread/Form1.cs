using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace xmlread
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }            


        private void Form1_Load(object sender, EventArgs e)
        {
            //string command = Environment.CommandLine;//获取进程命令行参数
            //string[] para = command.Split('\"');
            //if (para.Length > 3)
            //{
            //    path.my_path = para[3];//获取打开的文件的路径
            //                           //下面就可以自己编写代码使用这个pathC参数了
            //                           //FileStream fs = new FileStream(pathC, FileMode.Open, FileAccess.Read);
            //}
            label1.Text = path.my_path;

            outputtBox.Clear();
            //实例化一个XmlDocument对象
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                //实例对象读取要写入的XML文件
                xmlDoc.Load(path.my_path);
                //UXMLFormat.UXMLFormat();
                string my_xml = UXMLFormat.ConvertXmlDocumentTostring(xmlDoc);
                outputtBox.AppendText(my_xml);
            }
            catch 
            { }


        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)

        {
            path.my_path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            label1.Text = path.my_path;

            outputtBox.Clear();
            //实例化一个XmlDocument对象
            XmlDocument xmlDoc = new XmlDocument();
            //实例对象读取要写入的XML文件
            try
            {
                xmlDoc.Load(path.my_path);
                //UXMLFormat.UXMLFormat();
                string my_xml = UXMLFormat.ConvertXmlDocumentTostring(xmlDoc);
                outputtBox.AppendText(my_xml);
            }
            catch { }



            //XmlNode node = xmlDoc.DocumentElement;


            //XmlNodeList firstnode = node.ChildNodes; //获取子节点
            //                                         //int i1 = firstnode.Count;
            //                                         //outputtBox.AppendText(Convert.ToString(i1));



            //foreach (XmlNode xnl in firstnode)
            //{
            //    //outputtBox.AppendText(xnl.Name+":   :");//显示节点点文本
            //    //outputtBox.AppendText(xnl.InnerText);//显示节点点文本
            //    //outputtBox.AppendText("\r\n");//显示子节点点文

            //    XmlNodeList xnf = xnl.ChildNodes;
            //    foreach (XmlNode xml1 in xnf)
            //    {
            //        outputtBox.AppendText(xml1.Name + ":   :");//显示节点点文本
            //        outputtBox.AppendText(xml1.InnerText);//显示节点点文本
            //        outputtBox.AppendText("\r\n");//显示子节点点文

            //    }


            //}






        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void outputtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class UXMLFormat
    {
        public static string FormatXML(string XMLstring)
        {
            //校验是否是XML报文
            if (!XMLstring.Contains("<?xml version")) return XMLstring;
            XmlDocument xmlDocument = GetXmlDocument(XMLstring);
            return ConvertXmlDocumentTostring(xmlDocument);
        }

        public static string ConvertXmlDocumentTostring(XmlDocument xmlDocument)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(memoryStream, null)
            {
                Formatting = Formatting.Indented//缩进
            };
            xmlDocument.Save(writer);
            StreamReader streamReader = new StreamReader(memoryStream);
            memoryStream.Position = 0;
            string xmlString = streamReader.ReadToEnd();
            streamReader.Close();
            memoryStream.Close();
            return xmlString;
        }
        public static XmlDocument GetXmlDocument(string xmlString)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlString);
            return document;
        }
    }
    
}
