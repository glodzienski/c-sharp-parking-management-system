using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class ComandaStatusController : IBaseController<ComandaStatus>
    {
        public void Delete(ComandaStatus obj)
        {
            ComandaStatus comandaStatus = FindById(obj.ComandaStatusID);

            if (comandaStatus!= null)
            {
                Singleton.Instancia.ComandaStatus.Remove(comandaStatus);
                Singleton.Instancia.SaveChanges();
            }
        }

        public void Edit(ComandaStatus obj)
        {
            Singleton.Instancia.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Singleton.Instancia.SaveChanges();
        }

        public ComandaStatus FindById(int id)
        {
            return Singleton.Instancia.ComandaStatus.Find(id);
        }

        public IList<ComandaStatus> List()
        {
            return Singleton.Instancia.ComandaStatus.ToList();
        }
        public void Store(ComandaStatus obj)
        {
            Singleton.Instancia.ComandaStatus.Add(obj);
            Singleton.Instancia.SaveChanges();
        }
    }
}
