using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class ClienteController : IBaseController<Cliente>
    {
        private Contexto contexto = new Contexto();

        public void Delete(Cliente obj)
        {
            Cliente cliente = FindById(obj.ClienteID);

            if (cliente != null)
            {
                //1a forma
                //Singleton.Instancia.Entry(usu).State = System.Data.Entity.EntityState.Deleted;

                // 2a forma
                Singleton.Instancia.Cliente.Remove(cliente);
                Singleton.Instancia.SaveChanges();
            }
        }

        public void Edit(Cliente obj)
        {
            Singleton.Instancia.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Singleton.Instancia.SaveChanges();
        }

        public Cliente FindById(int id)
        {
            return Singleton.Instancia.Cliente.Find(id);
        }

        public IList<Cliente> List()
        {
            return Singleton.Instancia.Cliente.ToList();
        }

        public IList<Cliente> ListByName(string name)
        {
            return Singleton.Instancia.Cliente.Where(cliente => cliente.Nome == name).ToList();
        }

        public void Store(Cliente obj)
        {
            Singleton.Instancia.Cliente.Add(obj);
            Singleton.Instancia.SaveChanges();
        }
    }
}
