using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MP3HRCloud.Models
{
    public class SeNalaziNa
    { 
        public int ID { get; set; }

        [ForeignKey("Mp3Files"), Column(Order = 0)]
        public int IDPjesme { get; set; }

        [ForeignKey("Playlista"), Column(Order = 1)]
        public int IDPlayliste { get; set; }

        [JsonIgnore]
        public virtual Mp3Files Mp3Files { get; set; }

        [JsonIgnore]
        public virtual Playlista Playlista { get; set; }
    }
}