using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class VeiculoController : IBaseController<Veiculo>
    {

        public void Delete(Veiculo obj)
        {
            Veiculo veiculo = FindById(obj.VeiculoID);

            if (veiculo != null)
            {
                Singleton.Instancia.Veiculo.Remove(veiculo);
                Singleton.Instancia.SaveChanges();
            }
        }

        public void Edit(Veiculo obj)
        {
            Singleton.Instancia.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Singleton.Instancia.SaveChanges();
        }

        public Veiculo FindById(int id)
        {
            return Singleton.Instancia.Veiculo.Find(id);
        }

        public IList<Veiculo> List()
        {
            return Singleton.Instancia.Veiculo.ToList();
        }

        public void Store(Veiculo obj)
        {
            Singleton.Instancia.Veiculo.Add(obj);
            Singleton.Instancia.SaveChanges();
        }
    }
}
