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
                //contexto.Entry(usu).State = System.Data.Entity.EntityState.Deleted;

                // 2a forma
                contexto.Cliente.Remove(cliente);
                contexto.SaveChanges();
            }
        }

        public void Edit(Cliente obj)
        {
            contexto.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public Cliente FindById(int id)
        {
            return contexto.Cliente.Find(id);
        }

        public IList<Cliente> List()
        {
            return contexto.Cliente.ToList();
        }

        public IList<Cliente> ListByName(string name)
        {
            return contexto.Cliente.Where(cliente => cliente.Nome == name).ToList();
        }

        public void Store(Cliente obj)
        {
            contexto.Cliente.Add(obj);
            contexto.SaveChanges();
        }
    }
}
