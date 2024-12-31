using Campaign_Management_System.Src.Enums;
using Campaign_Management_System.Src.GenericRepo;
using MediatR;
using Src.Helpers;

namespace Campaign_Management_System.Src.Features.Subscriber.Commands.PostSubscriber
{
    public class PostSubscriberCommandHandler: IRequestHandler<PostSubscriberCommand, ResponseDTO>
    {
        private readonly ResponseDTO _responseDTO;
        public long _loggedInUserId;
        private readonly ILogger<PostSubscriberCommandHandler> _logger;
        private readonly IGRepository<Model.Subscriber>_subscriberRepository;

        public PostSubscriberCommandHandler(ILogger<PostSubscriberCommandHandler> logger,IGRepository<Model.Subscriber>subscriberRepository)
        {
            _responseDTO = new ResponseDTO();
            _subscriberRepository = subscriberRepository;
            _logger = logger;
        }
        public async Task<ResponseDTO> Handle(PostSubscriberCommand command, CancellationToken cancellationToken)
        {
            try
            {
             
                Model.Subscriber subscriber = new Model.Subscriber();

                subscriber.Name = command.Name;
                subscriber.Email = command.Email;
                subscriber.PhoneNumber = command.PhoneNumber;
                subscriber.SubscriptionStatus = command.SubscriptionStatus;
                subscriber.CreatedOn = DateTime.Now;
                subscriber.State = State.NotDeleted;
            
                _subscriberRepository.Add(subscriber);
                _subscriberRepository.Save();

                _responseDTO.Result = null;
                _responseDTO.StatusEnum = StatusEnum.SavedSuccessfully;
                _responseDTO.Message = "subscriberAddedSuccessfully";

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
