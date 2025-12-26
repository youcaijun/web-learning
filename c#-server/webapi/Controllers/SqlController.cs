
namespace webapi.Controllers;
using entity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SqlController : ControllerBase
{
    private readonly UserInfoDapper _userInfoDapper;

    public SqlController(UserInfoDapper userInfoDapper)
    {
        _userInfoDapper = userInfoDapper;
    }
    //get请求
    [HttpGet(Name = "sqlget")]
    public string Get()
    {
        Console.WriteLine("被调用了");
        string hello = "hello,sqlget";
        return hello;
    }

    // post请求用实体类接收
    [HttpPost("postbyentity")]
    public string Post([FromBody] UserInfo user)
    {

        Console.Write(user.ToString());
        return user.ToString();
    }
    //post请求传入传入字典后接收
    [HttpPost("postbyDict")]
    public IActionResult Post([FromBody] Dictionary<string, object> Params)
    {


        // List<UserInfo> Queryresult2 = userInfoDapper.GetUserByParams(Params);
        // Console.Write(Queryresult2.ToString());
        // return Params;
        Dictionary <string, object> newParms=[];
        foreach (var kvp in Params)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            newParms.Add(kvp.Key,kvp.Value);
        }
        Console.WriteLine("-------------");
        //UserInfoDapper UserInfoDapper = new UserInfoDapper();
        List<UserInfo> Queryresult1 = _userInfoDapper.GetAllUser();
        foreach (UserInfo user in Queryresult1)
        {
            Console.WriteLine(user.ToString());
        }
        Console.WriteLine("-------------");
        
        List<UserInfo> Queryresult2 = _userInfoDapper.GetUserByParams(newParms);
        foreach (UserInfo user in Queryresult2)
        {
            Console.WriteLine(user.ToString());
        }
        return Ok(new { code = 200, message = "成功", data = "Queryresult2" });
    }
}
