namespace AperoRental.API.Models {

    public class Admin {
    
        public int Id {get;set;}
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }

        public byte[] PassWordSalt { get; set; }

        public string Email {get;set;}

        override
        public string ToString() => "Username: " + UserName + "\nPassword Hash size: " + PasswordHash.Length +
                                    "\nPassword Salt size: " + PassWordSalt.Length;
    }
}