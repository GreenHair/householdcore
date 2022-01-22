using System;
using System.Collections.Generic;

#nullable disable

namespace HouseholdAppCore.Model
{
    public partial class Japan
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public string Laden { get; set; }
        public double? Betrag { get; set; }
        public bool? Essen { get; set; }
        public bool? Geschenk { get; set; }
        public int? Person { get; set; }
        public DateTime? Date { get; set; }
    }
}
