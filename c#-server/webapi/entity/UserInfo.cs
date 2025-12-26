using System.Data;
using System.Data.SQLite;
using Dapper;

namespace entity;

public class UserInfo
{
    //id
    public int Id { get; set; }
    //name
    public string? Name { get; set; }

    public int? Age { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}

public class UserInfoDapper
{
    string connectionString = "Data Source=study.db;Version=3;";

    //全表查询
    public List<UserInfo> GetAllUser()
    {
        using IDbConnection con = new SQLiteConnection(connectionString);
        con.Open();
        var result = con.Query<UserInfo>("select * from UserInfo").ToList();
        return result.ToList();

    }
    //参数查询
    public List<UserInfo> GetUserByParams(Dictionary<string, object> Params)
    {
        //处理参数
        var sql = "select id,name,age from UserInfo";
        // 处理sql
        sql += " where 1=1 ";
        //动态sql
        var parameters = new DynamicParameters();
        foreach (var key in Params.Keys)
        {
            sql += $" and {key} = @{key}";
            parameters.Add(key, Params[key]);
        }
        using IDbConnection con = new SQLiteConnection(connectionString);
        con.Open();
        List<UserInfo> result = con.Query<UserInfo>(sql, parameters).ToList();
        return result.ToList();
    }
    //非查询语句写法相同，多条新增，删除，更新；
    public Boolean Insert(List<UserInfo> users)
    {
        var sql = "insert into userinfo(id,name,age) values (null,@Name,@Age);";
        using IDbConnection con = new SQLiteConnection(connectionString);
        con.Open();
        int result = con.Execute(sql,users);
        return result>0;
    }
}





