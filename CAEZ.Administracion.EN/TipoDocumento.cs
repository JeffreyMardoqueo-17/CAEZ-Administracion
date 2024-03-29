﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAEZ.Administracion.EN
{
    public class TipoDocumento
    {
        [Key]
        public int Id { get; set; }

        //anotaciones de validacion
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(80, ErrorMessage = "Maximo de caracteres 80")]
        public string Nombre { get; set; } = string.Empty; //inicializo qeu es un string de logitud cero

    }
}
