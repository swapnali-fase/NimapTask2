﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NimapTask2.Models
{
    public class Category
    {
        [Key]
        public int CId { get; set; }


        public string CName { get; set; }

        public virtual ICollection<Product> Products { get; set; } // Navigation property
    }
}