using Models;
using Microsoft.Data.Sqlite;

public class PresupuestoRepository : IPresupuestoRepository
{
  private string cadenaDeConexion = "Data Source = Tienda.db";

  public void CrearPresupuesto(Presupuesto _presupuesto)
  {
    using (var connection = new SqliteConnection(cadenaDeConexion))
    {
      connection.Open();

      string queryPresupuesto = "INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES (@nombre, @fecha)";
      var command = new SqliteCommand(queryPresupuesto, connection);
      command.Parameters.AddWithValue("@nombre", _presupuesto.NombreDestinatario);
      command.Parameters.AddWithValue("@fecha", _presupuesto.FechaCreacion.ToString("yyyy-MM-dd"));

      command.ExecuteNonQuery();

      connection.Close();
    }
  }

  public List<Presupuesto> ListarPresupuestos()
  {
    var listaPresupuestos = new List<Presupuesto>();
    string query = "SELECT * FROM Presupuestos";

    using (var connection = new SqliteConnection(cadenaDeConexion))
    {
      connection.Open();

      var command = new SqliteCommand(query, connection);

      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          var presupuesto = new Presupuesto
          {
            IdPresupuesto = Convert.ToInt32(reader["IdPresupuesto"]),
            NombreDestinatario = Convert.ToString(reader["NombreDestinatario"]),
            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
            Detalle = new List<PresupuestoDetalle>()
          };

          listaPresupuestos.Add(presupuesto);
        }
      }

      connection.Close();
    }
    return listaPresupuestos;
  }

  public Presupuesto ObtenerPresupuestoPorID(int id)
  {
    Presupuesto presupuesto = new Presupuesto();
    string query = "SELECT * FROM Presupuestos WHERE IdPresupuesto = @id";

    using (var connection = new SqliteConnection(cadenaDeConexion))
    {
      connection.Open();

      var command = new SqliteCommand(query, connection);
      command.Parameters.AddWithValue("@id", id);

      using (var reader = command.ExecuteReader())
      {
        if (reader.Read())
        {
          presupuesto = new Presupuesto
          {
            IdPresupuesto = Convert.ToInt32(reader["IdPresupuesto"]),
            NombreDestinatario = Convert.ToString(reader["NombreDestinatario"]),
            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
            Detalle = new List<PresupuestoDetalle>()
          };
        }
      }
      connection.Close();

      //Agrego el detalle al presupuesto
      presupuesto.Detalle = ObtenerDetallesPorID(id);
    }
    return presupuesto;
  }

  /*public List<PresupuestoDetalle> ObtenerDetallesPorID(int id)
  {
      List<PresupuestoDetalle> listaDetalles = new List<PresupuestoDetalle>();
      Producto productoAux = new Producto();
      string query = "SELECT * FROM PresupuestosDetalle WHERE IdPresupuesto = @id";

      using (var connection = new SqliteConnection(cadenaDeConexion))
      {
          connection.Open();

          var command = new SqliteCommand(query, connection);
          command.Parameters.AddWithValue("@id", id);

          using (var reader = command.ExecuteReader())
          {
              while (reader.Read())
              {
                  PresupuestoDetalle detalle = new PresupuestoDetalle
                  {
                      Producto = new Producto(),
                      Cantidad = Convert.ToInt32(reader["Cantidad"])
                  };
                  listaDetalles.Add(detalle);
              }
          }
          connection.Close();
      }

      return listaDetalles;
  }*/
  public List<PresupuestoDetalle> ObtenerDetallesPorID(int id)
  {
    List<PresupuestoDetalle> listaDetalles = new List<PresupuestoDetalle>();

    string query = @"
        SELECT pd.idProducto, pd.Cantidad, p.Descripcion, p.Precio 
        FROM PresupuestosDetalle pd 
        INNER JOIN Productos p ON pd.idProducto = p.idProducto 
        WHERE pd.IdPresupuesto = @id";

    using (var connection = new SqliteConnection(cadenaDeConexion))
    {
      connection.Open();

      var command = new SqliteCommand(query, connection);
      command.Parameters.AddWithValue("@id", id);

      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          PresupuestoDetalle detalle = new PresupuestoDetalle
          {
            Producto = new Producto
            {
              IdProducto = Convert.ToInt32(reader["IdProducto"]),
              Descripcion = Convert.ToString(reader["Descripcion"]),
              Precio = Convert.ToInt32(reader["Precio"])
            },
            Cantidad = Convert.ToInt32(reader["Cantidad"])
          };
          listaDetalles.Add(detalle);
        }
      }
      connection.Close();
    }

    return listaDetalles;
  }

  public void ModificarPresupuesto(Presupuesto presupuesto)
  {
    string queryPresupuesto = "UPDATE Presupuestos SET NombreDestinatario = @nombre, FechaCreacion = @fecha WHERE IdPresupuesto = @id";

    using (var connection = new SqliteConnection(cadenaDeConexion))
    {
      connection.Open();

      var command = new SqliteCommand(queryPresupuesto, connection);
      command.Parameters.AddWithValue("@nombre", presupuesto.NombreDestinatario);
      command.Parameters.AddWithValue("@fecha", presupuesto.FechaCreacion.ToString("yyyy-MM-dd"));
      command.Parameters.AddWithValue("@id", presupuesto.IdPresupuesto);
      command.ExecuteNonQuery();

      connection.Close();
    }
  }

  public void EliminarPresupuestoPorID(int id)
  {
    string queryEliminarPresupuesto = "DELETE FROM Presupuestos WHERE IdPresupuesto = @id";

    using (var connection = new SqliteConnection(cadenaDeConexion))
    {
      connection.Open();

      var presupuestoCommand = new SqliteCommand(queryEliminarPresupuesto, connection);
      presupuestoCommand.Parameters.AddWithValue("@id", id);
      presupuestoCommand.ExecuteNonQuery();

      connection.Close();

    }
  }
}