using System;
using System.Collections.Generic;

#nullable disable

namespace HouseholdAppCore.Model
{
    public partial class User
    {
        public int Uid { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
