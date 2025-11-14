using Microsoft.AspNetCore.Mvc;
using Models;

public class ProductoController : Controller
{
  ProductoRepository _productoRepository;

  public ProductoController()
  {
    _productoRepository = new ProductoRepository();
  }

  [HttpGet]
  public IActionResult Index()
  {
    var productos = _productoRepository.ListarProductos();
    return View(productos);
  }

  [HttpGet]
  public IActionResult DetallesProducto(int id)
  {
    var producto = _productoRepository.ObtenerProductoPorID(id);
    return View(producto);
  }

  [HttpGet]
  public IActionResult EditarProducto(int id)
  {
    var producto = _productoRepository.ObtenerProductoPorID(id);
    return View(producto);
  }
  [HttpPost]
  public IActionResult EditarProducto(Producto producto)
  {
    _productoRepository.ModificarProducto(producto.IdProducto, producto.Descripcion, producto.Precio);
    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public IActionResult EliminarProducto(int id)
  {
    var producto = _productoRepository.ObtenerProductoPorID(id);
    return View(producto);
  }

  [HttpPost, ActionName("EliminarProducto")]
  public IActionResult EliminarProductoConfirmado(int id)
  {
    _productoRepository.EliminarProductoPorID(id);
    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public IActionResult CrearProducto()
  {
    return View();
  }

  [HttpPost]
  public IActionResult CrearProducto(Producto producto)
  {
    _productoRepository.CrearProducto(producto);
    return RedirectToAction(nameof(Index));
  }
}