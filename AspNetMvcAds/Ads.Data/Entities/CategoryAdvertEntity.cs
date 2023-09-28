﻿using Ads.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ads.Data.Entities
{
    public class CategoryAdvertEntity : IAuditEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int AdvertId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public CategoryEntity Category { get; set; } = null!;

        [ForeignKey(nameof(AdvertId))]
        public AdvertEntity Advert { get; set; }= null!; 

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
