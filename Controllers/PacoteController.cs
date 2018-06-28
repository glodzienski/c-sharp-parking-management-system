using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class PacoteController : IBaseController<Pacote>
    {
        public void Delete(Pacote obj)
        {
            Pacote pacote = FindById(obj.PacoteID);

            if (pacote != null)
            {
                Singleton.Instancia.Pacote.Remove(pacote);
                Singleton.Instancia.SaveChanges();
            }
        }

        public void Edit(Pacote obj)
        {
            Singleton.Instancia.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Singleton.Instancia.SaveChanges();
        }

        public Pacote FindById(int id)
        {
            return Singleton.Instancia.Pacote.Find(id);
        }

        public IList<Pacote> List()
        {
            return Singleton.Instancia.Pacote.ToList();
        }

        public IList<Pacote> ListByName(string name)
        {
            return Singleton.Instancia.Pacote.Where(servico => servico.Nome == name).ToList();
        }

        public void Store(Pacote obj)
        {
            Singleton.Instancia.Pacote.Add(obj);
            Singleton.Instancia.SaveChanges();
        }
    }
}
