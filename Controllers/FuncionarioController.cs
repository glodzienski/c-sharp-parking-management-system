using System.Collections.Generic;
using System.Linq;
using Controllers.Base;
using Controllers.DAL;
using Models;

namespace Controllers
{
    public class FuncionarioController : IBaseController<Funcionario>
    {
        private Contexto contexto = new Contexto();

        public void Delete(Funcionario obj)
        {
            Funcionario funcionario = FindById(obj.FuncionarioID);

            if (funcionario != null)
            {
                //1a forma
                //contexto.Entry(usu).State = System.Data.Entity.EntityState.Deleted;

                // 2a forma
                contexto.Funcionario.Remove(funcionario);
                contexto.SaveChanges();
            }
        }

        public void Edit(Funcionario obj)
        {
            contexto.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public Funcionario FindById(int id)
        {
            return contexto.Funcionario.Find(id);
        }

        public IList<Funcionario> List()
        {
            return contexto.Funcionario.ToList();
        }

        public IList<Funcionario> ListByName(string name)
        {
            return contexto.Funcionario.Where(func => func.Nome == name).ToList();
        }

        public void Store(Funcionario obj)
        {
            contexto.Funcionario.Add(obj);
            contexto.SaveChanges();
        }

        public Funcionario Login(string email, string password)
        {
            return contexto.Funcionario.Where(func => func.Email == email && func.Senha == password).FirstOrDefault<Funcionario>();
        }
    }
}
