
namespace webapi.Controllers;
using entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;

[ApiController]
[Route("[controller]")]
public class SqlController : ControllerBase
{
    private readonly UserInfoDapper _userInfoDapper;

    public SqlController(UserInfoDapper userInfoDapper)
    {
        _userInfoDapper = userInfoDapper;
    }
    //get请求，url:/Sql/sqlget
    [HttpGet("sqlget")]
    // [HttpGet("sqlget")] url:/sqlget
    public string Sqlget()
    {
        Console.WriteLine("sqlget被调用了");
        string hello = "hello,sqlget";
        return hello;
    }

    // post请求用实体类接收，url:/postbyentity
    [HttpPost("/postbyentity")]
    public string Postbyentity([FromBody] UserInfo user)
    {
        Console.WriteLine("postbyentity被调用了");
        Console.Write(user.ToString());
        return user.ToString();
    }
    //post请求传入传入字典后接收,url:/postbyDict
    [HttpPost("/postbyDict")]
    public IActionResult PostbyDict([FromBody] Dictionary<string, object> Params)
    {


        // List<UserInfo> Queryresult2 = userInfoDapper.GetUserByParams(Params);
        // Console.Write(Queryresult2.ToString());
        // return Params;
        Console.WriteLine("postbyDict被调用了");
        Dictionary <string, object> newParms=[];
        foreach (var kvp in Params)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            newParms.Add(kvp.Key,  kvp.Value.ToString());
        }
        // Console.WriteLine("-------------");
        // //UserInfoDapper UserInfoDapper = new UserInfoDapper();
        // List<UserInfo> Queryresult1 = _userInfoDapper.GetAllUser();
        // foreach (UserInfo user in Queryresult1)
        // {
        //     Console.WriteLine(user.ToString());
        // }
        Console.WriteLine("-------------");
        
        List<UserInfo> Queryresult2 = _userInfoDapper.GetUserByParams(newParms);
        foreach (UserInfo user in Queryresult2)
        {
            Console.WriteLine(user.ToString());
        }
        string jsonString = JsonSerializer.Serialize(Queryresult2, new JsonSerializerOptions { WriteIndented = false });
        return Ok(new { code = 200, message = "成功", data = jsonString });
        //结果：jsonString：前端接收用，var JSONstring=JSON.parse(string);"{\"id\":1,\"Name\":\"am\"}";
    }
}
