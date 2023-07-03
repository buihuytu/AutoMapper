namespace DemoAutoMapper.Models.DataModels
{
    public class Driver
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int DriverNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int Status { get; set; }

        public int WorldChampionships { get; set; }
    }
}
