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

        public GearbestApi(string apiKey, string secretKey)
        {
            if (this.requestBase == null)
            {
                this.requestBase = new RequestBase(apiKey, secretKey, null);
            }
        }
        public GearbestApi(string apiKey, string secretKey, string lkid)
        {
            if (this.requestBase == null)
            {
                this.requestBase = new RequestBase(apiKey, secretKey, lkid);
            }
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

            return await HandleGetResquest<Coupon>(couponResource, arguments);
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

            return await HandleGetResquest<ProductCreative>(productCreativeResource, arguments);
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
            
            return await HandleGetResquest<EventCreative>(eventCreativeResource, arguments);
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

            return await HandleGetResquest<PromotionProduct>(promotionProductResource, arguments);
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

            return await HandleGetResquest<CompletedOrder>(completedOrdersResource, arguments);
        }

        private async Task<ResponseData<T>> HandleGetResquest<T>(string resource, Dictionary<string, string> arguments)
        {
            var request = requestBase.PrepareRequest(resource, HttpMethod.Get, arguments);

            var response = await requestBase.GetAsync(request);

            try
            {
                return Deserialize<T>(response);
            }
            catch (JsonSerializationException)
            {
                var errorResponse = JsonConvert.DeserializeObject<ResponseDataError>(response, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });

                return new ResponseData<T>() 
                { 
                    Message = errorResponse.Message,
                    ErrorNo = errorResponse.ErrorNo,
                    Request = errorResponse.Request
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ResponseData<T> Deserialize<T>(string response)
        {
            var settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss"
            };

            return JsonConvert.DeserializeObject<ResponseData<T>>(response, settings);
        }
    }
}