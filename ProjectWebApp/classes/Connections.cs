using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace ProjectWebApp.classes
{
   public static class Connections
    {
        public static SqlConnection GetConeection()
        {
            

            string fileName = "ProjectDB.mdf";
            string pathToFile = AppDomain.CurrentDomain.BaseDirectory + $"\\{fileName}";
            string filePath = Path.GetFullPath(pathToFile).Replace(@"\bin\Debug\netcoreapp3.1", @"\Data");
            //string filePath = Path.GetFullPath(fileName);
            //string strCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={filePath};Integrated Security=True";
            return new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={filePath};Integrated Security=True");
        }
    }
}
