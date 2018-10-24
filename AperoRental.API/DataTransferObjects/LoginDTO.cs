using System.ComponentModel.DataAnnotations;

namespace AperoRental.API.DataTransferObjects {

    public class LoginDTO {  
    
        [Required]
        public string UserName{get;set;}
        [StringLength(200,MinimumLength = 8,ErrorMessage="You must specify a password that is longer than 8 characters")]
        [Required]
        public string Password {get;set;}
        
    }
}