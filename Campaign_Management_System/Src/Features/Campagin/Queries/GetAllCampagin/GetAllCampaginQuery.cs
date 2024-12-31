using MediatR;
using Src.Helpers;

namespace Campaign_Management_System.Src.Features.Campagin.Queries.GetAllCampagin
{
    public class GetAllCampaginQuery:IRequest<ResponseDTO>
    {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }

    }
}