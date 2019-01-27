using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExWebApiAutos.Model.VehiculoDb
{
    [Table("T_vehiculo")]
    public partial class TVehiculo
    {
        [Key]
        [Column("vehiculo_id")]
        public Guid VehiculoId { get; set; }
        [Required]
        [Column("vehiculo_color")]
        [StringLength(20)]
        public string VehiculoColor { get; set; }
        [Column("vehiculo_anio_fabri")]
        public int VehiculoAnioFabri { get; set; }
        [Required]
        [Column("vehiculo_placa")]
        [StringLength(20)]
        public string VehiculoPlaca { get; set; }
        [Column("vehiculo_nro_asientos")]
        public int VehiculoNroAsientos { get; set; }
        [Required]
        [Column("vehiculo_mecanico")]
        [StringLength(2)]
        public string VehiculoMecanico { get; set; }
        [Required]
        [Column("vehiculo_full")]
        [StringLength(2)]
        public string VehiculoFull { get; set; }
        [Column("marca_id")]
        public Guid MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        [InverseProperty("TVehiculo")]
        public TMarca Marca { get; set; }
    }
}
