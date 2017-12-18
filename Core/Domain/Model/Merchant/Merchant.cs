using ShiftManagementPortal.Core.SeedWork;

namespace ShiftManagementPortal.Core.Domain.Model
{
    public class Merchant: Entity
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public Address Address { get; set; }
    }
}
