namespace LicenseCreator.Models
{
    public class License
    {
        public List<Device> Devices { get; set; } = new List<Device>();
        public DateTime ExpiryDate { get; set; }
    }

    public class Device
    {
        public string? DeviceId { get; set; }
    }
}
