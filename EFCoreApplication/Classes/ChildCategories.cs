using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreApplication.Classes
{
    public class ChildCategories
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Categories> ParentCategory { get; set; } = new List<Categories>(); // Collection Navigation Property
    }
}
