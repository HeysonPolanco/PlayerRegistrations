using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerRegistrations.Models;

public class Movements
{
    [Key]
    public int MovementId { get; set; }
    public int MatchId { get; set; }
    public int PlayerId { get; set; }
    [Range (0, 2)]
    public int LinePosition { get; set; }
    [Range(0, 2)]
    public int columnPosition { get; set; }
    public DateTime MovementTime { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(MatchId))]
    public virtual Matches Match { get; set; }

    [ForeignKey(nameof(PlayerId))]
    public virtual Players Player { get; set; }
}
