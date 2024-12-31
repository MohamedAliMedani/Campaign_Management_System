using MediatR;
using Src.Helpers;

namespace Campaign_Management_System.Src.Features.Campagin.Commands.PostCampagin
{
    public class PostCampaginCommand:IRequest<ResponseDTO>
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}