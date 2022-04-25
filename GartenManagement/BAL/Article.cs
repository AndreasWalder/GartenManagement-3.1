using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GartenManagement.BAL
{
    public partial class Article
    {
        public Article()
        {
            Lieferungs = new HashSet<Lieferung>();
        }

        
        public int Id { get; set; }
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Patient is required and must not be empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Patient is required and must not be empty.")]
        public double Price { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Lieferung> Lieferungs { get; set; }
    }
}
