using System;
using util;
using entity;
namespace Case;

public class SQLiteCase1
{
    public static void Run()
    {
        string Sql = "select * from userinfo";

        SqlUtil sqlUtil = new()
        {
            Sql = Sql
        };

        //参数
        Dictionary<String, Object> Params = [];
        Params.Add("name", "am");
        Params.Add("age", 23);
        List<object[]> result = sqlUtil.Query(Params);
        //展示结果
        Console.WriteLine("------遍历的结果-----------");
        foreach (object[] Key in result)
        {
            for (int i = 0; i < Key.Length; i++)
            {
                Console.WriteLine(Key[i].ToString());
            }
        }

        List<UserInfo> users = [];
        //用实体类接收结果
        Console.WriteLine("------实体类接收-----------");
        foreach (object[] Key in result)
        {
            UserInfo user = new()
            {
                Id = Convert.ToInt32(Key[0]),
                Name = Key[1].ToString(),
                Age = Convert.ToInt32(Key[2])
            };
            users.Add(user);
        }
        //重写实体类toString方法后可用
        string usersString = string.Join("\n", users);
        Console.WriteLine(usersString);
        // 程序逻辑代码
    }
}