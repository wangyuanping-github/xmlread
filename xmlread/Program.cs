using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xmlread
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {



            if (arg.Length > 0)
            {
                path.my_path = arg[0].ToString();
                //MessageBox.Show(path.my_path);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }




    }
   static class  path
        {
        static string my_Path;
       public static string my_path
        {
            get
            {
                return my_Path;
            }
            set
            {
                my_Path = value;
            }
        }
}
}