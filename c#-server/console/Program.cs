using Case;
using entity;
//主启动类，可以直接跑
Console.WriteLine("主启动类");

//JDBC原生方法案例
//SQLiteCase1.Run();

//使用Daper框架
//全表查询
Console.WriteLine("全表查询：");
UserInfoDapper userInfoDapper = new();
List<UserInfo> Queryresult1 = userInfoDapper.getAllUser();
foreach (UserInfo user in Queryresult1)
{
    Console.WriteLine(user.ToString());
}
Console.WriteLine("条件查询：");
Dictionary<String, Object> Params = [];
Params.Add("name", "am");
Params.Add("age", 23);
List<UserInfo> Queryresult2 = userInfoDapper.getUserByParams(Params);
foreach (UserInfo user in Queryresult2)
{
    Console.WriteLine(user.ToString());
}
//非查询语句
Console.WriteLine("批量插入：");
List<UserInfo> insertParams1 = [
    new UserInfo { Name = "Alice", Age = 30 },
    new UserInfo { Name = "Bob", Age = 25 }
];
Boolean insertresult3 = userInfoDapper.Insert(insertParams1);

 Console.WriteLine("插入结果："+insertresult3);








