using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class Messages
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public DateTime Logged { get; set; }
        public string MessageSubject { get; set; }
        public string FromAddress { get; set; }
        public bool IsSpam { get; set; }
        public bool IsNice { get; set; }
    }
}
