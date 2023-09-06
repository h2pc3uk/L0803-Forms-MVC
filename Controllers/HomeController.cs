using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using L0803.Models;

namespace L0803.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    //
    // public IActionResult Privacy()
    // {
    //     return View();
    // }
    //
    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }

    [HttpGet]
    public IActionResult GenerateFakeData(string account)
    {
        var repaymentMethods = new Dictionary<int, string>
        {
            { 1, "按期繳息到期還本" },
            { 2, "先收息後本息平均攤還" },
            { 3, "先收息後本金平均攤還" },
            { 4, "本息平均攤還" },
            { 5, "本金平均攤還" },
            { 6, "到期繳息還本" },
            { 7, "定額年金分償法" },
            { 9, "約定還本方式" }
        };
        
        Random random = new Random();
        int index = repaymentMethods.Keys.ElementAt(random.Next(repaymentMethods.Count));

        var fakeData = new
        {
            repaymentMethodsNumber = index.ToString(),
            repaymentMethodsDescription = repaymentMethods[index],
            installments = random.Next(1, 99).ToString(),
            loanPrincipalRepayment = random.Next(1000, 9999).ToString()
        };

        return Json(fakeData);

    }
}