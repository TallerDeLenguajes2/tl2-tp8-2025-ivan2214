

namespace Models
{
  public class PresupuestoDetalle
  {
    public Producto Producto { get; set; } = new Producto();
    public int Cantidad { get; set; }
  }
}
