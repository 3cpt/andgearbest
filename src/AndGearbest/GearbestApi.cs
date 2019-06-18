namespace AndGearbest
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using AndGearbest.Client;
    using AndGearbest.Defaults;
    using AndGearbest.Models;
    using Newtonsoft.Json;

    public sealed class GearbestApi : IGearbestApi
    {
        private const string couponResource = "/coupon/list-coupons";
        private const string productCreativeResource = "/promotions/list-product-creative";
        private const string eventCreativeResource = "/banner/list-event-creative";
        private const string promotionProductResource = "/products/list-promotion-products";
        private const string completedOrdersResource = "/orders/completed-orders";

        private readonly RequestBase requestBase;
        private static GearbestApi gearbestApi;

        public GearbestApi(string apiKey, string secretKey, string lkid)
        {
            if (this.requestBase == null)
            {
                this.requestBase = new RequestBase(apiKey, secretKey, lkid);
            }
        }

        public static GearbestApi GetGearbestApi(string apiKey, string secretKey, string lkid = null)
        {
            // todo : verify also the key and secret
            if (gearbestApi == null)
            {
                gearbestApi = new GearbestApi(apiKey, secretKey, lkid);
            }

            return gearbestApi;
        }

        public async Task<ResponseData<Coupon>> GetCouponsAsync(Category category, LanguageType languageType, int page)
        {
            // coupon/list-coupons?api_key=[APIkey]&time=[time]&language=[language]&category=[category]&page=[page]&sign=[Signature]&lkid=[lkid]

            var ticks = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).Ticks;

            var arguments = new Dictionary<string, string>
            {
                { "time", ticks.ToString() },
                { "page", page.ToString() }
            };

            if (category != Category.None)
            {
                arguments.Add("category", ((int)category).ToString());
            }

            if (languageType != LanguageType.none)
            {
                arguments.Add("language", languageType.ToString());
            }

            var request = requestBase.PrepareRequest(couponResource, HttpMethod.Get, arguments);
            var response = await requestBase.GetAsync(request);

            try
            {
                return JsonConvert.DeserializeObject<ResponseData<Coupon>>(response);
            }
            catch (JsonSerializationException)
            {
                var aa = JsonConvert.DeserializeObject<object>(response, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public class WrapperObject
        {
            public object[] messages { get; set; }
        }

        public async Task<ResponseData<ProductCreative>> GetProductCreativeAsync(ProductCreativeType productCreativeType, int page = 1)
        {
            // promotions/list-product-creative?api_key=[APIkey]&time=[time]&type=[type]&category=[category]&page=[page]&sign=[Signature]&lkid=[lkid]

            var arguments = new Dictionary<string, string>
            {
                { "time", Utils.CurrentTicks() },
                { "type", productCreativeType.ToString("D") },
                { "page", page.ToString() }
            };

            var request = requestBase.PrepareRequest(productCreativeResource, HttpMethod.Get, arguments);
            var response = await requestBase.GetAsync(request);

            return JsonConvert.DeserializeObject<ResponseData<ProductCreative>>(response);
        }

        public async Task<ResponseData<EventCreative>> GetEventCreativeAsync(EventType eventType, int page = 1)
        {
            // banner/list-event-creative?api_key=[APIkey]&time=[time]&type=[type]&category=[category]&language=[language]&size=[size]&page=[page]&sign=[Signature]&lkid=[lkid]

            var arguments = new Dictionary<string, string>
            {
                { "time", Utils.CurrentTicks() },
                { "type", eventType.ToString("D") },
                { "page", page.ToString() }
            };

            var request = requestBase.PrepareRequest(eventCreativeResource, HttpMethod.Get, arguments);
            var response = await requestBase.GetAsync(request);

            return JsonConvert.DeserializeObject<ResponseData<EventCreative>>(response);
        }

        public async Task<ResponseData<PromotionProduct>> GetPromotionProductAsync(CurrencyType currencyType, int page = 1)
        {
            // products/list-promotion-products?api_key=[yourAPIkey]&time=[time]&lkid=[yourlinkid]&currency=[currency]&page=[page]&sign=[signature]

            var arguments = new Dictionary<string, string>
            {
                { "time", Utils.CurrentTicks() },
                { "currency", currencyType.ToString() },
                { "page", page.ToString() }
            };

            var request = requestBase.PrepareRequest(promotionProductResource, HttpMethod.Get, arguments);
            var response = await requestBase.GetAsync(request);

            return JsonConvert.DeserializeObject<ResponseData<PromotionProduct>>(response);
        }

        public async Task<ResponseData<CompletedOrder>> GetCompletedOrderAsync(DateTime startDate, DateTime endDate, int page = 1)
        {
            // orders/completed-orders?api_key=[APIkey]&time=[time]&start_date=[startDate]&end_date=[endDate]&page=[page]&sign=[Signature]

            var arguments = new Dictionary<string, string>
            {
                { "time", Utils.CurrentTicks() },
                { "start_date", startDate.ToString("yyyy-MM-dd") },
                { "end_date", endDate.ToString("yyyy-MM-dd") },
                { "page", page.ToString() }
            };

            var request = requestBase.PrepareRequest(completedOrdersResource, HttpMethod.Get, arguments);
            var response = await requestBase.GetAsync(request);

            return JsonConvert.DeserializeObject<ResponseData<CompletedOrder>>(response);
        }
    }
}