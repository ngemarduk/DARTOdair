using System;
using System.Collections.Generic;
using DinheiroDomain;

namespace DinheiroRepository
{
    public interface IMoedaInterface
    {
        IEnumerable<Moeda> Lista();
    }
}
