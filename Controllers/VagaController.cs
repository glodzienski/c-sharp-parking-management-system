using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class VagaController : IBaseController<Vaga>
    {
        private Contexto contexto = new Contexto();

        public void Delete(Vaga obj)
        {
            Vaga vaga = FindById(obj.VagaID);

            if (vaga != null)
            {
                contexto.Vaga.Remove(vaga);
                contexto.SaveChanges();
            }
        }

        public void Edit(Vaga obj)
        {
            contexto.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public Vaga FindById(int id)
        {
            return contexto.Vaga.Find(id);
        }

        public IList<Vaga> List()
        {
            return contexto.Vaga.ToList();
        }
        public void Store(Vaga obj)
        {
            contexto.Vaga.Add(obj);
            contexto.SaveChanges();
        }
    }
}
