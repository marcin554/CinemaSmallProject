using System.ComponentModel.DataAnnotations;

namespace BerrasBioMarcin.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDate = DateTime.Now;

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber {get; set;}

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Confirm password should be same as password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
