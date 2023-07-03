namespace DemoAutoMapper.Models.IncomingModels
{
    public class DriverForEditingDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int DriverNumber { get; set; }

        public int WorldChampionships { get; set; }
    }
}
