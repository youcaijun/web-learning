
using System.Data.SQLite;
namespace util;

public class SqlUtil
{
    static readonly string connectionString = "Data Source=study.db;Version=3;";
    public string? Sql { get; set; }
    public List<object[]> Query(Dictionary<String, Object> Params)
    {
        List<object[]> result = [];
        // 处理sql
        Sql += " where 1=1 ";
        //动态sql
        foreach (var key in Params.Keys)
        {
            Sql += $" and {key} = @{key}";
        }
        //Console.WriteLine($"sql是：{Sql}");
        //连接
        using var connection = new SQLiteConnection(connectionString);
        connection.Open();
        using (var command = new SQLiteCommand(Sql, connection))
        {
            
            foreach (var key in Params.Keys)
            {
                command.Parameters.AddWithValue($"@{key}", Params[key]);
            }
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                object[] values = new object[reader.FieldCount];
                //reader.GetValues(values); // 填充数组
                reader.GetValues(values);
                result.Add(values);
            }
            //赋值
        }

        return result;
    }

}





