using ContaBancaria_Grupo2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class ContaInvestimento : Conta
{
    public string perfil { get; protected set; }
    public string acoesCompradas { get; protected set; }
    public ContaInvestimento(int numeroConta, int numeroAgencia, string nomeCompleto, long cpf, string nomePerfil = "") : base(numeroConta, numeroAgencia, nomeCompleto, cpf)
    {
        MontarPerfil(nomePerfil);
    }

    //Nesta situação o nome do perfil permite ser vazio ou preenchido, esta opçõ existe pois se o acesso for para conta existente
    //o perfil ja vira setado como Moderado.

    public void MontarPerfil(string nomePerfil = "")
    {
        int numeroDigitado = 0;
        //será acumulado a pontuação para analisar o perfil do investidor
        int pontuacaoInvestidor = 0;

        // ficará gravado a qualificação, depois que todas as perguntas forem respondidas e o metodo for chamado.
        string qualificacaoInvestidor = "";

        if (nomePerfil == "")
        {
            Console.WriteLine("Para finalizar a abertura da Conta Investimento responda o Formulário de classificação de Investidor:");


            Console.WriteLine("1- Por quanto tempo pretende deixar seu dinheiro investido?\n(1)menos de 6 meses\n(2)Entre 1 ano e 3 anos\n(3)Acima de 3 anos ");

            numeroDigitado = ValidadorEConversorNumerico.ValidarEntradaFormularioInvestidor();

            pontuacaoInvestidor += numeroDigitado;

            //Depois de converter o numero, precisa buscar o peso dele na tabela(conforme escolha) e somar a pontuação do investidor


            Console.WriteLine("2- Qual o objetivo desse investimento?\n(1)Preservação de capital, assumindo riscos baixos\n(2)Aumento gradual do capita, assumindo riscos moderados" +
                "\n(3)Obter retornos elevados e significativos, assumindo riscos elevados ");

            numeroDigitado = ValidadorEConversorNumerico.ValidarEntradaFormularioInvestidor();

            pontuacaoInvestidor += numeroDigitado;

            Console.WriteLine("3- Qual das alternativas melhor classifica sua experiência com o mercado financeiro:" +
                "\n(1)Não possuo formação acadêmica ou conhecimento de mercado financeiro" +
                "\n(2)Possuo formação academica na area financeira, mas não tenho experiencia com o mercado financeiro" +
                "\n(3)Possuo formação academia em outra area ou na area financeira, mas possuo conhecimento no mercado financeiro ");

            numeroDigitado = ValidadorEConversorNumerico.ValidarEntradaFormularioInvestidor();

            pontuacaoInvestidor += numeroDigitado;

            Console.WriteLine("4- Quais investimento você conhece ou ja investe?" +
               "\n(1)Poupança, CDB e titulos públicos" +
               "\n(2)Titulos Publicos, CDBs, Fundos de Investimentos" +
               "\n(3)Renda Variavel, Renda Fixa, Fundos de Multimercado e Cambiais, Debentures e Derivativos ");

            numeroDigitado = ValidadorEConversorNumerico.ValidarEntradaFormularioInvestidor();

            pontuacaoInvestidor += numeroDigitado;

            Console.Clear();

            //chamar metodo para verificar a qual perfil se encaixa a pontuação atingida

            qualificacaoInvestidor = AnalisadorPerfilInvestidor(pontuacaoInvestidor);
            Console.WriteLine($"Seu Perfil de Investidor é {qualificacaoInvestidor}");

            //atribuo o perfil a propriedade
            perfil = qualificacaoInvestidor;


            //mensagem de boas vindas
            Saudacao("Investimento");
            Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");

            //Conta será criada e terá que apresentar um menu, para navegar nas opções
        }
        else
        {
            //se o acesso for atraves da opçao acessar conta existente, iniciara por aqui
            //com o perfil do investidor como "moderado".
            perfil = nomePerfil;
            Console.Clear();

            //mensagem de boas vindas
            Console.WriteLine($"Bem Vindo(a),{NomeCompleto}\nAg:{NumeroAgencia} conta Investimento:{NumeroConta}");
            Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
        }

        //apos iniciar a conta aparecerá o menu mostrando as possibilidades com novas interações
        // o menu aparece no console, indeterminadas vezes, até que a opção 5 seja acionada, assim ele encerrará

        int escolhaDigitadaNoMenu = MenuDeInteracoes.MenuContaInvestimento();
        do
        {


            Saldo = MenuEscolhas(escolhaDigitadaNoMenu, Saldo);
            Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");

            escolhaDigitadaNoMenu = MenuDeInteracoes.MenuContaInvestimento();

        } while (escolhaDigitadaNoMenu < 6);



    }
    public double MenuEscolhas(int escolha, double valorEmConta)
    {
        double atualizarSaldo = 0.0;
        switch (escolha)
        {

            case 1:
                Console.WriteLine("Qual valor deseja Depositar:");
                double valorDeposito = ValidadorEConversorNumerico.ConverterParaDouble();
                Depositar(valorDeposito);

                atualizarSaldo = valorEmConta + valorDeposito;
                break;

            case 2:
                Console.WriteLine("Qual valor deseja Sacar:");
                double valorSaque = ValidadorEConversorNumerico.ConverterParaDouble();
                Sacar(valorSaque);

                atualizarSaldo = valorEmConta - valorSaque;
                break;

            case 3:
                double valorCompradoDeAcao = ComprarAcao(valorEmConta);
                atualizarSaldo = valorCompradoDeAcao;
                break;
            case 4:
                //exibirá o extrato
                break;
            case 5:
                Environment.Exit(0);
                break;

        }
        return atualizarSaldo;

    }
    public static string AnalisadorPerfilInvestidor(int pontuacao)
    {
        //metodo verificador do saldo acumulado, conforme as escolhas do investidor
        string perfil = "";
        if (pontuacao <= 6)
        {
            perfil = "Conservador";
        }
        else if (pontuacao <= 11)
        {
            perfil = "Moderado";
        }
        else if (pontuacao == 12)
        {
            perfil = "Agressivo";
        }
        return perfil;

    }
    public override void Depositar(double valor)
    {
        base.Depositar(valor);
    }
    public override void Sacar(double valor)
    {
        base.Sacar(valor);
    }

    public static double ComprarAcao(double valorEmConta)
    {
        Console.WriteLine("Digite o código do Papel que deseja comprar");
        string codigoPapel = Console.ReadLine();

        Console.WriteLine($"Digite o valor que deseja investir em {codigoPapel}: ");
        double valorInvestidoNoPapel = ValidadorEConversorNumerico.ConverterParaDouble();

        double sobra = 0.0;

        if (valorInvestidoNoPapel > valorEmConta)
        {
            Console.WriteLine("Compra não realizada por falta de Saldo!");
            sobra = valorEmConta;
        }
        else
        {
            Console.WriteLine("Compra Realizada!");
            sobra = valorEmConta - valorInvestidoNoPapel;

        }
        return sobra;
    }

}




