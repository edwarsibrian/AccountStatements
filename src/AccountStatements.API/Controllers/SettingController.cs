using AccountStatements.Domain.Commands;
using AccountStatements.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AccountStatements.Repository.Entities;

namespace AccountStatements.Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SettingController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<Setting>GetSetting()
        {
            return await _mediator.Send(new GetSettingQuery());
        }

        [HttpPost]
        public async Task<Setting>CreateSetting(CreateSettingCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<bool>UpdateSetting(UpdateSettingCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
