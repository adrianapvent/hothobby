#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace hothobby.Models;

public class Post
{
    [Key]
    public int PostId { get; set; }

    [Required(ErrorMessage = "Image link is required")]
    public string Img { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Content description is required")]
    public string Content { get; set; }
    // add more attributes here

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public User? Creator { get; set; }

    public List<UserPostSignup> Hobbyist { get; set; } = new List<UserPostSignup>();
}