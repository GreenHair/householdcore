using System;
using System.Collections.Generic;

#nullable disable

namespace HouseholdAppCore.Model
{
    public partial class Familienmitglied
    {
        public Familienmitglied()
        {
            Einkommen = new HashSet<Einkomman>();
            Rechnungs = new HashSet<Rechnung>();
        }

        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public virtual ICollection<Einkomman> Einkommen { get; set; }
        public virtual ICollection<Rechnung> Rechnungs { get; set; }
    }
}
