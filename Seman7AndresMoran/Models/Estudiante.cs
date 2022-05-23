using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace Seman7AndresMoran.Models
{
    public class Estudiante
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(225)]
        public string Nombre { get; set; }
        [MaxLength(225)]
        public string Usuario { get; set; }
        [MaxLength(225)]
        public string Contrasena { get; set; }
    }
}
