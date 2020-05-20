using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadManagementApi.Models
{
    public class LeadsDBContext:DbContext
    {
        public LeadsDBContext(DbContextOptions<LeadsDBContext> options) : base(options)
        {

        }
        public DbSet<Lead> Leads { get; set; }
    }
    
}
