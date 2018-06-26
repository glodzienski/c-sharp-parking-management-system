using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.DAL
{
    public class Singleton
    {
        private static Contexto instancia;

        public static Contexto Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Contexto();
                }
                return instancia;
            }
        }

    }
}
