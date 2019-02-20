using System;
using System.Collections.Generic;
using DinheiroService;

namespace DartOdairCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal valorTotal;
            decimal valorArg;
            
            if (args.Length == 2)
            {
                if (decimal.TryParse(args[1], out valorTotal))
                {
                    if (decimal.TryParse(args[1], out valorArg))
                        Calcula(valorTotal, valorArg);
                }

                Sair(string.Empty);
            }
            else
            {
                
                Console.WriteLine("Digite o total da compra valor");
                if (decimal.TryParse(Console.ReadLine(), out valorTotal))
                {
                    Console.WriteLine("Digite o valor pago");
                    if (decimal.TryParse(Console.ReadLine(), out valorArg))
                    {
                        Calcula(valorTotal, valorArg);
                    }
                    else
                    {
                        Sair("Digite somente números");
                    }
                }
                
            }
        }

        private static void Calcula(decimal valorTotal, decimal valorPago)
        {
            List<string> retCedula = new List<string>();
            try
            {
                DinheirCalculaService dinCalServ = new DinheirCalculaService();

                decimal valorRest = valorPago - valorTotal;

                if(valorRest > 0)
                { 
                    retCedula = dinCalServ.DinheiroCalcula(valorRest);

                    if(retCedula != null)
                    { 
                        retCedula.ForEach(ret =>
                        {
                            Console.WriteLine();
                            Console.WriteLine(ret);
                        });
                    }
                    else {
                        Console.WriteLine("Infelizmente não foi possível calcular a quantidade de cédulas e moedas.");
                    }
                }
                else
                {
                    Console.WriteLine("O valor pago não é igual ou maior que o total.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao calcular a quantidade de cédulas e moedas: " + ex);
            }

            Sair(string.Empty);
        }

        private static void Sair(string mensagem)
        {
            if (mensagem.Length > 0)
                Console.WriteLine(mensagem);

            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Clique em qualquer tecla para sair...");

            Environment.Exit(0);
        }
    }
}
