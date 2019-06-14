using System;
using System.Collections.Generic;

namespace Site.Models
{
    public partial class Images
    {
        public int ImageId { get; set; }
        public string ImgFileName { get; set; }
        public DateTime UploadedDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int IsPublished { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}
