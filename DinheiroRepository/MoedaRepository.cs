using DinheiroDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinheiroRepository
{
    public class MoedaRepository : IMoedaInterface
    {
        private readonly List<Moeda> lstMoeda = new List<Moeda>(){
            new Moeda() { moedaID = 1, valor=0.5m },
            new Moeda() { moedaID = 2, valor=0.1m },
            new Moeda() { moedaID = 3, valor=0.05m },
            new Moeda() { moedaID = 4, valor=0.01m }
        };

        /// <summary>
        /// Lista de moedas cadastradas
        /// </summary>
        /// <returns>Objeto lista com as moedas cadastradas</returns>
        public IEnumerable<Moeda> Lista()
        {
            return lstMoeda;
        }
    }
}
