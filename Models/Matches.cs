using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlayerRegistrations.Models;

public class Matches
{
    [Key]
    public int MatchId { get; set; }

    public int PlayerId { get; set; }
    public int? Player2Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Matchstate { get; set; }

    public int? WinnerId { get; set; }
    public int? PlayerTurnId { get; set; }

    [StringLength(9)]

    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }

    // Propiedades de navegación
    [ForeignKey(nameof(PlayerId))]
    public virtual Players Player1 { get; set; }

    [ForeignKey(nameof(Player2Id))]
    public virtual Players Player2 { get; set; }

    [ForeignKey(nameof(WinnerId))]
    public virtual Players Winner { get; set; }

    [ForeignKey(nameof(PlayerTurnId))]
    public virtual Players PlayerTurns { get; set; }
}