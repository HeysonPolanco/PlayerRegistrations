using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace PlayerRegistrations.Models;

public class Matches
{
    [Key]
    public int MatchId { get; set; }

    [Required(ErrorMessage = "Player 1 must be selected")]
    public int Player1Id { get; set; }

    [Required(ErrorMessage = "Player 2 must be selected")]
    public int? Player2Id { get; set; }

    [Required]
    [StringLength(20)]
    public string MatchState { get; set; }

    public int? WinnerId { get; set; }
    public int? PlayerTurnId { get; set; }

    [StringLength(9)]
    public string BoardState { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }

    [ForeignKey(nameof(Player1Id))]
    public virtual Players Player1 { get; set; }

    [ForeignKey(nameof(Player2Id))]
    public virtual Players Player2 { get; set; }

    [ForeignKey(nameof(WinnerId))]
    public virtual Players Winner { get; set; }

    [ForeignKey(nameof(PlayerTurnId))]
    public virtual Players PlayerTurn { get; set; } // renamed for clarity

    public virtual ICollection<Movements> Movements { get; set; } = new List<Movements>();
}
