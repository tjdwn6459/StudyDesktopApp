﻿using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}