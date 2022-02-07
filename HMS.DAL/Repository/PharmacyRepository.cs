using HMS.DAL.Data;
using HMS.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMS.DAL.Repository
{
    public class PharmacyRepository : IPharmacyRepository
    {
        HMSDbContext _hMSDbContext;
        public PharmacyRepository(HMSDbContext hMSDbContext)
        {
            _hMSDbContext = hMSDbContext;
        }
        public void AddMedicine(Pharmacy pharmacy)
        {
            _hMSDbContext.pharmacy.Add(pharmacy);
            _hMSDbContext.SaveChanges();
        }

        public void DeleteMedicine(int MedicineId)
        {
            var pharmacy = _hMSDbContext.pharmacy.Find(MedicineId);
            _hMSDbContext.pharmacy.Remove(pharmacy);
            _hMSDbContext.SaveChanges();
        }

        public Pharmacy GetMedicineById(int MedicineId)
        {
            return _hMSDbContext.pharmacy.Find(MedicineId);
        }

        public IEnumerable<Pharmacy> GetMedicines()
        {
            return _hMSDbContext.pharmacy.ToList();
        }
        public void UpdateMedicine(Pharmacy pharmacy)
        {
            _hMSDbContext.Entry(pharmacy).State = EntityState.Modified;
            _hMSDbContext.SaveChanges();
        }
    }
}
