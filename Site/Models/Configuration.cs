using System;
using System.Collections.Generic;

namespace Site.Models
{
    public partial class Configuration
    {
        public int ConfigId { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
