using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WazeCreditApp.Models;
using WazeCreditApp.Models.ViewModels;
using WazeCreditApp.Service;

namespace WazeCreditApp.Controllers;

public class HomeController : Controller
{
    public HomeVM homeVm { get; set; }
    private readonly IMarketForecaster _marketForecaster;

    public HomeController(IMarketForecaster marketForecaster)
    {
        homeVm = new HomeVM();
        _marketForecaster = marketForecaster;
    }

    public IActionResult Index()
    {
        HomeVM homeVm = new HomeVM();
        MarketResult currentMarket = _marketForecaster.GetMarketPrediction();

        switch (currentMarket.MarketCondition)
        {
            case EMarketCondition.StableDown:
                homeVm.MarketForecast =
                    "Market shows signs to go down in a stabel state applications! But extra credit is always piece of mind if you have handy when you need it.";
                break;
            case EMarketCondition.StableUp:
                homeVm.MarketForecast = "Market shows signs to go up in a stabel state!";
                break;
            case EMarketCondition.Volatile:
                homeVm.MarketForecast = "Market shows signs of volatility.";
                break;
            default:
                homeVm.MarketForecast = "Apply for credit card using our application!";
                break;
        }
        return View(homeVm);
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
}