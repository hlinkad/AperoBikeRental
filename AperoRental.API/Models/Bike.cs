namespace AperoRental.API.Models{

    public class Bike {
  
        public int Id { get; set; }

        public string Type { get; set; }

        public string Size {get;set;}

       public int SpeedId {get;set;}
        
        public string GenderType { get; set; }

        public string PhotoUrl {get;set;}

        public Speed Speed {get;set;}

    }
}