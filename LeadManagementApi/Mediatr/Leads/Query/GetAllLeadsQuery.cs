using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadManagementApi.Models;
namespace LeadManagementApi.Mediatr.Leads.Query
{
    public class GetAllLeadsQuery : IRequest<List<Lead>>
    {
    }
}
