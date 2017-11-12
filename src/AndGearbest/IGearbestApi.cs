namespace AndGearbest
{
    using System;
    using System.Threading.Tasks;
    using AndGearbest.Defaults;
    using AndGearbest.Models;

    public interface IGearbestApi
    {
        Task<ResponseData<Coupon>> GetCouponsAsync(int page = 1);

        Task<ResponseData<ProductCreative>> GetProductCreativeAsync(ProductCreativeType productCreativeType, int page = 1);

        Task<ResponseData<EventCreative>> GetEventCreativeAsync(EventType eventType, int page = 1);

        Task<ResponseData<PromotionProduct>> GetPromotionProductAsync(CurrencyType currencyType, int page = 1);

        Task<ResponseData<CompletedOrder>> GetCompletedOrderAsync(DateTime startDate, DateTime endDate, int page = 1);
    }
}