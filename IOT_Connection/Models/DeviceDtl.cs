using System.ComponentModel.DataAnnotations;

namespace IOT_Connection.Models
{
    public class DeviceDtl
    {
        [Key]
        public Guid Id { get; set; }
        public DeviceStatusEnum Status { get; set; }

        public Guid FkDeviceHdrId { get; set; }
        public DeviceHdr DeviceHdr { get; set; }
    }
}
