using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProject.Models
{
    public class UserList
    {
        [Key]
        public int UserId { get; set; }
        public string Role { get; set; }
        public string FName { get; set; }
        public string? Lname { get; set; }
        public string? Gender { get; set; }

       
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

        public string Password { get; set; }
        [Compare("Password")]
        
        [NotMapped]
        [Display(Name = "Confirm Password")]
        public string? CPassword { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
