using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace  Registros.Entidades{

public class Personas{
        internal int id;

        [Key]
        public int ID { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
        public String Cedula { get; set; }
        public String Direccion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        public Personas()
        {
            ID = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Fecha= DateTime.Now;
        
        }
}
}