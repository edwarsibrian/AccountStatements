using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountStatements.Domain.Entities
{
    public class Setting
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public decimal InterestPct { get; set; }

        [Required]
        public decimal MinBalancePct { get; set; }
    }
}
