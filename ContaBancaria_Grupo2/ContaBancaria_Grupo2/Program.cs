using ContaBancaria_Grupo2;
using System.Reflection.Metadata.Ecma335;

namespace ContaBancaria_Grupo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //FUNÇÃO QUE MONTA A TELA DO CONSOLE
            ConfiguracaoLayout.LayoutDoConsole();

            try
            {
                //INICIO DO APLICAÇÃO, SERÁ EXIBIDO AS OPÇÕES DE DE ACESSO, A ESCOLHA SERÁ ATRAVES DE ESCOLHA PELO NUMERAL
                int retorno = 0;

                do
                {
                    Console.WriteLine("Seja Bem Vindo(a):\nO que deseja fazer:\n(1)Abrir Conta\n(2)Acessar Conta");

                    //ESTA FUNÇÃO LER A ENTRADA, VALIDA E CONVERTE
                    retorno = ValidadorEConversorNumerico.ConverterParaNumero();

                }while(retorno < 1|| retorno > 2); 

                if (retorno == 1)
                {
                    do
                    {
                        //PERGUNTA SOBRE QUAL TIPO DE CONTA DESEJA ABRIR, PARA QUE POSSA IR PARA A CLASSE ESPECIFICA
                        Console.WriteLine("Qual tipo de conta deseja abrir:\n(1)Conta Poupança\n(2)Conta Investimento\n(3)Conta Salário");

                        //ESTA FUNÇÃO LER A ENTRADA, VALIDA E CONVERTE
                        retorno = ValidadorEConversorNumerico.ConverterParaNumero();

                        ConfiguracaoLayout.ClearLayout();

                    } while (retorno < 1|| retorno > 3);
                    // O WHILE FUNCIONA COMO VALIDADOR, POIS ELE SÓ ACEITA COMO TRUE SE FOR 1,2,3

                    //FUNÇÃO QUE DIRECIONA PARA ABRIR CONTA
                    AbrirConta.AbrirContas(retorno);


                }
                else if (retorno == 2)
                {
                    //SE ESCOLHIDO ACESSA CONTA, SERÁ DIRECIONADO PARA OUTRA FUNÇÃO

                    AcessarContaExistente.AcessandoContaExistente();
                }


            }
            catch (Exception ex)
            {
                ConfiguracaoLayout.ClearLayout();
                Console.WriteLine(ex.Message);

            }

        }
    }
}