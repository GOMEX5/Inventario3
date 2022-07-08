using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Domain.Models
{
    public class Laboratorios
    {
        public Guid lab_id { get; set; }
        public int num_pc { get; set; }
        public string Estado { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
