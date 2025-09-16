using System.ComponentModel.DataAnnotations;

namespace PlayerRegistrations.Models;

public class Players
{
    [Key]
    public int PlayerId { get; set; }
    [Required(ErrorMessage = "First Name is required")]
    public string Concept { get; set; }
    public int losses { get: set: }
	public int Draw { get: set: }
}
