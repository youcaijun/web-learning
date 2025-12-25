
using System.Data.SQLite; // 注意这里是 System.Data.SQLite，不是 Microsoft.Data.Sqlite 或其他。
namespace util;

public class OtherClass
{
    static readonly string connectionString = "Data Source=study.db;Version=3;";
    public static void Run()
    {
        //var connectionString = "Data Source=study.db;Version=3;"; // SQLite数据库文件路径和版本号
        using var connection = new SQLiteConnection(connectionString);
        connection.Open();
        string sql = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)";
        using (var command = new SQLiteCommand(sql, connection))
        {
            command.ExecuteNonQuery(); // 使用 ExecuteNonQuery 而非 ExecuteReader 对于创建表和插入数据。
        }

        sql = "INSERT INTO users (name) VALUES (@name)";
        using (var command = new SQLiteCommand(sql, connection))
        {
            command.Parameters.AddWithValue("@name", "Bob"); // 使用 Parameters 以防止 SQL 注入攻击。
            command.ExecuteNonQuery(); // 使用 ExecuteNonQuery 对于插入数据。
                                       // 查询部分与上面的类似，只是使用了 ExecuteReader。这里不再赘述。
        }
        Console.WriteLine("我是其他类");
    }

    public static void Select()
    {
        try
        {
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            //异常sql
            //string sql = "select * from user";
            //正常sql
            string sql = "select * from users";
            using var command = new SQLiteCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"捕获到异常: {ex.Message}");
        }
        Console.WriteLine("执行完毕");
    }
}





