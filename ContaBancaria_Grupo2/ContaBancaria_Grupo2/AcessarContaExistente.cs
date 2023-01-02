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
            int retorno = 0;
            //VARIAVEIS SERÃO ATRIBUIDO PELO USUARIO
            int numeroConta = 0;
            int numeroAgencia = 0;
            do
            {
                //SELEÇÃO DO TIPO DE CONTA
                Console.WriteLine("Que bom te Ver de Novo!!\nQual tipo de Conta deseja acessar:" +
                    "\n(1)Conta Poupança" +
                    "\n(2)Conta Investimento" +
                    "\n(3)Conta Salário");

                //ARMAZENA A RESPOSTA E CHAMA O METODO DE CONVERSÃO E VALIDAÇÃO
                //O RETORNO DESTA VARIAVEL ARMAZENA A INFORMAÇÃO DE AUQL CONTA SERA INSTANCIADA
                retorno = ValidadorEConversorNumerico.ConverterParaNumero();
                               
                Console.WriteLine("Digite o número da sua Agencia:");
                numeroAgencia = ValidadorEConversorNumerico.ConverterParaNumero();

                Console.WriteLine("Digite o número da sua Conta");
                numeroConta = ValidadorEConversorNumerico.ConverterParaNumero();

            } while (retorno < 1 || retorno > 3);
           
            //INSTANCIANDO A CONTA COM OS ARGUMENTOS NECESSARIOS PARA PREENCHIMENTO DAS PROPRIEDADES OBRIGATORIAS
            if (retorno == 1)
            {
                ContaPoupanca contaP = new ContaPoupanca(numeroConta, numeroAgencia, "Jaqueline Laurenti", 12345678910, 50.00);
            }
            else if (retorno == 2)
            {
                ContaInvestimento contaI = new ContaInvestimento(numeroConta, numeroAgencia, "Jaqueline Laurenti", 12345678910);
                contaI.MontarPerfil("Moderado");
            }
            else if (retorno == 3)
            {
                ContaSalario contaS = new ContaSalario(numeroConta, numeroAgencia, "Jaqueline Laurenti", 12345678910, "Maquina de Nomes Ltda");
            }

        }


    }
}
