using System.ComponentModel.DataAnnotations;

namespace PlayerRegistrations.Models;

public class Players
{
    [Key]
    public int PlayerId { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    public string Name { get; set; } = null!;

    [Range(1, int.MaxValue, ErrorMessage = "The number of matches has to greater than 1")]

    public int Wins { get; set; }
    public int Losses { get; set; }
    public int draws { get; set; }
}
