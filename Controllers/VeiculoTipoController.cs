using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class VeiculoTipoController : IBaseController<VeiculoTipo>
    {
        private Contexto contexto = new Contexto();

        public void Delete(VeiculoTipo obj)
        {
            VeiculoTipo veiculoTipo = FindById(obj.VeiculoTipoID);

            if (veiculoTipo != null)
            {
                contexto.VeiculoTipo.Remove(veiculoTipo);
                contexto.SaveChanges();
            }
        }

        public void Edit(VeiculoTipo obj)
        {
            contexto.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public VeiculoTipo FindById(int id)
        {
            return contexto.VeiculoTipo.Find(id);
        }

        public IList<VeiculoTipo> List()
        {
            return contexto.VeiculoTipo.ToList();
        }
        public void Store(VeiculoTipo obj)
        {
            contexto.VeiculoTipo.Add(obj);
            contexto.SaveChanges();
        }
    }
}
