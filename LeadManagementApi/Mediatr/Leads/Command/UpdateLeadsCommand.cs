using MediatR;
using LeadManagementApi.Models;

namespace LeadManagementApi.Mediatr.Leads.Commands
{
    public class UpdateLeadsCommand : IRequest<Lead>
    {
        public UpdateLeadsCommand(Lead lead)
        {
            Lead = lead;
        }

        public Lead Lead { get; }
    }
}
   
