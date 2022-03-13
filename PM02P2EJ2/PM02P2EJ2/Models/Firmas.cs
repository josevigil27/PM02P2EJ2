using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM02P2EJ2.Models
{
    public class Firmas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public String Nombre { get; set; }

        [MaxLength(100)]
        public String Descripcion { get; set; }

        public Byte[] Imagen { get; set; }
    }
}
