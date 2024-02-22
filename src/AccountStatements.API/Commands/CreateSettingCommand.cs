using AccountStatements.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Options;

namespace AccountStatements.API.Commands
{
    public class CreateSettingCommand : IRequest<Setting>
    {
        public decimal InterestPct { get; set; }
        public decimal MinBalancePct { get; set; }
    }
}
