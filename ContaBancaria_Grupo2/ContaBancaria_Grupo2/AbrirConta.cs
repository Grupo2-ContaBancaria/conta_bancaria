using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria_Grupo2
{
    class AbrirConta
    {
        public static void AbrirContas(int numeroQueEscolheQualACategoriaDaConta)
        {

            int retorno = numeroQueEscolheQualACategoriaDaConta;
            //recebo o retorno e entro na opção para instanciar a conta escolhida

            //peço dados obrigatorios para todas as antes **VErificar se precisa de mais dados
            string NomeCompleto = "";
            long cpf = 0;

            //Perguntar as exigencias para enviar para o construtor, os campos Agencia e Conta estão fixos
            Console.WriteLine("Digite seu NOME COMPLETO:");
            NomeCompleto = Console.ReadLine();

            Console.WriteLine("Digite os 11 digitos do seu CPF:");

            cpf = ValidadorEConversorNumerico.ConverterParaLong();

            //instanciando a conta conforme escolha
            if (retorno == 1)
            {
                ContaPoupanca contaP = new ContaPoupanca(258902, 2541, NomeCompleto, cpf, 0.0);

            }
            else if (retorno == 2)
            {
                ContaInvestimento contaI = new ContaInvestimento(25890022, 2541, NomeCompleto, cpf);
            }
            else if (retorno == 3)
            {
                ContaSalario contaS = new ContaSalario(27852322, 2541, NomeCompleto, cpf, "");
            }

        }
    }
}
