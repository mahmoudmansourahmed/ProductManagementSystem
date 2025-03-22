using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Domain.Entity
{
    public class Product
    {
        public int Id { get; set; } // معرف المنتج
        public string ProductName { get; set; } // اسم المنتج
        public int QuantityPerUnitId { get; set; } // معرف الوحدة (Foreign Key)
        public int ReorderLevel { get; set; } // الحد الأدنى لإعادة الطلب
        public int SupplierId { get; set; } // معرف المورد (Foreign Key)
        public decimal UnitPrice { get; set; } // سعر الوحدة
        public int UnitsInStock { get; set; } // الوحدات في المخزون
        public int UnitsOnOrder { get; set; } // الوحدات في الطلب

        // Navigation properties
        public Supplier? Supplier { get; set; }
        public Unit? Units { get; set; }
    }
}
