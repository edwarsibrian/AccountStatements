using AccountStatements.Domain.Queries;
using AccountStatements.Repository.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountStatements.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreditCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CreditCard>> GetAllCreditCards()
        {
            return await _mediator.Send(new GetAllCreditCardQuery());
        }
    }
}
