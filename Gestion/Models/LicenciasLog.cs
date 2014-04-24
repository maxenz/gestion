using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Gestion.Models
{
    [Table("LicenciasLogs")]
    public class LicenciasLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int LicenciaID { get; set; }

        public int SolicitudID { get; set; }

        [Required]
        public String IP { get; set; }

        public String Referencias { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

    }
}