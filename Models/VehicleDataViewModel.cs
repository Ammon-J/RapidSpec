using System.ComponentModel;

namespace RapidSpec.Models
{
    public class VehicleDataViewModel
    {
        public int Id { get; set; }
        [DisplayName("Make")]
        public string Make { get; set; }
        [DisplayName("Model")]
        public string Model { get; set; }
        [DisplayName("Year")]
        public int Year { get; set; }
        [DisplayName("Engine Name")]
        public string EngineName { get; set; }
        [DisplayName("Engine Type")]
        public string EngineType { get; set; }
        [DisplayName("Price")]
        public float Price { get; set; }
    }
}
