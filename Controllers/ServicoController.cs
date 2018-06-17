using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class ServicoController : IBaseController<Servico>
    {
        private Contexto contexto = new Contexto();

        public void Delete(Servico obj)
        {
            Servico servico = FindById(obj.ServicoID);

            if (servico != null)
            {
                contexto.Servico.Remove(servico);
                contexto.SaveChanges();
            }
        }

        public void Edit(Servico obj)
        {
            contexto.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public Servico FindById(int id)
        {
            return contexto.Servico.Find(id);
        }

        public IList<Servico> List()
        {
            return contexto.Servico.ToList();
        }

        public IList<Servico> ListByName(string name)
        {
            return contexto.Servico.Where(servico => servico.Nome == name).ToList();
        }

        public void Store(Servico obj)
        {
            contexto.Servico.Add(obj);
            contexto.SaveChanges();
        }
    }
}
