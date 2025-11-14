using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class PresupuestoViewModels : IValidatableObject
    {
        public int IdPresupuesto { get; set; }

        [DisplayName("Nombre o email del Destinatario")]
        [Required(ErrorMessage = "Campo obligatorio: nombre o email")]
        public string NombreDestinatario { get; set; }

        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Fecha es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FechaCreacion > DateTime.Today)
            {
                yield return new ValidationResult(
                    "La fecha de creación no puede ser futura",
                    new[] { nameof(FechaCreacion) });
            }

            if (string.IsNullOrWhiteSpace(NombreDestinatario) && string.IsNullOrWhiteSpace(Email))
            {
                yield return new ValidationResult(
                    "Debe ingresar al menos NombreDestinatario o Email",
                    new[] { nameof(NombreDestinatario), nameof(Email) });
            }
        }
    }
}
