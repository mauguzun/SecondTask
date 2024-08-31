
namespace TestTask.Domain.Entites
{
    public class WeatherData : Entity
    {
        public Location Location { get; set; } 
        
        // that will be real in sqlite or psql
        public int Temperature  {get; set; } 
        
        public int LocationId { get; set; }
        
        // text for ef core , but for test will be ok
        
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
