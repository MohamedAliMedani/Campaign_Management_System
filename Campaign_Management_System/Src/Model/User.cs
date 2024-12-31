using System.ComponentModel.DataAnnotations;
using Campaign_Management_System.Src.Enums;

namespace Campaign_Management_System.Src.Model
{
	public class User : Entity
	{
        public Guid UserId { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? ForthName { get; set; }
        public string? ImageUrl { get; set; }

        public State State { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

