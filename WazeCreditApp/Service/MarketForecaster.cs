using WazeCreditApp.Models;

namespace WazeCreditApp.Service;

public class MarketForecaster : IMarketForecaster
{
    public MarketResult GetMarketPrediction()
    {
        // Call API to do some complex calculations end current stock market forecast
        // For course purpose we sill hard code the result
        return new MarketResult
        {
            MarketCondition = Models.EMarketCondition.StableUp
        };
    }
}