using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class VagaController : IBaseController<Vaga>
    {

        public void Delete(Vaga obj)
        {
            Vaga vaga = FindById(obj.VagaID);

            if (vaga != null)
            {
                Singleton.Instancia.Vaga.Remove(vaga);
                Singleton.Instancia.SaveChanges();
            }
        }

        public void Edit(Vaga obj)
        {
            Singleton.Instancia.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Singleton.Instancia.SaveChanges();
        }

        public Vaga FindById(int id)
        {
            return Singleton.Instancia.Vaga.Find(id);
        }

        public IList<Vaga> List(bool ocupadas = false, bool ativas = true)
        {
            return Singleton.Instancia.Vaga.Where(vaga => vaga.Ocupada == ocupadas && vaga.Ativo == ativas).ToList();
        }

        public IList<Vaga> List()
        {
            return Singleton.Instancia.Vaga.ToList();
        }

        public void Store(Vaga obj)
        {
            Singleton.Instancia.Vaga.Add(obj);
            Singleton.Instancia.SaveChanges();
        }
    }
}
