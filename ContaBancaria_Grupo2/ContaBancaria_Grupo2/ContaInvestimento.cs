using ContaBancaria_Grupo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class ContaInvestimento : Conta
{
    public string perfil { get; protected set; }
    public ContaInvestimento(int numeroConta, int numeroAgencia, string nomeCompleto, long cpf) : base(numeroConta, numeroAgencia, nomeCompleto, cpf)
    {
        MontarPerfil();
    }
     

    public void MontarPerfil()
    {
        
        Console.WriteLine("Para finalizar a abertura da Conta Investimento responda o Formulário de classificação de Investidor:");

        //será acumulado a pontuação para analisar o perfil do investidor
        int pontuacaoInvestidor = 0;

        // ficará gravado a qualificação, depois que todas as perguntas forem respondidas e o metodo for chamado.
        string qualificacaoInvestidor = "";

        Console.WriteLine("1- Por quanto tempo pretende deixar seu dinheiro investido?\n(1)menos de 6 meses\n(2)Entre 1 ano e 3 anos\n(3)Acima de 3 anos ");
        
        pontuacaoInvestidor += ValidadorEConversorNumerico.ConverterParaNumero();


        //chamar a função que converte 
        //Depois de converter o numero, precisa buscar o peso dele na tabela(conforme escolha) e somar a pontuação do investidor
        

        Console.WriteLine("2- Qual o objetivo desse investimento?\n(1)Preservação de capital, assumindo riscos baixos\n(2)Aumento gradual do capita, assumindo riscos moderados" +
            "\n(3)Obter retornos elevados e significativos, assumindo riscos elevados ");

        pontuacaoInvestidor += ValidadorEConversorNumerico.ConverterParaNumero();
        

        Console.WriteLine("3- Qual das alternativas melhor classifica sua experiência com o mercado financeiro:" +
            "\n(1)Não possuo formação acadêmica ou conhecimento de mercado financeiro" +
            "\n(2)Possuo formação academica na area financeira, mas não tenho experiencia com o mercado financeiro" +
            "\n(3)Possuo formação academia em outra area ou na area financeira, mas possuo conhecimento no mercado financeiro ");
        pontuacaoInvestidor += ValidadorEConversorNumerico.ConverterParaNumero();
        

        Console.WriteLine("4- Quais investimento você conhece ou ja investe?" +
           "\n(1)Poupança, CDB e titulos públicos" +
           "\n(2)Titulos Publicos, CDBs, Fundos de Investimentos" +
           "\n(3)Renda Variavel, Renda Fixa, Fundos de Multimercado e Cambiais, Debentures e Derivativos ");
        pontuacaoInvestidor += ValidadorEConversorNumerico.ConverterParaNumero();
        

        //chamar metodo para verificar a qual perfil se encaixa a pontuação atingida

        qualificacaoInvestidor = AnalisadorPerfilInvestidor(pontuacaoInvestidor);
        Console.WriteLine($"Seu Perfil de Investidor é {qualificacaoInvestidor}");

        //atribuo o perfil a propriedade
        perfil = qualificacaoInvestidor;

        Console.Clear();

        //mensagem de boas vindas
        Saudacao("Investimento");

        //Conta será criada e terá que apresentar um menu, para navegar nas opções
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
    
}




