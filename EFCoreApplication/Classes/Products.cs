using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreApplication.Classes
{
    public class Products // Dependent Entity (Child Entity)
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public ICollection<Categories> Category { get; set; } = new List<Categories>(); // Collection Navigation Property
    }
}
