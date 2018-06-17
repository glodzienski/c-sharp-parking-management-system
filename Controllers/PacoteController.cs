using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class PacoteController : IBaseController<Pacote>
    {
        private Contexto contexto = new Contexto();

        public void Delete(Pacote obj)
        {
            Pacote pacote = FindById(obj.PacoteID);

            if (pacote != null)
            {
                contexto.Pacote.Remove(pacote);
                contexto.SaveChanges();
            }
        }

        public void Edit(Pacote obj)
        {
            contexto.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public Pacote FindById(int id)
        {
            return contexto.Pacote.Find(id);
        }

        public IList<Pacote> List()
        {
            return contexto.Pacote.ToList();
        }

        public IList<Pacote> ListByName(string name)
        {
            return contexto.Pacote.Where(servico => servico.Nome == name).ToList();
        }

        public void Store(Pacote obj)
        {
            contexto.Pacote.Add(obj);
            contexto.SaveChanges();
        }
    }
}
