using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.Models
{
    public  class GameAndDeveloper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public int GameId { get; set; }

        [NotMapped]
        public virtual Developer Developer { get; set; }

        [NotMapped]
        public virtual Game Games { get; set; }
        public GameAndDeveloper()
        {

        }
        public GameAndDeveloper(string initstr)
        {
            string[] split = initstr.Split(',');
            Id = int.Parse(split[0]);
            DeveloperId = int.Parse(split[1]);
            GameId = int.Parse(split[2]);
        }
    }
}
