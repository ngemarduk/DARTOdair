using DinheiroDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinheiroRepository
{
    public interface IDinherioDadosInterface
    {
        IEnumerable<Dinheiro> Lista();
    }
}
