using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExWebApiAutos.Model.VehiculoDb
{
    [Table("T_marca")]
    public partial class TMarca
    {
        public TMarca()
        {
            TVehiculo = new HashSet<TVehiculo>();
        }

        [Key]
        [Column("marca_id")]
        public Guid MarcaId { get; set; }
        [Required]
        [Column("marca_nombre")]
        [StringLength(20)]
        public string MarcaNombre { get; set; }

        [InverseProperty("Marca")]
        public ICollection<TVehiculo> TVehiculo { get; set; }
    }
}
