﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace KQUYOZ_HFT_2023241.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2023)]
        public int ReleaseYear { get; set; }

        [Required]
        [Range(0, 100)]
        public int Metascore { get; set; }

        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Developer Developer { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Publisher Publisher { get; set; }

    }
}
