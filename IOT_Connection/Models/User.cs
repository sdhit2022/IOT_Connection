using System.ComponentModel.DataAnnotations;

namespace IOT_Connection.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string? UserName { get; set; }
        [MaxLength(12)]
        public string Mobile { get; set; }
        [MaxLength(5)]
        public string? ActiveCode { get; set; }
        public bool Enabled { get; set; } = false;

        public ICollection<RelUserAndDevice> RelUserAndDevices { get; set; }

    }
}
