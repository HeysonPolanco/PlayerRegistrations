using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerRegistrations.Models
{
    public class Movements
    {
        [Key]
        public int MovementId { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        [Range(0, 2)]
        public int LinePosition { get; set; }
        [Range(0, 2)]
        public int ColumnPosition { get; set; }
        public DateTime MovementDate { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(MatchId))]
        public virtual Matches? Matches { get; set; }
        [ForeignKey(nameof(PlayerId))]
        public virtual Players? Players { get; set; }
    }
}
