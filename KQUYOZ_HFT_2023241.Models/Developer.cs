using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQUYOZ_HFT_2023241.Models
{
    public class Developer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DeveloperId", TypeName = "int")]
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Game> Games { get; set; }

        public Developer()
        {
            Games = new HashSet<Game>();
        }

        public Developer(string initstr)
        {
            string[]split=initstr.Split(',');
            Id = int.Parse(split[0]);
            Name = split[1];
            Games = new HashSet<Game>();
        }
    }
}
