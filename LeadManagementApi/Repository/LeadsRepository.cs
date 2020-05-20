using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadManagementApi.Models;

namespace LeadManagementApi.Repository
{
    public class LeadsRepository : ILeadsRepository
    {
        private readonly LeadsDBContext context;

        public LeadsRepository(LeadsDBContext context)
        {
            this.context = context;
        }

        public async Task<Lead> Create(Lead Lead)
        {
            context.Leads.Add(Lead);
            await context.SaveChangesAsync();
            return Lead;
        }

        public async Task<Lead> Edit(Lead Lead)
        {
            context.Leads.Update(Lead);
            await context.SaveChangesAsync();
            return Lead;
        }

        public List<Lead> FindAll()
        {
            return context.Leads.ToList();
        }

        public Lead FindById(int id)
        {
            return context.Leads.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Lead> Remove(Lead Lead)
        {
            context.Leads.Remove(Lead);
            await context.SaveChangesAsync();
            return Lead;
        }
    }
}
