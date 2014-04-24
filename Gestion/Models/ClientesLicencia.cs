﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gestion.Models
{
    [Table("ClientesLicencias")]
    public class ClientesLicencia
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Licencia")]
        public int LicenciaID { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int ClienteID { get; set; }

        [Required]
        [Display(Name = "DataSource")]
        public String CnnDataSource { get; set; }

        [Required]
        [Display(Name = "Catalog")]
        public String CnnCatalog { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public String CnnUser { get; set; }

        [Required]
        [Display(Name = "Password")]
        public String CnnPassword { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "DateTime2")]
        [Display(Name = "Fecha de Vencimiento")]
        public DateTime FechaDeVencimiento { get; set; }

        [Display(Name = "Servidor")]
        public String ConexionServidor { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Licencia Licencia { get; set; }

        public virtual IList<ClientesLicenciasProducto> ClientesLicenciasProductos { get; set; }


    }
}