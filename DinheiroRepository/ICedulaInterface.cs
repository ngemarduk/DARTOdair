using System;
using System.Collections.Generic;
using DinheiroDomain;

namespace DinheiroRepository
{
    public interface ICedulaInterface
    {
        IEnumerable<Cedula> Lista();
    }
}
