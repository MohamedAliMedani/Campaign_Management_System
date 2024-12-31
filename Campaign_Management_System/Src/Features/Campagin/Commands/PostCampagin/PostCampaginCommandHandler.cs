using Campaign_Management_System.Src.Enums;
using Campaign_Management_System.Src.GenericRepo;
using MediatR;
using Src.Helpers;

namespace Campaign_Management_System.Src.Features.Campagin.Commands.PostCampagin
{
    public class PostCampaginCommandHandler : IRequestHandler<PostCampaginCommand, ResponseDTO>
    {
        private readonly ResponseDTO _responseDTO;
        public long _loggedInUserId;
        private readonly ILogger<PostCampaginCommandHandler> _logger;
        private readonly IGRepository<Model.Campaign> _campaginRepository;

        public PostCampaginCommandHandler(ILogger<PostCampaginCommandHandler> logger, IGRepository<Model.Campaign> campaginRepository)
        {
            _responseDTO = new ResponseDTO();
            _campaginRepository = campaginRepository;
            _logger = logger;
        }
        public async Task<ResponseDTO> Handle(PostCampaginCommand command, CancellationToken cancellationToken)
        {
            try
            {

                Model.Campaign campaign = new Model.Campaign();

                campaign.Subject = command.Subject;
                campaign.Content = command.Content;
                campaign.ScheduledDate = command.ScheduledDate;
                campaign.CreatedOn = DateTime.Now;
                campaign.State = State.NotDeleted;

                _campaginRepository.Add(campaign);
                _campaginRepository.Save();

                _responseDTO.Result = null;
                _responseDTO.StatusEnum = StatusEnum.SavedSuccessfully;
                _responseDTO.Message = "campaignAddedSuccessfully";

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
