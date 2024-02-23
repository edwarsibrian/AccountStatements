using AccountStatements.Repository.Entities;
using MediatR;

namespace AccountStatements.Domain.Commands
{
    public class CreateSettingCommand : IRequest<Setting>
    {
        public decimal InterestPct { get; set; }
        public decimal MinBalancePct { get; set; }
    }
}
