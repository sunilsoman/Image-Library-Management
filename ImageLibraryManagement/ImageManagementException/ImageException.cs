using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManagementException
{
    public class ImageException:ApplicationException
    {
        public ImageException()
        {
            LogError("unknown ERRor");
        }
        public ImageException(string message):base(message)
        {
            LogError(message);
        }
        public ImageException(string message, Exception inner)
            : base(message,inner)
        {
            LogError(message+inner);
        }


        static void  LogError(string message)
        {
            string fileName = ConfigurationManager.AppSettings["ErrorFile"];
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.WriteLine("ERROR" + message + "occured At" + DateTime.Now);
            writer.Flush();
            writer.Close();
        }
    }
}
