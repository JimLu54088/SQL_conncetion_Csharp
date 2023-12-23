using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Mysql_exercise;
using Newtonsoft.Json;

public class TorihikisakiDao : CommonDao
{
    // 由於我們在 `CommonDao` 中已經定義了 MySqlConnection 和 MySqlCommand，這裡不需要再定義

    public List<Dto> SelectTorihikisakiMain()
    {
        try
        {
            // Connect to DB
            Connect();

            string sql = $"SELECT * FROM sex";

            // Execute SQL and get result
            MySqlDataReader rs = ExecuteQuery(sql);

            // Create a list for data storage
            List<Dto> resultList = new List<Dto>();

            // Retrieve data from the result set
            while (rs.Read())
            {
                Dto dto = new Dto();

                dto.Sid = rs.GetInt32("sid");
                dto.Sname = rs.GetString("sname");




                resultList.Add(dto);
            }

            return resultList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            throw new InvalidOperationException(e.Message);
        }
        finally
        {
            // Disconnect from DB
            Disconnect();
        }
    }


    static void Main(string[] args)
    {
        List<Dto> al = new List<Dto>();

        Console.WriteLine("yyy");
        TorihikisakiDao dao = new TorihikisakiDao();

        al = dao.SelectTorihikisakiMain();
        Console.WriteLine(JsonConvert.SerializeObject(al));

        Console.ReadLine();

    }





}


