using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysql_exercise
{
    public class CommonDao
    {
        // 連接字串
        private static readonly string ConnectionString = @"Server=127.0.0.1;Database=csiisysdb3;User ID=root;Password=1234;Charset=utf8;";

        // 保持資料庫的連接和命令
        private MySqlConnection con = null;
        private MySqlCommand cmd = null;

        // 連接資料庫
        public void Connect()
        {
            try
            {
                con = new MySqlConnection(ConnectionString);
                con.Open();
                cmd = new MySqlCommand();
                cmd.Connection = con;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new InvalidOperationException(e.Message);
            }
        }

        // 斷開資料庫連接
        public void Disconnect()
        {
            if (cmd != null)
            {
                cmd.Dispose();
            }

            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
        }

        // 執行查詢
        public MySqlDataReader ExecuteQuery(string sql)
        {
            try
            {
                cmd.CommandText = sql;
                return cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new InvalidOperationException(e.Message);
            }
        }

        // 執行更新
        public int ExecuteUpdate(string sql)
        {
            try
            {
                cmd.CommandText = sql;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}
