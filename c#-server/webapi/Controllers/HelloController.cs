using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

//[Route("[controller]")],特殊名称，会按照控制器的名称取route
[ApiController]
[Route("xxx")]
public class HelloController : ControllerBase
{
    
    [HttpGet("hello1")]
    public string Get()
    {
        string hello = "hello,weibapi";
        return hello;
    }
}
