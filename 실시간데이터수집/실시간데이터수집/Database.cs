using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 실시간데이터수집
{
    class Database
    {
        public static SQLiteConnection conn = null;
        public static SQLiteTransaction transaction;
        public static SQLiteCommand cmd = new SQLiteCommand();

        public static void DBConnect()
        {
            Console.WriteLine("DB 연결");
            string strConn = "Data Source=C:\\chichi\\sqliteDB\\mydb.db";
            Console.WriteLine("strConn : " + strConn);

            conn = new SQLiteConnection(strConn);
            conn.Open();
        }
    }
}
