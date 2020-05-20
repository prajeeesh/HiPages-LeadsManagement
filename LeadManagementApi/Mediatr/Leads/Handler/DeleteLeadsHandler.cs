using System.Threading;
using System.Threading.Tasks;
using MediatR;
using LeadManagementApi.Mediatr.Leads.Commands;
using LeadManagementApi.Models;
using LeadManagementApi.Repository;
namespace LeadManagementApi.Mediatr.Leads.Handler
{
    public class DeleteLeadsHandler : IRequestHandler<DeleteLeadsCommand, Lead>
    {
        private readonly ILeadsRepository LeadRepository;

        public DeleteLeadsHandler(ILeadsRepository LeadRepository)
        {
            this.LeadRepository = LeadRepository;
        }

        public async Task<Lead> Handle(DeleteLeadsCommand request, CancellationToken cancellationToken)
        {
            return await LeadRepository.Remove(request.Lead);
        }
    }
}