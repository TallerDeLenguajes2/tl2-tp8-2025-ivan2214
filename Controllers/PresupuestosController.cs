using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Models;

public class PresupuestoController : Controller
{
  private PresupuestoRepository _presupuestoRepository;

  public PresupuestoController()
  {
    _presupuestoRepository = new PresupuestoRepository();
  }

  [HttpGet]
  public IActionResult CrearPresupuesto()
  {
    return View();
  }

  [HttpPost]
  public IActionResult CrearPresupuesto(Presupuesto _presupuesto)
  {
    _presupuestoRepository.CrearPresupuesto(_presupuesto);
    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public IActionResult Index()
  {
    var presupuestos = _presupuestoRepository.ListarPresupuestos();
    return View(presupuestos);
  }

  [HttpGet]
  public IActionResult DetallesPresupuesto(int id)
  {
    var presupuesto = _presupuestoRepository.ObtenerPresupuestoPorID(id);
    return View(presupuesto);
  }

  [HttpGet]
  public IActionResult EditarPresupuesto(int id)
  {
    var presupuesto = _presupuestoRepository.ObtenerPresupuestoPorID(id);
    return View(presupuesto);
  }

  [HttpPost]
  public IActionResult EditarPresupuesto(Presupuesto presupuesto)
  {
    _presupuestoRepository.ModificarPresupuesto(presupuesto);
    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public IActionResult EliminarPresupuesto(int id)
  {
    var presupuesto = _presupuestoRepository.ObtenerPresupuestoPorID(id);
    return View(presupuesto);
  }
  [HttpPost, ActionName("EliminarPresupuesto")]
  public IActionResult EliminarPresupuestoConfirmado(int id)
  {
    _presupuestoRepository.EliminarPresupuestoPorID(id);
    return RedirectToAction(nameof(Index));
  }
}