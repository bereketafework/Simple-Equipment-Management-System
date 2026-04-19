using Equipment_Management.Domain;
using System.ComponentModel.DataAnnotations;

namespace Equipment_Management.Infrastructure.DTOs
{
    public class UpdateEquipmentDto
    {
        public required string Name { get; set; }

        [EnumDataType(typeof(EquipmentStatus), ErrorMessage = " Invalid Status Value")]
        public EquipmentStatus Status { get; set; }

        //= EquipmentStatus.Active;

        public required string SerialNumber { get; set; }

        public DateTime PurchaseDate { get; set; }

    }
}
