using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class Expenses
    {
        [Key]
        public int ExpenseId { get; set; }
        public String Item { get; set; }
        public decimal Cost { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
