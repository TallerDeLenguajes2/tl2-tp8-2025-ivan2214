using Models;

public interface IProductoRepository
{
    public void Create(Producto _producto);

    public void Edit(int _id, string _nuevoNombre, double _nuevoPrecio);
    public List<Producto> GetAll();

    public Producto GetById(int _id);

    public void Delete(int _id);
}