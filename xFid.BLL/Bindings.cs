using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using xFid.Data;

namespace xFid.BLL
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<Repository>().To<FileRepository>();
        }
    }
}
