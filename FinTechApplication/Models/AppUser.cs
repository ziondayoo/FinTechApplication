using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinTechApplication.Models
{
    public class AppUser : IdentityUser
    {

        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(250, ErrorMessage = "First Name can not be longer than 250 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [MaxLength(250, ErrorMessage = "Last Name can not be longer than 250 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public byte Gender { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Address? Address { get; set; }

        public List<Account> Accounts { get; set; }
        public List<Transaction> Transactions { get; set; }
        public AppUser()
        {
            Accounts = new List<Account>();
            Transactions = new List<Transaction>();
        }
    }
}
