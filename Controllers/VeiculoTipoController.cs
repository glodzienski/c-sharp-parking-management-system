using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class VeiculoTipoController : IBaseController<VeiculoTipo>
    {
        public void Delete(VeiculoTipo obj)
        {
            VeiculoTipo veiculoTipo = FindById(obj.VeiculoTipoID);

            if (veiculoTipo != null)
            {
                Singleton.Instancia.VeiculoTipo.Remove(veiculoTipo);
                Singleton.Instancia.SaveChanges();
            }
        }

        public void Edit(VeiculoTipo obj)
        {
            Singleton.Instancia.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Singleton.Instancia.SaveChanges();
        }

        public VeiculoTipo FindById(int id)
        {
            return Singleton.Instancia.VeiculoTipo.Find(id);
        }

        public IList<VeiculoTipo> List()
        {
            return Singleton.Instancia.VeiculoTipo.ToList();
        }
        public void Store(VeiculoTipo obj)
        {
            Singleton.Instancia.VeiculoTipo.Add(obj);
            Singleton.Instancia.SaveChanges();
        }
    }
}
