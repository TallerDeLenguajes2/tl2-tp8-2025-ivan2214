using Microsoft.Data.Sqlite;
using Models;

public class ProductoRepository : IProductoRepository
{
  private string cadenaDeConexion = "Data Source = Tienda.db";
  public void Create(Producto _producto)
  {
    string query = "INSERT INTO Productos (Descripcion, Precio) VALUES (@des,@pre)";


    using (var connection = new SqliteConnection(cadenaDeConexion))
    {
      connection.Open();

      var command = new SqliteCommand(query, connection);
      command.Parameters.AddWithValue("@des", _producto.Descripcion);
      command.Parameters.AddWithValue("pre", _producto.Precio);

      command.ExecuteNonQuery();

      connection.Close();
    }

  }

  public void Edit(int _id, string _nuevoNombre, double _nuevoPrecio)
  {
    string query = "UPDATE Productos SET Descripcion = @nuevaDes, Precio = @nuevoPrecio WHERE IDProducto = @id";

    using (var connection = new SqliteConnection(cadenaDeConexion))
    {
      connection.Open();

      var command = new SqliteCommand(query, connection);

      command.Parameters.AddWithValue("@nuevaDes", _nuevoNombre);
      command.Parameters.AddWithValue("@nuevoPrecio", _nuevoPrecio);
      command.Parameters.AddWithValue("@id", _id);

      command.ExecuteNonQuery();

      connection.Close();
    }
  }
  public List<Producto> GetAll()
  {
    List<Producto> listaProductos = new List<Producto>();
    string query = "SELECT * FROM Productos";

    using (var connection = new SqliteConnection(cadenaDeConexion))
    {
      connection.Open();

      var command = new SqliteCommand(query, connection);

      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          var producto = new Producto
          {
            IdProducto = Convert.ToInt32(reader["IdProducto"]),
            Descripcion = Convert.ToString(reader["Descripcion"]),
            Precio = Convert.ToInt32(reader["Precio"])
          };

          listaProductos.Add(producto);
        }
      }

      connection.Close();
    }
    return listaProductos;
  }

  public Producto GetById(int _id)
  {
    Producto producto = new Producto();
    string query = "SELECT * FROM Productos WHERE IDProducto = @id";

    using (var connection = new SqliteConnection(cadenaDeConexion))
    {

      connection.Open();

      var command = new SqliteCommand(query, connection);
      command.Parameters.AddWithValue("@id", _id);

      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          producto.IdProducto = Convert.ToInt32(reader["IdProducto"]);
          producto.Descripcion = Convert.ToString(reader["Descripcion"]);
          producto.Precio = Convert.ToInt32(reader["Precio"]);
        }
      }

      connection.Close();
    }
    return producto;
  }

  public void Delete(int _id)
  {
    string query = "DELETE FROM Productos WHERE IDProducto = @id";

    using (var connection = new SqliteConnection(cadenaDeConexion))
    {
      connection.Open();

      var command = new SqliteCommand(query, connection);
      command.Parameters.AddWithValue("@id", _id);
      command.ExecuteNonQuery();

      connection.Close();
    }
  }
}