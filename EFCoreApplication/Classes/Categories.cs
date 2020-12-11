using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreApplication.Classes
{
    public class Categories // Principal Entity (Parent Entity)
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Products> Product { get; set; } = new List<Products>(); // Collection Navigation Property
        public ICollection<ChildCategories> ChildCategories { get; set; } = new List<ChildCategories>(); // Collection Navigation Property

    }
}
