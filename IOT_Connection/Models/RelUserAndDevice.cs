using System.ComponentModel.DataAnnotations;

namespace IOT_Connection.Models
{
    public class RelUserAndDevice
    {
        [Key]
        public int Id { get; set; }

        public Guid FkUserId { get; set; }
        public User User { get; set; }

        public Guid FkDeviceHdrId { get; set; }
        public DeviceHdr DeviceHdr { get; set; }
    }
}
