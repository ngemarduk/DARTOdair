using System;
using System.Collections.Generic;
using System.Text;

namespace DinheiroRepository
{
    public interface IGenRepository<T>
    {
        IList<T> Lista();
    }
}
