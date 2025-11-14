using Models;

public interface IPresupuestoRepository
{
    public void Create(Presupuesto _presupuesto);
    public List<Presupuesto> GetAll();
    public Presupuesto GetById(int _id);
    public void Edit(Presupuesto _presupuesto);
    public void Delete(int _id);
}