using Equipment_Management.Domain;

namespace Equipment_Management.Infrastructure.DTOs
{
    public class UpdateEquipmentDto
    {
        public required string Name { get; set; }

        public EquipmentStatus Status { get; set; }

        //= EquipmentStatus.Active;

        public required string SerialNumber { get; set; }

        public DateTime PurchaseDate { get; set; }

    }
}
