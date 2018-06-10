using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Base
{
    interface IBaseController<Model>
    {
        void Store(Model obj);

        void Edit(Model obj);

        void Delete(Model obj);
        Model FindById(int id);
        IList<Model> List();
        IList<Model> ListByName(string name);
    }
}
