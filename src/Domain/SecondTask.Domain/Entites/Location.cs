using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Domain.Entites
{
    public class Location : Entity
    {
      
        [Column(TypeName = "text(100)")]
        public string Name { get; set; }
        
        [Column(TypeName = "text(2)")]
        public string CountryCode { get; set; }
        
        public List<WeatherData> WeatherData { get; set; } = new();
    }
}
