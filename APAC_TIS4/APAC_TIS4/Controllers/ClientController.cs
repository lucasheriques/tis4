using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4.Controllers
{
    class ClientController
    {
        public Tuple<Boolean, string> Create(ClientModel client)
        {
            return Tuple.Create(true, "");
        }
    }
}
