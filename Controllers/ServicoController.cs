using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class ServicoController : IBaseController<Servico>
    {
        public void Delete(Servico obj)
        {
            Servico servico = FindById(obj.ServicoID);

            if (servico != null)
            {
                Singleton.Instancia.Servico.Remove(servico);
                Singleton.Instancia.SaveChanges();
            }
        }

        public void Edit(Servico obj)
        {
            Singleton.Instancia.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Singleton.Instancia.SaveChanges();
        }

        public Servico FindById(int id)
        {
            return Singleton.Instancia.Servico.Find(id);
        }

        public IList<Servico> List()
        {
            return Singleton.Instancia.Servico.ToList();
        }

        public IList<Servico> ListByName(string name)
        {
            return Singleton.Instancia.Servico.Where(servico => servico.Nome == name).ToList();
        }

        public void Store(Servico obj)
        {
            Singleton.Instancia.Servico.Add(obj);
            Singleton.Instancia.SaveChanges();
        }
    }
}
