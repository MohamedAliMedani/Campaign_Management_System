using Campaign_Management_System.Src.Features.Subscriber.Commands.PostSubscriber;
using Campaign_Management_System.Src.Features.Subscriber.Queries.GetAllSubscriber;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Src.Helpers;

namespace Campaign_Management_System.Src.Controller
{
    [ApiController]
    [Route("api/subscribers")]
    public class SubscriberController : ControllerBase
    {
        private readonly ILogger<SubscriberController> _logger;
        private readonly IMediator _mediator;
        private readonly ResponseDTO _response;

        public SubscriberController(ILogger<SubscriberController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDTO();
            _logger = logger;
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetAllSubscriber")]
        public async Task<ResponseDTO> GetAllSubscriber()
        {
            return await _mediator.Send(new GetAllSubscriberQuery());
        }
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("PostSubscriber")]
        public async Task<ResponseDTO> PostSubscriber([FromBody] PostSubscriberCommand content)
        {
            return await _mediator.Send(content);
        }
    }
}