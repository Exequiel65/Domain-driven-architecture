using Packgroup.Ecommerce.Domain.Common;
using Packgroup.Ecommerce.Domain.Enums;

namespace Packgroup.Ecommerce.Domain.Entities
{
    public class Discount: BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Percent { get; set; }

        public DiscountStatus Status { get; set; }
    }
}
