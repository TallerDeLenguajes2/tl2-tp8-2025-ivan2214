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
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Create(Presupuesto _presupuesto)
  {
    _presupuestoRepository.Create(_presupuesto);
    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public IActionResult Index()
  {
    var presupuestos = _presupuestoRepository.GetAll();
    return View(presupuestos);
  }

  [HttpGet]
  public IActionResult Detail(int id)
  {
    var presupuesto = _presupuestoRepository.GetById(id);
    return View(presupuesto);
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    var presupuesto = _presupuestoRepository.GetById(id);
    return View(presupuesto);
  }

  [HttpPost]
  public IActionResult Edit(Presupuesto presupuesto)
  {
    _presupuestoRepository.Edit(presupuesto);
    return RedirectToAction(nameof(Index));
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    var presupuesto = _presupuestoRepository.GetById(id);
    return View(presupuesto);
  }
  [HttpPost, ActionName("EliminarPresupuesto")]
  public IActionResult EliminarPresupuestoConfirmado(int id)
  {
    _presupuestoRepository.Delete(id);
    return RedirectToAction(nameof(Index));
  }
}