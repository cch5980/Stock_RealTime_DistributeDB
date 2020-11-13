using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 실시간데이터수집
{
    class DB_Config
    {
        private static SQLiteConnection conn = null;

        public static SQLiteConnection GetDBConnection()
        {
            if(conn != null)
            {
                return conn;
            } else
            {
                Console.WriteLine("DB 연결");
                string strConn = "Data Source=C:\\chichi\\sqliteDB\\mydb.db";
                conn = new SQLiteConnection(strConn);
                conn.Open();
                return conn;
            }           
        }

        public static void DisConnection()
        {
            if (conn != null) conn.Close();
        }

    }
}
