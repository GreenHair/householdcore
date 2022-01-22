using System;
using System.Collections.Generic;

#nullable disable

namespace HouseholdAppCore.Model
{
    public partial class Pkw
    {
        public int Id { get; set; }
        public double? Km { get; set; }
        public double? Verbrauch { get; set; }
        public string Bemerkungen { get; set; }
    }
}
