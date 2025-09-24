using System.ComponentModel.DataAnnotations;

namespace RapidSpec.Models
{
    public class VehicleDataEntity
    {
        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string EngineName { get; set; }
        public string EngineType { get; set; }
        public decimal Price { get; set; }
    }
}
