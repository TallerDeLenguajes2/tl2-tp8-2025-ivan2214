using Models;

public interface IProductoRepository
{
    public void CrearProducto(Producto _producto);

    public void ModificarProducto(int _id, string _nuevoNombre, double _nuevoPrecio);
    public List<Producto> ListarProductos();

    public Producto ObtenerProductoPorID(int _id);

    public void EliminarProductoPorID(int _id);
}