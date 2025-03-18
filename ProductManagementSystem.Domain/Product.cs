using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int QuantityPerUnitId { get; set; }
        public int ReorderLevel { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public Supplier Supplier { get; set; }
        public Units Units { get; set; }
    }
}
