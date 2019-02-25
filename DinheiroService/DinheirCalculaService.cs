using System;
using System.Collections.Generic;
using DinheiroRepository;
using DinheiroDomain;
using System.Linq;

namespace DinheiroService
{
    public class DinheirCalculaService
    {
        private DinherioDadosRepository repDinheiro = new DinherioDadosRepository();

        /// <summary>
        /// Retorna a quantidade de cedulas e moedas a serem retornadas
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public List<string> DinheiroCalcula(decimal valorTotal, decimal valorPago)
        {
            List<string> lstRetorno = new List<string>();
            List<Dinheiro> lstDinheiro = repDinheiro.Lista().ToList();
            
            decimal troco = CalculaTroco(valorTotal, valorPago);

            if (troco > 0)
            {
                var retCalculo = CalculaItensDinheiro(troco, lstDinheiro);

                if (retCalculo != null)
                    lstRetorno = retCalculo;
                else
                    lstRetorno.Add("Não foi possível fazer o cálculo");
            }
            else {
                if (troco == 0)
                {
                    lstRetorno.Add("Não há troco");
                }
                else {
                    lstRetorno.Add(string.Format("O dinherio do pagamento não é o suficiente para o pagamento total. Faltam: {0}", troco * (-1) ));
                }
            }
            
            return lstRetorno;
        }

        private decimal CalculaTroco(decimal valorTotal, decimal valorPago)
        {
            return valorPago - valorTotal;
        }
        
        /// <summary>
        /// Método geral para retorno de quantidade de item
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="lstValores"></param>
        /// <returns></returns>
        private  List<String> CalculaItensDinheiro(decimal valor, List<Dinheiro> lstValores )
        {
            List<String> lstRetorno = new List<string>();

            try
            {
                lstValores = lstValores.OrderByDescending(x => x.valor).ToList();

                foreach (var unidadeValor in lstValores)
                {
                    if (unidadeValor.valor != 0)
                    {
                        int contagem = (int)(valor / unidadeValor.valor);
                        valor -= contagem * unidadeValor.valor;

                        lstRetorno.Add(string.Format("Quantidade: {0} - Valor: {1}", contagem.ToString(), unidadeValor.valor.ToString()));
                    }

                }
                return lstRetorno;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
