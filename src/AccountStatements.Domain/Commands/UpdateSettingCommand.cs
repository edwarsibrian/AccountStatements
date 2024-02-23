using AccountStatements.Domain.DTOs;
using MediatR;

namespace AccountStatements.Domain.Commands
{
    public class UpdateSettingCommand : SettingCommandBase, IRequest<bool>
    {
        public int Id { get; set; }
    }
}
