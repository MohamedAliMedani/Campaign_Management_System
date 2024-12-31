using Campaign_Management_System.Src.Enums;
using Campaign_Management_System.Src.GenericRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Src.Helpers;

namespace Campaign_Management_System.Src.Features.Campagin.Queries.GetAllCampagin
{
    public class GetAllCampaginQueryHandler: IRequestHandler<GetAllCampaginQuery, ResponseDTO>
    {
        private readonly ResponseDTO _responseDTO;
        public long _loggedInUserId;
        private readonly ILogger<GetAllCampaginQueryHandler> _logger;
        private readonly IGRepository<Model.Campaign>_campaignRepository;

        public GetAllCampaginQueryHandler(ILogger<GetAllCampaginQueryHandler> logger,IGRepository<Model.Campaign>campaignRepository)
        {
            _responseDTO = new ResponseDTO();
            _campaignRepository = campaignRepository;
            _logger = logger;
        }
        public async Task<ResponseDTO> Handle(GetAllCampaginQuery command, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _campaignRepository.GetAll(s => s.State != State.Deleted &&
                        s.ScheduledDate >= command.startDate && s.ScheduledDate <= command.endDate)
                        .Select(x => new {
                            Id = x.Id,
                            Content = x.Content,
                            ScheduledDate = x.ScheduledDate,
                            Subject = x.Subject,
                        }).ToListAsync();

                _responseDTO.Result = null;
                _responseDTO.StatusEnum = StatusEnum.Success;
                _responseDTO.Message = "subscriberRetrivedSuccessfully";

            }
            catch (Exception ex)
            {
                _responseDTO.Result = null;
                _responseDTO.StatusEnum = StatusEnum.Exception;
                _responseDTO.Message = "anErrorOccurredPleaseContactSystemAdministrator";
                _logger.LogError(ex, ex.Message, (ex != null && ex.InnerException != null ? ex.InnerException.Message : ""));

            }
            return _responseDTO;
        }

    }
}
