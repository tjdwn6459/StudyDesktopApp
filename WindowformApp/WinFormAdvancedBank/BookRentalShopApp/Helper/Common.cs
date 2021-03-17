using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalShopApp.Helper
{
    public static class Common
    {
        public static string ConnString = "Data Source=127.0.0.1;" +
            "Initial Catalog=bookrentalshop;" +
            "Persist Security Info=True;" +
            "User ID=sa;" +
            "Password=mssql_p@ssw0rd!";// 데이터 베이스 연결 문자열

        public static string LoginUserId = string.Empty;

        internal static object GetLocalIp()
        {
            string localIP = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress iP in host.AddressList)
            {
                if (iP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = iP.ToString();
                    break;
                }
            }

            return localIP;
        }
    }
}
