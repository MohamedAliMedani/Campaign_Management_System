using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Campaign_Management_System.Src.Enums;

namespace Campaign_Management_System.Src.Model
{
public class Entity
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }

        [ForeignKey("User")]
        public Guid? CreatedBy { get; set; }
        public User User { get; set; }

        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public State State { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}