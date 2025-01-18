using MyTracker.Models.AppModels;
using MyTracker.Models.EntityModels;

namespace MyTracker.Service.Interface
{
    public interface IMedicineService
    {
        ResponseModel GetAllMedicines();

        ResponseModel GetMedicineById(short id);

        ResponseModel CreateMedicine(Medicine medicine);

        ResponseModel UpdateMedicine(Medicine medicine);

        ResponseModel DeleteMedicine(short id);

    }
}
