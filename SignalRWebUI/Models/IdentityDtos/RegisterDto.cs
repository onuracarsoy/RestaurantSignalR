using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Models.IdentityDtos
{
    public class RegisterDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
       
    }
}
