using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Core.Domain.Models
{
    public class Mantenimiento
    {
        public Guid user_id { get; set; }
        public Guid lab_id { get; set; }
        public DateTime fecha { get; set; }
        public string info { get; set; }

        [ForeignKey("user_id")]
        public Usuarios usuarios { get; set; }

        [ForeignKey("lab_id")]
        public Laboratorios laboratorios { get; set; }
   }
}
