using Equipment_Management.Infrastructure.DTOs;

namespace Equipment_Management.Domain
{
    public interface IRepository
    {
        Task<Equipment?> GetById(Guid id);
        Task<IEnumerable<Equipment>> GetAll();
        Task<Equipment> Add(CreateEquipmentDto equipment);
        Task<Equipment> Update(UpdateEquipmentDto equipment, Guid id);
        Task <Equipment> Delete(Guid id);
    }
}
