using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace GobMxDummy.Models
{
    public class FormularioModels
    {
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El primer apellido es requerido.")]
        public string ApellidoPat { get; set; }
        [Required(ErrorMessage = "El segundo apellido es requerido.")]
        public string ApellidoMat { get; set; }
        [Required(ErrorMessage = "La lada es requerida.")]
        public string Lada { get; set; }
        [Required(ErrorMessage = "El teléfono es requerido.")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El correo eléctronico es requerido.")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "El sexo es requerido.")]
        public char Sexo { get; set; }
        [Required(ErrorMessage = "La nacionalidad es requerida.")]
        public char Nacionalidad { get; set; }
        [Required(ErrorMessage = "El estado civil es requerido.")]
        public string EstadoCivil { get; set; }
        [Required(ErrorMessage = "El tipo de vivienda es requerido.")]
        public string TipoVivienda { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        public DateTime FecNac { get; set; }
        [Required(ErrorMessage = "Debes aceptar los terminos y condiciones")]
        public bool AceptaTerminos { get; set; }

        public FormularioModels()
        {
            FecNac = DateTime.Today;
        }
    }
}