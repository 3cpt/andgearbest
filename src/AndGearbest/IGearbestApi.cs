namespace AndGearbest
{
    using System.Threading.Tasks;
    using AndGearbest.Models;

    public interface IGearbestApi
    {
        Task<ResponseData<Coupon>> GetCouponsAsync(int page);
    }
}