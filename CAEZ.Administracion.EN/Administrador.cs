using CAEZ.Administracion.EN;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAEZ.Administracion.EN
{
    public class Administrador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El cargo es requerido")]
        [Display(Name = "Cargo")]
        public int IdCargo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo 7")]
        public string Telefono { get; set; } // Propiedad de teléfono

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [MaxLength(25, ErrorMessage = "Máximo 25 caracteres")]
        [Display(Name = "Nombre de usuario")]
        public string Login { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "La contraseña debe tener entre 6 y 32 caracteres", MinimumLength = 6)]
        public string Pass { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [Display(Name = "Estado")]
        public byte Estado { get; set; }

        [Display(Name = "Fecha de registro")]
        public DateTime FechaRegistro { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "La confirmación de contraseña es requerida")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "La contraseña debe tener entre 6 y 32 caracteres", MinimumLength = 6)]
        [Compare("Pass", ErrorMessage = "Las contraseñas no coinciden")]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmPass { get; set; }

        public Cargo? Cargo { get; set; }
    }

    public enum User_Status
    {
        ACTIVO = 1, INACTIVO = 2
    }
}
