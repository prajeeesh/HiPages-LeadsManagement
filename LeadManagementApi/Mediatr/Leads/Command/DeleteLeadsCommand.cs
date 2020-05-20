using MediatR;
using LeadManagementApi.Models;
namespace LeadManagementApi.Mediatr.Leads.Commands
{
    public class DeleteLeadsCommand : IRequest<Lead>
    {
        public DeleteLeadsCommand (Lead lead)
        {
            Lead = lead;
        }

        public Lead Lead { get; }
    }
}