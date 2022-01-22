using System;
using System.Collections.Generic;

#nullable disable

namespace HouseholdAppCore.Model
{
    public partial class Ausgaben
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public double? Betrag { get; set; }
        public int? ProdGr { get; set; }
        public int? Rechnungsnr { get; set; }

        public virtual Produktgruppe ProdGrNavigation { get; set; }
        public virtual Rechnung RechnungsnrNavigation { get; set; }
    }
}
