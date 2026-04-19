using Equipment_Management.Domain;
using Equipment_Management.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Equipment_Management.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly EfDbContext _context;

        public Repository(EfDbContext context)
        {

            _context = context;
        }


        // A Function That Fetch  an Equipments By Id
        public async Task<Equipment?> GetById(Guid id)
        {
            var equipment = await _context.Equipment.FindAsync(id);

            return equipment;

        }

        // A Function That Fetch Equipments
        public async Task<IEnumerable<Equipment>> GetAll()
        {
            var allequipment = await _context.Equipment.ToListAsync();
            return allequipment;

        }
        // A Function That Create an Equipments
        public async Task<Equipment> Add(CreateEquipmentDto equipment)
        {

            var NewEquipment = new Equipment
            {
                Id = Guid.NewGuid(),
                Name = equipment.Name,
                SerialNumber = equipment.SerialNumber,
                Status = equipment.Status,
                PurchaseDate = equipment.PurchaseDate
            };
            _context.Equipment.Add(NewEquipment);
            _context.SaveChanges();
            return (NewEquipment);

        }
        // A Function That Update an Equipments Data
        public async Task<Equipment> Update(UpdateEquipmentDto equipment, Guid id)
        {
            var EquipmentFound = await _context.Equipment.FindAsync(id);



            EquipmentFound.Name = equipment.Name;
            EquipmentFound.SerialNumber = equipment.SerialNumber;
            EquipmentFound.Status = equipment.Status;
            EquipmentFound.PurchaseDate = equipment.PurchaseDate;
            
       //_context.Equipment.Update(EquipmentFound);
            _context.SaveChanges();
            return (EquipmentFound);
        }


        // A Function That Delete an Equipments
        public async Task<Equipment> Delete(Guid id)
        {
            var equpment = await _context.Equipment.FindAsync(id);

            _context.Remove(equpment);
            _context.SaveChanges();
            return (equpment);
        }
    }

}
