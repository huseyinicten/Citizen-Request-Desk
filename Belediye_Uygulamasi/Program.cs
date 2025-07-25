using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belediye_Uygulamasi
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            string server = "127.0.0.1";
            int port = 3306;
            string uid = "root";
            string password = "secret";
            string database = "hsyndb";


            while (true)
            {
                try
                {
                    GlobalDegiskenler.DB = new DB(server, port, uid, password, database);
                    GlobalDegiskenler.DB.Connect();
                    try
                    {
                        Application.Run(new MainSelectForm());
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch
                {
                    if (MessageBox.Show("Giriş yapılamadı" , "Çıkış yap", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        continue;
                    }
                    else { break; };
                }
            }



        }
    }
}
