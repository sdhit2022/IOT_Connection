using IOT_Connection.Models;
using System.ComponentModel.DataAnnotations;

namespace IOT_Connection.Models
{
    public class DeviceHdr
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public IconEnum? Icon { get; set; }
        [MaxLength(100)]
        public string SystemCode { get; set; }
        [MaxLength(100)]
        public string UniqId { get; set; }

        public ICollection<DeviceDtl> DeviceDtls { get; set; }
        public ICollection<RelUserAndDevice> RelUserAndDevices { get; set; }
    }
}
