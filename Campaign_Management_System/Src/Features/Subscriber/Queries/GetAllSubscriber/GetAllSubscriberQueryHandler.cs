using Campaign_Management_System.Src.Enums;
using Campaign_Management_System.Src.GenericRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Src.Helpers;

namespace Campaign_Management_System.Src.Features.Subscriber.Queries.GetAllSubscriber
{
    public class GetAllSubscriberQueryHandler: IRequestHandler<GetAllSubscriberQuery, ResponseDTO>
    {
        private readonly ResponseDTO _responseDTO;
        public long _loggedInUserId;
        private readonly ILogger<GetAllSubscriberQueryHandler> _logger;
        private readonly IGRepository<Model.Subscriber>_subscriberRepository;

        public GetAllSubscriberQueryHandler(ILogger<GetAllSubscriberQueryHandler> logger,IGRepository<Model.Subscriber>subscriberRepository)
        {
            _responseDTO = new ResponseDTO();
            _subscriberRepository = subscriberRepository;
            _logger = logger;
        }
        public async Task<ResponseDTO> Handle(GetAllSubscriberQuery command, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _subscriberRepository.GetAll(s => s.State != State.Deleted
                     && (string.IsNullOrEmpty(command.Name) || s.Name.Contains(command.Name)) &&
                        (string.IsNullOrEmpty(command.Email) || s.Email.Contains(command.Email)) &&
                        (string.IsNullOrEmpty(command.SubscriptionStatus) || s.SubscriptionStatus == command.SubscriptionStatus))
                        .Select(x => new {
                            Id = x.Id,
                            Name = x.Name,
                            PhoneNumber = x.PhoneNumber,
                            SubscriptionStatus = x.SubscriptionStatus
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
