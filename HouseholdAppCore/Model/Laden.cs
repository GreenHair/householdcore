using System;
using System.Collections.Generic;

#nullable disable

namespace HouseholdAppCore.Model
{
    public partial class Laden
    {
        public Laden()
        {
            Rechnungs = new HashSet<Rechnung>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Online { get; set; }

        public virtual ICollection<Rechnung> Rechnungs { get; set; }
    }
}
