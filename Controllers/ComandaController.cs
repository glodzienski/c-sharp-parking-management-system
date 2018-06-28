using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Enumerable;
using Models;

namespace Controllers
{
    public class ComandaController : IBaseController<Comanda>
    {
        public void Delete(Comanda obj)
        {
            Comanda comanda = FindById(obj.ComandaID);

            if (comanda != null)
            {
                Singleton.Instancia.Comanda.Remove(comanda);
                Singleton.Instancia.SaveChanges();
            }
        }

        public void Edit(Comanda obj)
        {
            Singleton.Instancia.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Singleton.Instancia.SaveChanges();
        }

        public Comanda FindById(int id)
        {
            return Singleton.Instancia.Comanda.Find(id);
        }

        public IList<Comanda> List()
        {
            return Singleton.Instancia.Comanda.ToList();
        }

        public IList<Comanda> FindByStatus(int status)
        {
            return Singleton.Instancia.Comanda.Where(comanda => comanda.ComandaStatusID == status).ToList();
        }

        public void Store(Comanda obj)
        {
            Singleton.Instancia.Comanda.Add(obj);
            Singleton.Instancia.SaveChanges();
        }

        public void Fechar(Comanda comanda)
        {
            comanda.ComandaStatusID = ComandaStatusEnum.Fechada;
            Singleton.Instancia.Entry(comanda).State = System.Data.Entity.EntityState.Modified;
            Singleton.Instancia.SaveChanges();
        }
    }
}
