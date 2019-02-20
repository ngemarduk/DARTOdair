using DinheiroDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinheiroRepository
{
    public class CedulaRepository : ICedulaInterface
    {
        private readonly List<Cedula> lstCedula = new List<Cedula>(){
            new Cedula() { cedulaID = 1, valor=100.00m },
            new Cedula() { cedulaID = 2, valor=50.00m },
            new Cedula() { cedulaID = 3, valor=10.00m },
            new Cedula() { cedulaID = 4, valor=5.00m },
            new Cedula() { cedulaID = 5, valor=1.00m }
        };

        /// <summary>
        /// Lista de moedas cadastradas
        /// </summary>
        /// <returns>Objeto lista com as moedas cadastradas</returns>
        public IEnumerable<Cedula> Lista()
        {
            return lstCedula;
        }
    }
}
