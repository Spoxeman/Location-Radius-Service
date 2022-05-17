using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitiLocations.Models
{
    public class RadiusViewModel
    {
        [Key]
        public string GeoName { get; set; }

        [Column(TypeName = "decimal(8,6)")]
        public decimal Lat { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal Long { get; set; }
    }
}
