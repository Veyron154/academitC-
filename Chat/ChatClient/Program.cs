using System;
using System.Configuration;
using System.Windows.Forms;
using ChatClient.View;

namespace ChatClient
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var port = int.Parse(ConfigurationManager.AppSettings["port"]);
            var host = ConfigurationManager.AppSettings["host"];

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatForm(port, host));
        }
    }
}
