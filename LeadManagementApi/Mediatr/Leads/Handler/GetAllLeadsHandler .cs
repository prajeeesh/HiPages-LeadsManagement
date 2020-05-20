using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using LeadManagementApi.Mediatr.Leads.Query;
using LeadManagementApi.Models;
using LeadManagementApi.Repository;
using System.Threading;

namespace LeadManagementApi.Mediatr.Leads.Handler
{
    public class GetAllLeadsHandler : IRequestHandler<GetAllLeadsQuery, List<Lead>>
    {
        private readonly ILeadsRepository LeadRepository;

        public GetAllLeadsHandler(ILeadsRepository LeadRepository)
        {
            this.LeadRepository = LeadRepository;
        }

        public Task<List<Lead>> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                return LeadRepository.FindAll();
            });
        }
    }
}