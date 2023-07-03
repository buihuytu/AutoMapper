namespace DemoAutoMapper.Models.IncomingModels
{
    public class DriverForCreationDTO
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int DriverNumber { get; set; }

        public int WorldChampionships { get; set; }
    }
}
