using System;
using System.Linq;
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

                var coupons = api.GetCouponsAsync(Category.CellPhones, LanguageType.po).Result;
                
                //foreach (var c in coupons.Data.Items.GroupBy(c => c.Language))
                //{
                //    Console.WriteLine(c.Key);
                //}

                if (false)
                {
                    var productCreative = api.GetProductCreativeAsync(ProductCreativeType.HottestDeals).Result;

                    var events = api.GetEventCreativeAsync(EventType.TopBrands).Result;

                    var promos = api.GetPromotionProductAsync(CurrencyType.USD).Result;

                    var orders = api.GetCompletedOrderAsync(DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(1)).Result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}