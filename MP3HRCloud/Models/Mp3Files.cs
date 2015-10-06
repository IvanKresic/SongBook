using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MP3HRCloud.Models
{
    public class Mp3Files
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDPjesme { get; set; }

        [Required]
        public string NaslovPjesme { get; set; }

        [Required]
        public int GodinaIzdavanja { get; set; }

        [Required]
        public string Izvodjac { get; set; }

        [Required]
        public string Trajanje { get; set; }

        [Required]
        public string Velicina { get; set; }

    }
}