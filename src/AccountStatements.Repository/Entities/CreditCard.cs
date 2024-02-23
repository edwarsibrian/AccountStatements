using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountStatements.Repository.Entities
{
    public class CreditCard
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Holder")]
        public int HolderId { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public decimal CreditLimit { get; set; }

        public decimal CurrentBalance { get;set; }

        [Required]
        public decimal AvailableBalance { get; set; }

        public Holder Holder { get; set; }

        [NotMapped]
        public IEnumerable<Charge> Charges { get; set; }
    }
}
