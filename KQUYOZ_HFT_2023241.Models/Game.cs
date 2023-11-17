using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KQUYOZ_HFT_2023241.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string Title { get; set; }

        [NotMapped]
        public virtual List<GameAndDeveloper> GameAndDeveloper { get; set; }

    }
}