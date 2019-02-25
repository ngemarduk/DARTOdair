using DinheiroDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinheiroRepository
{
    public class DinherioDadosRepository: IDinherioDadosInterface
    {
        private readonly List<Dinheiro> lstDinheiro = new List<Dinheiro>(){
            new Dinheiro() { dinheiroID = 1, tipo=1, valor=100},
            new Dinheiro() { dinheiroID = 2, tipo=1, valor=50 },
            new Dinheiro() { dinheiroID = 3, tipo=1, valor=10 },
            new Dinheiro() { dinheiroID = 4, tipo=1, valor=5 },
            new Dinheiro() { dinheiroID = 5, tipo=1, valor=1 },
            new Dinheiro() { dinheiroID = 6, tipo=1, valor=0.5m },
            new Dinheiro() { dinheiroID = 7, tipo=1, valor=0.1m },
            new Dinheiro() { dinheiroID = 8, tipo=1, valor=0.05m },
            new Dinheiro() { dinheiroID = 9, tipo=1, valor=0.01m }
        };


        public IEnumerable<Dinheiro> Lista()
        {
            return lstDinheiro;
        }
    }
}
