

using System.Net.Security;

namespace services;
public static class ServiceExtensions
{
    public static void add(builder builder)
    {
        // 使用反射或手动列出所有需要注册的服务
        builder.Services.AddScoped<UserInfoDapper>();
    }
    public static void  hello()
    {
        Console.WriteLine("hellow");
    }
}