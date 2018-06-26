using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class VagaTipoController : IBaseController<VagaTipo>
    {
        private Contexto contexto = new Contexto();

        public void Delete(VagaTipo obj)
        {
            VagaTipo vagaTipo = FindById(obj.VagaTipoID);

            if (vagaTipo != null)
            {
                Singleton.Instancia.VagaTipo.Remove(vagaTipo);
                Singleton.Instancia.SaveChanges();
            }
        }

        public void Edit(VagaTipo obj)
        {
            Singleton.Instancia.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Singleton.Instancia.SaveChanges();
        }

        public VagaTipo FindById(int id)
        {
            return Singleton.Instancia.VagaTipo.Find(id);
        }

        public IList<VagaTipo> List()
        {
            return Singleton.Instancia.VagaTipo.ToList();
        }
        public void Store(VagaTipo obj)
        {
            Singleton.Instancia.VagaTipo.Add(obj);
            Singleton.Instancia.SaveChanges();
        }
    }
}
