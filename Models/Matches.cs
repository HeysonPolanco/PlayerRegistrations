using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerRegistrations.Models
{
    public class Matches
    {
        [Key]
        public int MatchId { get; set; }

        public int? Player1Id { get; set; }
        public int? Player2Id { get; set; }
        public string MatchState { get; set; } = string.Empty;
        public int? WinnerId { get; set; }
        public int? PlayerTurnId { get; set; }
        public string? BoardState { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(Player1Id))]
        public virtual Players? Player1 { get; set; }

        [ForeignKey(nameof(Player2Id))]
        public virtual Players? Player2 { get; set; }

        [ForeignKey(nameof(WinnerId))]
        public virtual Players? Winner { get; set; }

        [ForeignKey(nameof(PlayerTurnId))]
        public virtual Players? PlayerTurn { get; set; }
    }
}
