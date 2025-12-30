using entity;
namespace register;

//使用配置类注册服务，扩展方法：必须是静态类的静态方法
public static class ServiceRegister
{
    public static void ConfigureServices(IServiceCollection services)
    {
        Console.WriteLine("注册服务..");
        services.AddScoped<UserInfoDapper>();
        // 其他服务注册
    }
}