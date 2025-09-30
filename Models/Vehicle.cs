using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace RapidSpec.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string EngineName { get; set; }
        public string EngineType { get; set; }
        public float Price { get; set; }
    }
}
