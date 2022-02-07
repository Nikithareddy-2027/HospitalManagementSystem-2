using HMS.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.DAL.Repository
{
    public interface IPharmacyRepository
    {
        void AddMedicine(Pharmacy pharmacy);
        void UpdateMedicine(Pharmacy pharmacy);
        void DeleteMedicine(int MedicineId);
        Pharmacy GetMedicineById(int MedicineId);
        IEnumerable<Pharmacy> GetMedicines();
    }
}
