using System;

namespace Harvest.Models
{
    public class ExpenseCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public double? UnitPrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}