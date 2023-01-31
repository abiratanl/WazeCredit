using WazeCreditApp.Models;

namespace WazeCreditApp.Service;

public interface IMarketForecaster
{
    MarketResult GetMarketPrediction();
}