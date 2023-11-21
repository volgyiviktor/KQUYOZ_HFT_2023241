using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KQUYOZ_HFT_2023241.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2023)]
        public int ReleaseYear {  get; set; }

        [Required]
        [Range(0, 100)]
        public int Metascore { get; set; }

        [NotMapped]
        public virtual List<GameAndDeveloper> GameAndDeveloper { get; set; }

    }
}