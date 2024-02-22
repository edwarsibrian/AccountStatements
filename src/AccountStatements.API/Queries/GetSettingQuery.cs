using AccountStatements.Domain.Entities;
using MediatR;

namespace AccountStatements.API.Queries
{
    public class GetSettingQuery : IRequest<Setting>
    {
    }
}
