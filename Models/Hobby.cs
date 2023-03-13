#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace hothobby.Models;

public class Hobby
{
    [Key]
    public int HobbyId { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
    public string Title { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "Hobby description must be at least 15 characters long")]
    public string HobbyDes { get; set; }
    // add more attributes here

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public User? Creator { get; set; }
}