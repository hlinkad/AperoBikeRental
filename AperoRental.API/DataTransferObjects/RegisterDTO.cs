using System.ComponentModel.DataAnnotations;

namespace AperoRental.API.DataTransferObjects {
 
    public class RegisterDTO {
    
        [Required]
        public string UserName{get;set;}
        [StringLength(200,MinimumLength = 8,ErrorMessage="You must specify a password that is longer than 8 characters")]
        [Required]
        public string Password {get;set;}
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email {get;set;}
    }
}