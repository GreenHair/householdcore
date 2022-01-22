using System;
using System.Collections.Generic;

#nullable disable

namespace HouseholdAppCore.Model
{
    public partial class Produktgruppe
    {
        public Produktgruppe()
        {
            Ausgabens = new HashSet<Ausgaben>();
        }

        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public bool Essen { get; set; }

        public virtual ICollection<Ausgaben> Ausgabens { get; set; }
    }
}
