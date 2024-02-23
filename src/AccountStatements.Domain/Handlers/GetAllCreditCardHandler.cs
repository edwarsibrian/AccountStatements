using AccountStatements.Domain.Queries;
using AccountStatements.Repository.Entities;
using AccountStatements.Repository.Interfaces;
using MediatR;

namespace AccountStatements.Domain.Handlers
{
    public class GetAllCreditCardHandler : IRequestHandler<GetAllCreditCardQuery, List<CreditCard>>
    {
        private readonly ICreditCardService _creditCardService;

        public GetAllCreditCardHandler(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        public async Task<List<CreditCard>> Handle(GetAllCreditCardQuery request, CancellationToken cancellationToken)
        {
            return await _creditCardService.GetCreditCards();
        }
    }
}
