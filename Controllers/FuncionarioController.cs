using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class FuncionarioController : IBaseController<Funcionario>
    {
        public void Delete(Funcionario obj)
        {
            Funcionario funcionario = FindById(obj.FuncionarioID);

            if (funcionario != null)
            {
                //1a forma
                //Singleton.Instancia.Entry(usu).State = System.Data.Entity.EntityState.Deleted;

                // 2a forma
                Singleton.Instancia.Funcionario.Remove(funcionario);
                Singleton.Instancia.SaveChanges();
            }
        }

        public void Edit(Funcionario obj)
        {
            Singleton.Instancia.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Singleton.Instancia.SaveChanges();
        }

        public Funcionario FindById(int id)
        {
            return Singleton.Instancia.Funcionario.Find(id);
        }

        public IList<Funcionario> List()
        {
            return Singleton.Instancia.Funcionario.ToList();
        }

        public IList<Funcionario> ListByName(string name)
        {
            return Singleton.Instancia.Funcionario.Where(func => func.Nome == name).ToList();
        }

        public void Store(Funcionario obj)
        {
            Singleton.Instancia.Funcionario.Add(obj);
            Singleton.Instancia.SaveChanges();
        }

        public Funcionario Login(string email, string password)
        {
            return Singleton.Instancia.Funcionario.Where(func => func.Email == email && func.Senha == password).FirstOrDefault<Funcionario>();
        }
    }
}
