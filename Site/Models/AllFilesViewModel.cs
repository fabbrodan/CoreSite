using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class AllFilesViewModel
    {
        public IEnumerable<Images> Images { get; set; }
        public IEnumerable<Files> Files { get; set; }
        public IEnumerable<FileCategories> Categories { get; set; }
    }
}
