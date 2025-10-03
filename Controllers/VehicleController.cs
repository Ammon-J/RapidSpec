using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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

        [HttpGet]
        [Authorize]
        public IActionResult AddVehicle()
        {
            return View();
        }

        [Authorize]
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

        [HttpGet]
        [Authorize]
        public IActionResult EditVehicle(int id)
        {
            Vehicle curCar = CrudVehicleDatabase.GetVehicle(id);
            return View(curCar);
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditVehicle(Vehicle currCar)
        {
            bool success = false;
            if (currCar.Model != null)
            {
                success = CrudVehicleDatabase.EditVehicle(currCar);

                if (success) 
                {
                    return RedirectToAction("Cars");
                }

                else
                {
                    return View();
                }
            }

            else
            {
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public IActionResult DeleteVehicle(int id)
        {
            Vehicle currCar = CrudVehicleDatabase.GetVehicle(id);

            if (currCar != null)
            {
                return View(currCar);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteVehicle(Vehicle car)
        {
            bool success = CrudVehicleDatabase.DeleteVehicle(car.Id);

            if (success)
            {
                return RedirectToAction("Cars");
            }
            else
            {
                return View();
            }
        }
    }
}
