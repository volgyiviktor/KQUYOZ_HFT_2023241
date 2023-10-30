using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KQUYOZ_HFT_2023241.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("GameId", TypeName = "int")]
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string Title { get; set; }

        [NotMapped]
        public virtual Developer Developer { get; set; }

        public Game()
        {

        }

        public Game(string initstr)
        {
            string[] split = initstr.Split(',');
            Id = int.Parse(split[0]);
            Title = split[1];
        }
    }
}