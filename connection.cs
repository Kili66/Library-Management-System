using System.Configuration;

namespace Myproject
{
    class connection
    {
        public static string sqlconnection = ConfigurationManager.ConnectionStrings["Library_Management_System _sqlconnection"].ConnectionString;
    }
}
