using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeHouse.Models
{
    public class Advertisement
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        // public byte []Image {get;set;}
        //0 unprocceed ,1 successful,2 unsuccessful
        public int Pass { get; set; }
        public string address { get; set; }
        public string RefuseReason { get; set; }
        //public int UserID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}