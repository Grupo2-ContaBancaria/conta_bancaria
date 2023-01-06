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

            Console.WriteLine("Dados Obrigatorios:\n");

            //O PROGRAM AO INICIAR A SOLUÇÃO CHAMOU ESTE METODO E ENVIOU UM NUMERO QUE DETERMINA QUAL TIPO DE 
            //CONTA O USUARIO DESEJA ABRIR, ESTA INFORMAÇÃO  E O ARGUMENTO RECEBIDO E ATRIBUIDO NA VARIAVEL RETORNO

            int retorno = numeroQueEscolheQualACategoriaDaConta;

            //NA OPÇÃO ABRIR CONTA É NECESSARIO, QUE O USUARIO DIGITE SEM NOME E CPF
            //POIS ESTES DADOS SERÃO SETADOS NA PROPRIEDADE OBRIGATORIA DA CLASSE ABSTRATA CONTA

            string NomeCompleto = "";
            long cpf = 0;

            //O NOMECOMPLETO, CHAMA UM METODO QUE PEDE O NOME, LER O DADO, VALIDA SE O USUARIO DIGITOU 2 NOMES, CASO NÃO TENHA FEITO, FICA NO LOOP
            NomeCompleto = ValidadorEConversorNumerico.ColetarNomeCompleto();
                        

            Console.WriteLine("Digite os 11 digitos do seu CPF, sem traços ou pontos:");

            cpf = ValidadorEConversorNumerico.ConverterParaLong();

            // INSTANCIANDO A CONTA CONFORME ESCOLHA DO USUARIO, E ATRIBUINDO OS DADOS OBRIGATORIOS PARA SEREM SETADOS NO CONSTRUTOR
            //OS CAMPOS AGENCIA E CONTA ESTÃO FIXOS.

            if (retorno == 1)
            {
                ContaPoupanca contaP = new ContaPoupanca(258902, 2541, NomeCompleto, cpf,"Poupança", 0.0);

            }
            else if (retorno == 2)
            {
                ContaInvestimento contaI = new ContaInvestimento(25890022, 2541, NomeCompleto, cpf, "Investimento");
                contaI.MontarPerfil();


                //Mostrar menu de ações do que fazer
            }
            else if (retorno == 3)
            {
                ContaSalario contaS = new ContaSalario(27852322, 2541, NomeCompleto, cpf, "Salario", "");
            }

        }
    }
}
