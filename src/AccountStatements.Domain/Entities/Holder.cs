using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountStatements.Domain.Entities
{
    public class Holder
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [NotMapped]
        public IEnumerable<CreditCard> CreditCards { get; set;}
    }
}
