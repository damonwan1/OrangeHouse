using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeHouse.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public int AdvertisementID { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string Description { get; set; }
        public virtual Advertisement Advertisement { get; set; }
    }
}