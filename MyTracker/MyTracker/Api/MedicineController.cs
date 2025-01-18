using Microsoft.AspNetCore.Mvc;
using MyTracker.Models.EntityModels;
using MyTracker.Service.Interface;

namespace MyTracker.Api
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class MedicineController(ILogger<MedicineController> logger, IConfiguration config, IMedicineService medicineService) : ControllerBase
    {
        [HttpGet]
        //Authorize and authenticated

        public IActionResult GetMedicines()
        {
            return base.Ok(medicineService.GetAllMedicines()); 
        }

        [HttpGet]
        //Authorize and authenticated

        public IActionResult GetMedicineById(short id)
        {
            return base.Ok(medicineService.GetMedicineById(id));
        }


        [HttpPost]
        //Authorize and authenticated

        public IActionResult CreateMedicine(Medicine medicine)
        {
            return base.Ok( medicineService.CreateMedicine(medicine));
        }

        [HttpPost]
        //Authorize and authenticated

        public IActionResult UpdateMedicine(Medicine medicine)
        {
            return base.Ok(medicineService.UpdateMedicine(medicine));
        }

        [HttpPost]
        //Authorize and authenticated

        public IActionResult DeleteMedicine(short id)
        {
            return base.Ok(medicineService.DeleteMedicine(id));
        }
    }
}
