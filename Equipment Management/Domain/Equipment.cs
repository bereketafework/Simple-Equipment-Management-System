using System.ComponentModel.DataAnnotations;

namespace Equipment_Management.Domain
{
    public enum EquipmentStatus
    {
        Active,
        Inactive,
        Maintenance
    }
    public class Equipment

    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        [EnumDataType(typeof(EquipmentStatus),ErrorMessage =" Invalid Status Value")]
        public EquipmentStatus Status { get; set; }


        public required string SerialNumber { get; set; }

        public DateTime PurchaseDate { get; set; }
     
    }
}
