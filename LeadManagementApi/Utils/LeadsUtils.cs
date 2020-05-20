using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadManagementApi.Utils
{
    public class LeadsUtils: ILeadsUtils
    {
         decimal discountPercentage = 10;
         decimal discountPriceLimit = 500;
        public LeadsUtils(IConfiguration configuration)
        {
            discountPercentage = Convert.ToDecimal(configuration["DiscountPercentage"]);
            discountPriceLimit = Convert.ToDecimal(configuration["DiscountPriceLimit"]);
        }
        public  decimal ApplyDiscount(decimal amount)
        {
            
            if (amount > discountPriceLimit && discountPercentage >0)
            {
                return amount - ((amount * discountPercentage) / 100);
            }
            else
                return amount;
        }
        public bool SendEmail(string receipient, string subject, string body)
        {
            return true;
        }
    }
}
