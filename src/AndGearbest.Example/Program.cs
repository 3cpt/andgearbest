using System;
using AndGearbest.Defaults;

namespace AndGearbest.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var key = "";
                var secret = "";

                Console.WriteLine("Hello World!");

                IGearbestApi api = GearbestApi.GetGearbestApi(key, secret);

                var coupons = api.GetCouponsAsync().Result;

                var productCreative = api.GetProductCreativeAsync(ProductCreativeType.HottestDeals).Result;

                var events = api.GetEventCreativeAsync(EventType.TopBrands).Result;

                var promos = api.GetPromotionProductAsync(CurrencyType.USD).Result;

                var orders = api.GetCompletedOrderAsync(DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(1)).Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}