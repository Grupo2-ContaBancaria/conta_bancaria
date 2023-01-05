using ContaBancaria_Grupo2;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ContaInvestimento : Conta
{
    //ESTA CLASSE HERDA AS PROPRIEDADES OBRIGATORIAS DA CLASSE CONTA E NOVAS PROPRIEDADES 
    public string? Perfil { get; protected set; }
    
    public static Painel_Investimento? painel_Investimento { get;protected set; }

    //CONSTRUTORA DA CLASSE
    public ContaInvestimento(int numeroConta, int numeroAgencia, string nomeCompleto, long cpf) : base(numeroConta, numeroAgencia, nomeCompleto, cpf)
    {
        painel_Investimento = new Painel_Investimento("", 0);
    }

    // NA OPÇÃO CONTA EXISTENTE O PERFIL VEM SETADO COMO ARGUMENTO QUANDO SE INSTANCIA A CLASSE

    //O PERFIL DO USUARIO EM CASO DE CONTA NOVA E PREENCHIDO ATRAVES DO FORMULARIO
    public void MontarPerfil(string nomePerfil = "")
    {

        Console.WriteLine("Formulário Obrigatorio para Análise de Perfil:\n");

        //VARIAVEL REPONSAVEL POR ARMAZENAR O NUMERO DIGITADO PELO USUARIO
        int numeroDigitado = 0;

        //CONTADOR DE PONTOS
        int pontuacaoInvestidor = 0;

        // REGISTRA O NOME DO PERFIL
        string qualificacaoInvestidor = "";

        if (nomePerfil == "")
        {
            Console.WriteLine("Para finalizar a abertura da Conta Investimento responda o Formulário de classificação de Investidor:");


            Console.WriteLine("1- Por quanto tempo pretende deixar seu dinheiro investido?\n(1)menos de 6 meses\n(2)Entre 1 ano e 3 anos\n(3)Acima de 3 anos ");

            numeroDigitado = ValidadorEConversorNumerico.ValidarEntradaFormularioInvestidor();

            pontuacaoInvestidor += numeroDigitado;


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

            //FORMULARIO PREECHIDO PERFIL JA DEFINIDO, CHAMADO DO METODO QUE LIMPA LAYOUT PARA EXIBIÇÃO DE UMA NOVA AREA

            ConfiguracaoLayout.ClearLayout(); ;

            //CHAMA DA FUNÇÃO QUE IDENTIFICA E PONTUAÇÃO E A QUAL PERFIL ELA SE ENCAIXA

            qualificacaoInvestidor = AnalisadorPerfilInvestidor(pontuacaoInvestidor);
            Console.WriteLine($"Seu Perfil de Investidor é {qualificacaoInvestidor}");

            //A PROPRIEDADE RECEBE O NOME DO PERFIL DO USUARIO, CONFORME SUAS ESCOLHAS NO FORMULARIO.
            Perfil = qualificacaoInvestidor;

            Saudacao($"Investimento");

            Console.WriteLine($"{Environment.NewLine}Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");

            //CONTA NOVA CRIADA
        }
        else
        {
            //NESTE CASO HABILITA O ACESSO PELA CONTA EXISTENTE, ENTÃO OS ARGUMENTOS PARA ATRIBUIÇÃO DAS PROPRIEDADES SÃO DIFERENTES

            Perfil = nomePerfil;

            //PERFIL VIRÁ COMO MODERADO

            ConfiguracaoLayout.ClearLayout(); ;

            
            Console.WriteLine($"{Environment.NewLine}Bem Vindo(a),{NomeCompleto}\nAg:{NumeroAgencia} \nconta Investimento:{NumeroConta}\n{Environment.NewLine}");
            Console.WriteLine($"{Environment.NewLine}Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
        }
        //CHAMA DA FUNÇAÕ TAXA
        TaxaBancaria();
                
        //NO MENU DE OPÇÃO DESTA CONTA É INCLUIDO UMA NOVA OPÇÃO

        TipoAcaoDaConta = "Comprar Ação";
       

        //METODO QUE EXIBE MENU DE ATIVIDADES DA CONTA
        AcoesDaConta("INVESTIMENTO");


    }
 
    private static string AnalisadorPerfilInvestidor(int pontuacao)
    {
       //METODO QUE VERIFICA PONTUAÇÃO E ATRIBUI O NOME DO PERFIL
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

    public static double ComprarAcao(double valorEmConta)
    {
        // METODO DE COMPRAR AÇÃO

        Console.WriteLine("Digite o código do Papel que deseja comprar");
        string codigoPapel = Console.ReadLine().ToUpper();

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

            //ATUALIZA O SALDO DA CONTA
            sobra = valorEmConta - valorInvestidoNoPapel;
            
            // INCLUI TRANSAÇÃO DE COMPRA NO EXTRATO DE PATRIMONIO
            painel_Investimento.IncluirTransacaoNoPainel(codigoPapel, valorInvestidoNoPapel);

        }
        return sobra;
    }

    public override void TaxaBancaria()
    {
        /*Se for multiplicação o calculo da taxa, usar este codigo
         * double percentualDeDesconto = 0.0;
         * double TaxaManutencao = 0.0;
         * 
         * TaxaManutencao = Saldo * percentualDeDesconto;
         * 
         * Saldo -=TaxaManutencao;
         */

        //Se for uma conta de subtração usar este aqui
        double TaxaManutencao = 0.8;

        Saldo -= TaxaManutencao;
        IncluirTransacaoNoExtrato(TipoOperacao.TAXA_MANUTENÇAO, TaxaManutencao);
    }


}










