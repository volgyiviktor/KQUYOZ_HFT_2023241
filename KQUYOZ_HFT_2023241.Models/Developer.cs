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
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public virtual List<GameAndDeveloper> GameAndDeveloper { get; set; }
    }
}
