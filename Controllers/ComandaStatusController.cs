using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class ComandaStatusController : IBaseController<ComandaStatus>
    {
        private Contexto contexto = new Contexto();

        public void Delete(ComandaStatus obj)
        {
            ComandaStatus comandaStatus = FindById(obj.ComandaStatusID);

            if (comandaStatus!= null)
            {
                contexto.ComandaStatus.Remove(comandaStatus);
                contexto.SaveChanges();
            }
        }

        public void Edit(ComandaStatus obj)
        {
            contexto.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public ComandaStatus FindById(int id)
        {
            return contexto.ComandaStatus.Find(id);
        }

        public IList<ComandaStatus> List()
        {
            return contexto.ComandaStatus.ToList();
        }
        public void Store(ComandaStatus obj)
        {
            contexto.ComandaStatus.Add(obj);
            contexto.SaveChanges();
        }
    }
}
