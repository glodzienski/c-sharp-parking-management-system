using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Base
{
    public class BaseController : IBaseController<Model>
    {
        public BaseController(Type className)
        {
            this.Entitie = (Model)Activator.CreateInstance(className);
            // TODO aqui cria a lista
        }

        public Model Entitie { get; set; }

        public IList<Model> List { get; set; }

        public void Delete(Model obj)
        {
            throw new NotImplementedException();
        }

        public void Edit(Model obj)
        {
            throw new NotImplementedException();
        }

        public Model FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Model> List()
        {
            throw new NotImplementedException();
        }

        public IList<Model> ListByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Store(Model obj)
        {
            throw new NotImplementedException();
        }
    }
}
