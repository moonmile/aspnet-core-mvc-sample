using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SampleSessionMvc.Models;

namespace SampleSessionMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        this.HttpContext.Session.SetString("now", DateTime.Now.ToString());
        this.HttpContext.Response.Cookies.Append("my-cookie", DateTime.Now.AddDays(100).ToString());
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    // 内部のフィールド変数
    private string _data = "";
    public IActionResult First()
    {
        // フィールド変数に保存する
        _data = DateTime.Now.ToString();
        ViewData["data"] = _data;
        ViewData["hash"] = this.GetHashCode().ToString("X");
        return View();
    }
    public IActionResult Second()
    {
        // フィールド変数は保存されていない
        ViewData["data"] = _data;
        ViewData["hash"] = this.GetHashCode().ToString("X");
        return View();
    }
}
