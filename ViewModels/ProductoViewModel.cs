

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ViewModels
{
    public class ProductoViewModels
    {
        public int IdProducto { get; set; }

        [DisplayName("Descripción del Producto")]
        [StringLength(250, ErrorMessage = "No puede superar los 250 caracteres")]
        public string Descripcion { get; set; }

        [DisplayName("Precio del Producto")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser mayor a cero")]
        public double Precio { get; set; }

    }
}