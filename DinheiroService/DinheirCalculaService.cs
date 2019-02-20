using System;
using System.Collections.Generic;
using DinheiroRepository;
using DinheiroDomain;
using System.Linq;

namespace DinheiroService
{
    public class DinheirCalculaService
    {
        private CedulaRepository repCedula = new CedulaRepository();
        private MoedaRepository repMoeda = new MoedaRepository();

        /// <summary>
        /// Retorna a quantidade de cedulas e moedas a serem retornadas
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public List<string> DinheiroCalcula(decimal valor)
        {
            List<string> lstRetorno = new List<string>();

            var retCedula = CedulaCalcula(valor);

            retCedula.Item2.ForEach(strCedula => 
            {
                lstRetorno.Add("Cedula - "+ strCedula);
            });
            
            if (retCedula.Item1 > 0)
                MoedaCalcula(retCedula.Item1).ForEach(retMoeda=> 
                {
                    lstRetorno.Add("Moeda - " + retMoeda);
                });
            
            return lstRetorno;
        }

        /// <summary>
        /// Calcula a quantidade de cédulas a serem retornadas
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private Tuple<decimal, List<String>> CedulaCalcula(decimal valor)
        {
            List<String> lstTroco = new List<string>();
            List<decimal> lstCedulaValores = new List<decimal>();
            try
            {
                List<Cedula> lstCedulas = repCedula.Lista().ToList();

                lstCedulas.ForEach(moeda => {
                    lstCedulaValores.Add(moeda.valor);
                });

                var retTroco = CalculaTroco(valor, lstCedulaValores);

                return retTroco;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Calcula a quantidade de moedas a serem retornadas.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private List<String> MoedaCalcula(decimal valor)
        {
            List<String> lstTroco = new List<string>();
            List<decimal> lstMoedaValores = new List<decimal>();

            try
            {
                List<Moeda> lstMoedas = repMoeda.Lista().ToList();

                lstMoedas.ForEach(moeda => {
                    lstMoedaValores.Add(moeda.valor);
                });

                var retTroco = CalculaTroco(valor, lstMoedaValores);
                
                return retTroco.Item2;

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Método geral para retorno de quantidade de item
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="lstValores"></param>
        /// <returns></returns>
        private Tuple<decimal, List<String>> CalculaTroco(decimal valor, List<Decimal> lstValores )
        {
            List<String> lstRetorno = new List<string>();

            try
            {
                lstValores = lstValores.OrderByDescending(x => x).ToList();

                foreach (var unidadeValor in lstValores)
                {
                    if (unidadeValor != 0)
                    {
                        int contagem = (int)(valor / unidadeValor);
                        valor -= contagem * unidadeValor;

                        lstRetorno.Add(string.Format("Quantidade: {0} - Valor: {1}", contagem.ToString(), unidadeValor.ToString()));
                    }

                }
                return new Tuple<decimal, List<String>>(valor, lstRetorno);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
