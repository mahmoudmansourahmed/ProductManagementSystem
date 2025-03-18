using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Domain
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
