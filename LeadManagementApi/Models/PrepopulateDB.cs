using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LeadManagementApi.Models
{
    public static class PrepopulateDB
    {
        public static void PerpopulateTables(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<LeadsDBContext>());
            }
            
        }
        public static void SeedData(LeadsDBContext context)
        {
            context.Database.Migrate();
            if(!context.Leads.Any())
            {
                context.Leads.AddRange(
                        new Lead() { FirstName = "Luke", LastName = "Skywalker", Email = "luke@mailinator.com", Phone = 0412345678, Suburb = "Sydney", Date = new DateTime(2020,5,10,10,30,0), Category = "Plumbing", Desciption = "Integer aliquam pulvinar odio et convallis. Integer id tristique ex. ", Price = 1234, Status = "New" } ,
                        new Lead() { FirstName = "Darth", LastName = "Vader", Email = "darth@mailinator.com", Phone = 0312456, Suburb = "Bondi", Date = new DateTime(2020, 5, 12, 7, 20, 0), Category = "Electrical", Desciption = "Aliquam posuere est sit amet libero egestas tempus.", Price = 4321, Status = "New" },
                        new Lead() { FirstName = "Han", LastName = "Solo", Email = "han@mailinator.com", Phone = 023455, Suburb = "Manly", Date = new DateTime(2020, 5, 16, 9, 45, 0), Category = "Carpentry", Desciption = "Morbi rutrum felis lacinia eros tincidunt scelerisque. Morbi aliquam porttitor sapien.", Price = 357, Status = "New" },
                        new Lead() { FirstName = "Lando", LastName = "Calrissian", Email = "lando@mailinator.com", Phone = 0322145, Suburb = "Newtown", Date = new DateTime(2020, 5, 16, 8, 30, 0), Category = "Building", Desciption = "Suspendisse consequat malesuada arcu id venenatis. Donec maximus, dolor quis elementum scelerisque", Price = 120, Status = "New" }
                    );
                context.SaveChanges();
            }
        }
    }
}
