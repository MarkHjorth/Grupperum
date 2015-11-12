using GrupperumServer.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupperumServer
{
    public interface IGrumServer
    {
        String SayHello();
        Class getClassById(int id);
    }
}
