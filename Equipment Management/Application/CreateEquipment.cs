//using Equipment_Management.Domain;
//using Microsoft.AspNetCore.Mvc;

//namespace Equipment_Management.Application
//{
//    public record CreateEquipmentRequest(string Name, string SerialNumber, EquipmentStatus Status, DateTime PurchaseDate);
//    public class CreateEquipmentHandler(IRepository repository)
//    {
//        public async Task<ActionResult<Equipment>>
//            Add(CreateEquipmentRequest request)
//        {
//            var equipment = new Equipment
//            {
//                Id = Guid.NewGuid(),
//                Name = request.Name,
//                SerialNumber = request.SerialNumber,
//                Status = request.Status,
//                PurchaseDate = request.PurchaseDate
//            };
//            await repository.Add(equipment);
//            return equipment;

//        }
//    }
//}
