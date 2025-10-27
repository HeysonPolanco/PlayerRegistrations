using System.ComponentModel.DataAnnotations;

namespace PlayerRegistrations.Models
{
    public class Players
    {
        [Key]
        public int PlayerId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Concept { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
    }
}