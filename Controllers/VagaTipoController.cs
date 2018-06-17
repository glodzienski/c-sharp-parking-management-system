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
                contexto.VagaTipo.Remove(vagaTipo);
                contexto.SaveChanges();
            }
        }

        public void Edit(VagaTipo obj)
        {
            contexto.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public VagaTipo FindById(int id)
        {
            return contexto.VagaTipo.Find(id);
        }

        public IList<VagaTipo> List()
        {
            return contexto.VagaTipo.ToList();
        }
        public void Store(VagaTipo obj)
        {
            contexto.VagaTipo.Add(obj);
            contexto.SaveChanges();
        }
    }
}
