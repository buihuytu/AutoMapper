using System.Security.Principal;

namespace DemoAutoMapper.Models.OutgoingModels
{
    public class DriverDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        public int DriverNumber { get; set; }

        public int WorldChampionships { get; set; }
    }
}
