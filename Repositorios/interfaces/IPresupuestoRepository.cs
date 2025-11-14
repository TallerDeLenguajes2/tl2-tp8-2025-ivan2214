using Models;

public interface IPresupuestoRepository
{
    public void CrearPresupuesto(Presupuesto _presupuesto);
    public List<Presupuesto> ListarPresupuestos();
    public Presupuesto ObtenerPresupuestoPorID(int _id);
    public void ModificarPresupuesto(Presupuesto _presupuesto);
    public void EliminarPresupuestoPorID(int _id);
}