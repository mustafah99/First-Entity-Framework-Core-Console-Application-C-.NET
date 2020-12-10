using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreApplication.Classes
{
    public class Subcategories
    {
        [Key]
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
    }
}
