using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class ComandaController : IBaseController<Comanda>
    {
        private Contexto contexto = new Contexto();

        public void Delete(Comanda obj)
        {
            Comanda comanda = FindById(obj.ComandaID);

            if (comanda != null)
            {
                contexto.Comanda.Remove(comanda);
                contexto.SaveChanges();
            }
        }

        public void Edit(Comanda obj)
        {
            contexto.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public Comanda FindById(int id)
        {
            return contexto.Comanda.Find(id);
        }

        public IList<Comanda> List()
        {
            return contexto.Comanda.ToList();
        }

        public void Store(Comanda obj)
        {
            contexto.Comanda.Add(obj);
            contexto.SaveChanges();
        }
    }
}
