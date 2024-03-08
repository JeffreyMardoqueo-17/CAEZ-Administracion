using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEZ.Administracion.EN
{
    public class Direccion
    {
        [Key]
        public int Id { get; set; }

        //anotaciones de validacion
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(200, ErrorMessage = "Maximo de caracteres 200")]
        public string Nombre { get; set; } = string.Empty; //inicializo qeu es un string de logitud cero

    }
}
