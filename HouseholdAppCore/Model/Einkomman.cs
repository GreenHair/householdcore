using System;
using System.Collections.Generic;

#nullable disable

namespace HouseholdAppCore.Model
{
    public partial class Einkomman
    {
        public int Nr { get; set; }
        public DateTime Datum { get; set; }
        public string Bezeichnung { get; set; }
        public int? Person { get; set; }
        public double? Betrag { get; set; }

        public virtual Familienmitglied PersonNavigation { get; set; }
    }
}
