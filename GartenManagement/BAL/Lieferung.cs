using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GartenManagement.BAL
{
    public partial class Lieferung
    {
        public int Id { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Article is required and must not be empty.")]
        public string selectedArticleId { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Supplier is required and must not be empty.")]
        public string selectedSupplierId { get; set; }

        public int ArticleId { get; set; }
        public int LieferantId { get; set; }

        [Required(ErrorMessage = "Day Of Delivery is required and must not be empty.")]
        public DateTime? DayOfDelivery { get; set; }


        [Range(1, 1000, ErrorMessage = "Value must be between 1 and 1000.")]
        public int Amount { get; set; }

        public virtual Article Article { get; set; }
        public virtual Lieferant Lieferant { get; set; }
    }
}
