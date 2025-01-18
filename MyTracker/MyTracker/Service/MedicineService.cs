using MyTracker.Models.AppModels;
using MyTracker.Models.EntityModels;
using MyTracker.Models.EntityModels.Context;
using MyTracker.Models.Enums;
using MyTracker.Service.Interface;

namespace MyTracker.Service
{
    public class MedicineService : IMedicineService
    {
        public ResponseModel CreateMedicine(Medicine medicine)
        {
            try
            {
                using var dbContext = new TrackerContext();
                if (!dbContext.Medicines.Any(g => g.Name == medicine.Name))
                {
                    dbContext.Add(medicine);
                    dbContext.SaveChanges();
                    return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record created successfully", Data = medicine };
                }
                else
                    throw new Exception("Record already exist");
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel DeleteMedicine(short id)
        {
            try
            {
                using var dbContext = new TrackerContext();
                var medicine = dbContext.Medicines.First(g => g.Id == id);
                dbContext.Remove(medicine);
                dbContext.SaveChanges();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record deleted successfully", Data = medicine };
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel GetAllMedicines()
        {
            try
            {
                using var dbContext = new TrackerContext();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record(s) fetched successfully", Data = dbContext.Medicines.Distinct().ToList() };

            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel GetMedicineById(short id)
        {
            try
            {
                using var dbContext = new TrackerContext();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record fetched successfully", Data = dbContext.Medicines.First(g => g.Id == id) };

            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }

        public ResponseModel UpdateMedicine(Medicine medicine)
        {
            try
            {
                using var dbContext = new TrackerContext();
                var existingRecord = dbContext.Medicines.First(g => g.Id == medicine.Id);

                if (dbContext.Medicines.Any(g => g.Name == medicine.Name && g.Id != medicine.Id))
                {
                    throw new Exception("Record with same name already exist");
                }

                existingRecord.Name = medicine.Name;
                existingRecord.ExpiryDate = medicine.ExpiryDate;
                existingRecord.UpdatedDate = medicine.UpdatedDate;
                existingRecord.RemindBefore = medicine.RemindBefore;
                existingRecord.QuantityPerDay = medicine.QuantityPerDay;
                existingRecord.AvailableQuantity = medicine.AvailableQuantity;
                existingRecord.ConsumerId = medicine.ConsumerId;
                existingRecord.MedicineTypeId = medicine.MedicineTypeId;
                existingRecord.Note = medicine.Note;
                dbContext.Update(existingRecord);
                dbContext.SaveChanges();
                return new ResponseModel() { Status = ResponseStatus.Success.ToString(), Message = "Record updated successfully", Data = existingRecord };
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Status = ResponseStatus.Error.ToString(), Message = ex.Message };
            }
        }
    }
}
