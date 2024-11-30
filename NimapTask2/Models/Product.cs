﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NimapTask2.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }  // Foreign key for Category

        public virtual Category Category { get; set; } // Navigation property

    }
}