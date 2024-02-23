using AccountStatements.Domain.DTOs;
using AccountStatements.Repository.Entities;
using MediatR;

namespace AccountStatements.Domain.Commands
{
    public class CreateSettingCommand : SettingCommandBase, IRequest<Setting>
    {
    }
}
