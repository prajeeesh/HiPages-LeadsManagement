using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManagementApi.Models;

namespace LeadManagementApi.Repository
{
    public interface ILeadsRepository
    {
        Task<Lead> Create(Lead Lead);
        Task<Lead> Edit(Lead Lead);
        Task<Lead> Remove(Lead Lead);
        Lead FindById(int id);
        List<Lead> FindAll();
    }
}
