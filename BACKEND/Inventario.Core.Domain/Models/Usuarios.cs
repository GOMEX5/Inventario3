using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Domain.Models
{
    public class Usuarios
    {
        public Guid user_id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cargo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
