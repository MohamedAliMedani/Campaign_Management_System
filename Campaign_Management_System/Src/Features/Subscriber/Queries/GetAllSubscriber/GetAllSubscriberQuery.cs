using MediatR;
using Src.Helpers;

namespace Campaign_Management_System.Src.Features.Subscriber.Queries.GetAllSubscriber
{
    public class GetAllSubscriberQuery :IRequest<ResponseDTO>
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? SubscriptionStatus { get; set; }

    }
}