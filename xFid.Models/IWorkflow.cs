using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace xFid.Models
{
    public interface IWorkflow
    {
        void Execute();
    }
}
