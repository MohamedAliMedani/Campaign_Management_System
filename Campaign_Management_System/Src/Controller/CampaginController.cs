using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campaign_Management_System.Src.Features.Campagin.Commands.PostCampagin;
using Campaign_Management_System.Src.Features.Campagin.Queries.GetAllCampagin;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Src.Helpers;

namespace Campaign_Management_System.Src.Controller
{    
    [ApiController]
    [Route("api/campagins")]
    public class CampaginController: ControllerBase
    {
        private readonly ILogger<CampaginController> _logger;
        private readonly IMediator _mediator;
        private readonly ResponseDTO _response;

        public CampaginController(ILogger<CampaginController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseDTO();
            _logger = logger;
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetAllCampagin")]
        public async Task<ResponseDTO> GetAllCampagin()
        {
            return await _mediator.Send(new GetAllCampaginQuery());
        }
        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("PostCampagin")]
        public async Task<ResponseDTO> PostCampagin([FromBody] PostCampaginCommand content)
        {
            return await _mediator.Send(content);
        }
    }
}