using System;
using System.Collections.Generic;
using System.Text;

namespace AndGearbest.Models
{
    public class Coupon
    {
        public string coupon_name { get; set; }

        public string category { get; set; }

        public string coupon_code { get; set; }

        public DateTime start_time { get; set; }

        public DateTime end_time { get; set; }

        public string language { get; set; }

        public string coupon_url { get; set; }

        public string promotion_url { get; set; }
    }
}
