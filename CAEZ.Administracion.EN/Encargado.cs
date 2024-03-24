using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAEZ.Administracion.EN
{
    public class Encargado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El tipo de documento es requerido")]
        [ForeignKey("TipoDocumento")]
        public int IdTipoDoc { get; set; }

        [Required(ErrorMessage = "El número de documento es requerido")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [ForeignKey("Direccion")]
        public int IdDireccion { get; set; }

        [Required(ErrorMessage = "El parentezco es requerido")]
        [ForeignKey("Parentezco")]
        public int IdParentezco { get; set; }

        [Required(ErrorMessage = "El administrador es requerido")]
        [ForeignKey("User")]
        public int IdAdministrador { get; set; }

        [Display(Name = "Fecha de registro")]
        public DateTime FechaRegistro { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; } // propiedad auxiliar PARA PODER DECIR CUANTOS REGISTROS QUIERO

    }
}
