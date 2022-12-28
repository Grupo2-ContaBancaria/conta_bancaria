using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria_Grupo2
{
    public class AcessarContaExistente
    {
        public static void AcessandoContaExistente()
        {
            Console.WriteLine("---- Banco Grupo 2 ----\n");

            //Perguntar qual tipo de conta acessar
            Console.WriteLine("Seja bem vindo:\nQual tipo de Conta deseja acessar:" +
                "\n(1)Conta Poupança" +
                "\n(2)Conta Investimento" +
                "\n(3)Conta Salário" +
                "\n" +
                " Digite o numeral correspondente:");

            //pegar a resposta
            int retorno = ValidadorEConversorNumerico.ConverterParaNumero();
            //converter para número a resposta


            //recebo o retorno e entro na opção para instanciar a conta escolhida

            int numeroConta = 0;
            int numeroAgencia = 0;

            if (retorno == 1)
            {
                //Perguntar as exigencias para enviar para o construtor, os campos Agencia e Conta estão fixos
                Console.WriteLine("Digite o número da sua Agencia:");

                numeroAgencia = ValidadorEConversorNumerico.ConverterParaNumero();

                //converter para número a resposta

                Console.WriteLine("Digite o número da sua Conta");

                numeroConta = ValidadorEConversorNumerico.ConverterParaNumero(); ;

                ContaPoupanca contaP = new ContaPoupanca(numeroConta, numeroAgencia, "Jaqueline Laurenti", 12345698741);
            }
            else if (retorno == 2)
            {
                //Perguntar as exigencias para enviar para o construtor, os campos Agencia e Conta estão fixos
                Console.WriteLine("Digite o número da sua Agencia:");

                //pegar a resposta

                numeroAgencia = ValidadorEConversorNumerico.ConverterParaNumero();

                //converter para número a resposta

                Console.WriteLine("Digite o número da sua Conta");

                numeroConta = ValidadorEConversorNumerico.ConverterParaNumero();
                ContaInvestimento contaI = new ContaInvestimento(numeroConta, numeroAgencia, "Jaqueline Laurenti", 12345698741, "Moderado");
            }
            else if (retorno == 3)
            {
                //Perguntar as exigencias para enviar para o construtor, os campos Agencia e Conta estão fixos
                Console.WriteLine("Digite o número da sua Agencia:");

                //pegar a resposta

                numeroAgencia = ValidadorEConversorNumerico.ConverterParaNumero();

                //converter para número a resposta

                Console.WriteLine("Digite o número da sua Conta");

                numeroConta = ValidadorEConversorNumerico.ConverterParaNumero(); ;

                ContaSalario contaS = new ContaSalario(numeroConta, numeroAgencia, "Jaqueline Laurenti", 12345698741, "Maquina de Nomes Ltda");
            }
            
        }


    }
}
