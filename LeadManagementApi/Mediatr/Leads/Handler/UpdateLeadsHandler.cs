using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using LeadManagementApi.Mediatr.Leads.Commands;
using LeadManagementApi.Models;
using LeadManagementApi.Repository;
using System.Threading;

namespace LeadManagementApi.Mediatr.Leads.Handler
{
    public class UpdateLeadsHandler : IRequestHandler<UpdateLeadsCommand, Lead>
    {
        private readonly ILeadsRepository LeadsRepository;

        public UpdateLeadsHandler(ILeadsRepository LeadsRepository)
        {
            this.LeadsRepository = LeadsRepository;
        }

        public async Task<Lead> Handle(UpdateLeadsCommand request, CancellationToken cancellationToken)
        {
            return await LeadsRepository.Edit(request.Lead);
        }
    }
}