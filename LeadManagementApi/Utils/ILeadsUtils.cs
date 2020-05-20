using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadManagementApi.Utils
{
    public interface ILeadsUtils
    {
        decimal ApplyDiscount(decimal amount);
        bool SendEmail(string receipient, string subject, string body);
    }
}
