using Microsoft.AspNetCore.Mvc;
using RapidSpec.Data;
using RapidSpec.Models;

namespace RapidSpec.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleDbContext _context;

        public VehicleController(VehicleDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Cars()
        {
            var vehicles = _context.VehicleSpecs.ToList();

            if (vehicles != null)
            {
                List<VehicleDataViewModel> vehicleList = new List<VehicleDataViewModel>();
                foreach (var vehicle in vehicles)
                {
                    var vehicleDataViewModel = new VehicleDataViewModel
                    {
                        Id = vehicle.Id,
                        Make = vehicle.Make,
                        Model = vehicle.Model,
                        Year = vehicle.Year,
                        EngineName = vehicle.EngineName,
                        EngineType = vehicle.EngineType,
                        Price = vehicle.Price,
                    };
                    vehicleList.Add(vehicleDataViewModel);
                }
                return View(vehicleList);
            }
            return View(vehicles);
        }

        public IActionResult AddVehicle()
        {
            return View();
        }

        
        public IActionResult OnSubmitAddVehicle(Vehicle car)
        {
            if (car.Model != null)
            {
                CrudVehicleDatabase.AddVehicle(car);
                return RedirectToAction("Cars");
            }
            else
            {
                return View();
            }
        }
    }
}
