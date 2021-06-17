using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Availibility2.Models
{
    public partial class Avail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Time { get; set; }
        public string Note { get; set; }
        public bool Cancelled { get; set; }
        public string Secret { get; set; }
    }
}
