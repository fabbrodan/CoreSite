using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class AllFilesAdminViewModel
    {
        public List<List<Images>> CategorizedImages { get; set; }
        public List<Files> Files { get; set; }
        public List<FileCategories> Categories { get; set; }

        public AllFilesAdminViewModel()
        {
            CategorizedImages = new List<List<Images>>();
            Files = new List<Files>();
            Categories = new List<FileCategories>();
        }
    }
}
