
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ViewModels
{
    public class AgregarProductoViewModels
    {
        [Required]
        public int IdPresupuesto { get; set; }

        [DisplayName("Producto")]
        [Required(ErrorMessage = "Debe seleccionar un producto")]
        public int IdProducto { get; set; }

        [DisplayName("Cantidad")]
        [Required(ErrorMessage = "Debe ingresar una cantidad")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero")]
        public int Cantidad { get; set; }


        // Propiedad adicional para el Dropdown (no se valida, solo se usa en la Vista)
        public SelectList Productos { get; set; }


    }
}