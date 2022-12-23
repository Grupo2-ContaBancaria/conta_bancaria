using ContaBancaria_Grupo2;
using System.Reflection.Metadata.Ecma335;

namespace ContaBancaria_Grupo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trabalho Final - POO_Modulo_2");


            try
            {
                Console.WriteLine("---- Banco Grupo 2 ----\n");
                //Definir como iniciar a solução
                Console.WriteLine("Seja bem vindo:\nO que deseja fazer:\n(1)Abrir Conta\n(2)Acessar Conta");

                //chamar a função que converte para numero, lá será feito o readline e a conversão até que seja digitado um numero valido.
                int retorno = ValidadorEConversorNumerico.ConverterParaNumero();

                if (retorno == 1)
                {
                    
                    // Perguntar qual tipo de conta deseja Abrir, para mandar para a classe especifica
                    Console.WriteLine("Qual tipo de conta deseja abrir:\n(1)Conta Poupança\n(2)Conta Investimento\n(3)Conta Salário\n Digite o numeral correspondente:");

                    //chamar a função que converte para numero
                    retorno = ValidadorEConversorNumerico.ConverterParaNumero();

                    //Chamar a função de Abrir Conta 
                    AbrirConta.AbrirContas(retorno);


                }
                else if (retorno == 2)
                {
                    //Chamar a classe acessar conta
                    
                    AcessarContaExistente.AcessandoContaExistente();
                }




            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);

            }

        }
    }
}