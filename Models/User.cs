#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace hothobby.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Name is required and must be at least 2 characters.")]
    [Display(Name = "Full Name")] // If using asp-for in label this lets you customize what the label shows
    public string Name { get; set; }

    [Required(ErrorMessage = "Email address is Required")]
    [EmailAddress] // Set the type of email
    public string Email { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [DataType(DataType.Password)] // auto fills input type of password (specifically when using asp)
    public string Password { get; set; }

    [NotMapped] // please don't add me to the database
    [Compare("Password", ErrorMessage = "Passwords do not match, try again.")]
    public string Confirm { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Post> CreatorPost { get; set; } = new List<Post>();
}
public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext valContext)
    {
        if (value == null)
        { // if email input is empty
            return new ValidationResult("Email is required");
        }
        MyContext _context = (MyContext)valContext.GetService(typeof(MyContext));
        if (_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("Email is in use"); // if email is in database
        }
        else
        {
            return ValidationResult.Success; // email not in database good to go
        }
    }
}