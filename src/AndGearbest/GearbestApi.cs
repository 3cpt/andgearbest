namespace AndGearbest
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using AndGearbest.Client;
    using AndGearbest.Models;
    using Newtonsoft.Json;

    public class GearbestApi : IGearbestApi
    {
        private const string couponsRootUrl = "/coupon/list-coupons";
        private readonly RequestBase requestBase;
        private static GearbestApi gearbestApi;

        private GearbestApi(string apiKey, string secretKey, string lkid)
        {
            if (this.requestBase == null)
            {
                this.requestBase = new RequestBase(apiKey, secretKey, lkid);
            }
        }

        public static GearbestApi GetGearbestApi(string apiKey, string secretKey, string lkid = null)
        {
            if (gearbestApi == null)
            {
                gearbestApi = new GearbestApi(apiKey, secretKey, lkid);
            }

            return gearbestApi;
        }

        public async Task<ResponseData<Coupon>> GetCouponsAsync(int page)
        {
            var ticks = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).Ticks;

            var arguments = new Dictionary<string, string>();
            arguments.Add("time", ticks.ToString());
            arguments.Add("page", page.ToString());

            var request = requestBase.PrepareRequest(couponsRootUrl, HttpMethod.Get, arguments);
            var response = await requestBase.GetAsync(request);

            return JsonConvert.DeserializeObject<ResponseData<Coupon>>(response);
        }
    }
}