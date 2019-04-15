using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class Files
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public DateTime UploadedDate { get; set; }
        public string FolderName { get; set; }
    }
}
