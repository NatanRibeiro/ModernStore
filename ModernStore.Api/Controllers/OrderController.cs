using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Infra.Transactions;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class OrderController: BaseController
    {
        private readonly OrderCommandHandler _handler;

        OrderController(IUow uow, RegisterOrderCommand hadler) : base(uow) => _handler = _handler;

        [HttpPost]
        [Route("api/order")]
        public async Task<IActionResult> Post([FromBody]RegisterOrderCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }
    }
}