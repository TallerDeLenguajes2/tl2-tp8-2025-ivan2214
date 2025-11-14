using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels;

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
    var productos = _productoRepository.GetAll();
    return View(productos);
  }

  [HttpGet]
  public IActionResult Detail(int id)
  {
    var producto = _productoRepository.GetById(id);
    return View(producto);
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    var producto = _productoRepository.GetById(id);
    return View(producto);
  }
  [HttpPost]
  public IActionResult Edit(Producto producto)
  {
    _productoRepository.Edit(producto.IdProducto, producto.Descripcion, producto.Precio);
    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    var producto = _productoRepository.GetById(id);
    return View(producto);
  }

  [HttpPost, ActionName("EliminarProducto")]
  public IActionResult EliminarProductoConfirmado(int id)
  {
    _productoRepository.Delete(id);
    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Create(ProductoViewModel productoVM)
  {
    if (!ModelState.IsValid)
    {
      return View(productoVM);
    }
    var producto = new Producto
    {
      Descripcion = productoVM.Descripcion,
      Precio = productoVM.Precio
    };

    _productoRepository.Create(producto);
    return RedirectToAction(nameof(Index));
  }
}