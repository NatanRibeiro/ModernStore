using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Infra.Transactions;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerCommandHandler _handler;

        CustomerController(IUow uow, CustomerCommandHandler handler) : base(uow) => _handler = handler;

        [HttpPost]
        [Route("api/customer")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterCustomerCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }
    }
}
