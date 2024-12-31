using System.ComponentModel.DataAnnotations;
using MediatR;
using Src.Helpers;

namespace Campaign_Management_System.Src.Features.Subscriber.Commands.PostSubscriber
{
    public class PostSubscriberCommand:IRequest<ResponseDTO>
    {    
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string SubscriptionStatus { get; set; }
    }
}