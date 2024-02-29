using System;
using System.Collections.Generic;
using System.Text;

namespace Packgroup.Ecommerce.Domain.Entity
{
    public class Categories
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
