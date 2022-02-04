using RentacarApi.Helpers.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace RentacarApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]{1,20}", ErrorMessage = "Name can contain only letters.")]
        public string Name { get; set; } = null!;

        [Required]
        [RegularExpression(@"[a-zA-Z]{1,20}", ErrorMessage = "Name can contain only letters.")]
        public string LastName { get; set; } = null!;

        [Required]
        [JmbgValidation]
        public long Jmbg { get; set; }


        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;
    }
}//@"^[a-zA-Z''-'\s]{1,40}$"
