using System;

namespace AndGearbest.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IGearbestApi api = GearbestApi.GetGearbestApi("", "", "aaaa");

            var result = api.GetCouponsAsync(1);

            var coupons = result.Result;

            IGearbestApi api3 = GearbestApi.GetGearbestApi("", "");
        }
    }
}