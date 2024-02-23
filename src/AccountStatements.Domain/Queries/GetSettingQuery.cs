using AccountStatements.Repository.Entities;
using MediatR;

namespace AccountStatements.Domain.Queries
{
    public class GetSettingQuery : IRequest<Setting>
    {
    }
}
