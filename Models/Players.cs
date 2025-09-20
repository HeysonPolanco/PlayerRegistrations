using System.ComponentModel.DataAnnotations;

namespace PlayerRegistrations.Models;

public class Players
{
    [Key]
    public int PlayerId { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    public required string Name { get; set; }
    public string Concept { get; set; } = null!;
    public int? Wins { get; set; } = 0;
    public int? Losses { get; set; } = 0;
    public int? Draws { get; set; } = 0;
}
