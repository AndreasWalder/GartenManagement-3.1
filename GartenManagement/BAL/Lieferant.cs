using System;
using System.Collections.Generic;

#nullable disable

namespace GartenManagement.BAL
{
    public partial class Lieferant
    {
        public Lieferant()
        {
            Lieferungs = new HashSet<Lieferung>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Lieferung> Lieferungs { get; set; }
    }
}
