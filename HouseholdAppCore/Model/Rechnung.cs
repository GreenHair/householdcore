using System;
using System.Collections.Generic;

#nullable disable

namespace HouseholdAppCore.Model
{
    public partial class Rechnung
    {
        public Rechnung()
        {
            Ausgabens = new HashSet<Ausgaben>();
        }

        public int Id { get; set; }
        public int? Laden { get; set; }
        public DateTime Datum { get; set; }
        public int Einmalig { get; set; }
        public int? Person { get; set; }

        public virtual Laden LadenNavigation { get; set; }
        public virtual Familienmitglied PersonNavigation { get; set; }
        public virtual ICollection<Ausgaben> Ausgabens { get; set; }
    }
}
