using System.ComponentModel.DataAnnotations;

namespace _Subject.Models
{
    public class Subjet
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SubjetName { get; set; }
    }
}
