

using System.ComponentModel.DataAnnotations;

namespace AperoRental.API.Models {

    public class Speed {
        
        public int Id {get;set;}
        public int Speed1 { get; set; }
        public int Speed2 { get; set; }
        override
        public string ToString() => Speed1 + "x" + Speed2;

    }
}