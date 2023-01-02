using ContaBancaria_Grupo2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

public abstract class Conta : ListaExtrato
{
    public int NumeroConta { get; protected set; }
    public int NumeroAgencia { get; protected set; }
    public string NomeCompleto { get; protected set; }
    public long CPF { get; protected set; }
    public double Saldo { get; protected set; }

    public string TipoAcaoDaConta { get; protected set; } = "";

    public Conta(int numeroConta, int numeroAgencia, string nomeCompleto, long cpf)
    {
        NumeroConta = numeroConta;
        NumeroAgencia = numeroAgencia;
        NomeCompleto = nomeCompleto;
        CPF = cpf;

    }

    public DateTime DataAberturaConta
    {
        get

        {
            return DataAberturaConta;
        }

        protected set
        {
            DateTime data = DateTime.Now;
            DataAberturaConta = value;
        }
    }

    //METODOS

    public virtual void Depositar(double valor)
    {
        Saldo += valor;
    }
    public virtual void Sacar(double valor)
    {
        if (Saldo < valor)
        {
            //SE O SALDO FOR MENOR QUE A OPERAÇÃO, INDICO UM ERRO
            throw new Exception("Operação Negada por falta de limite disponivel.");

        }
        else
        {
            Saldo -= valor;
        }

    }

    //MENSAGEM 
    public virtual void Saudacao(string tipo_conta = "")
    {
        var mensagem = $"Olá, {NomeCompleto.Split(" ")[0]}, Bem Vindo(a)!!Sua conta {tipo_conta} foi aberta.\nSeus Dados:\nConta: {NumeroConta}\nAgencia: {NumeroAgencia}.{Environment.NewLine}";
        Console.WriteLine(mensagem);
    }



    public virtual void TaxaBancaria()
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
        double TaxaManutencao = 0.0;

        Saldo -= TaxaManutencao;
        IncluirTransacaoNoExtrato(TipoOperacao.TAXA_MANUTENÇAO, TaxaManutencao);
    }

    /*
     * 
    - Para a contaInvestimento: taxa de 0.8
    - Para a contaPoupanca: taxa de 0.3,5
    - Para a contaSalario: taxa de 0.3
    */


    //METODO DO MENU DE OPÇÕES E ACOES DISPONIVEIS DAS CONTAS
    public void AcoesDaConta()
    {
        while (true)
        {
            MenuDeInteracoes.MostrarMenu(TipoAcaoDaConta);
            TipoAcaoDaConta = "";
            MenuEscolhas(MenuDeInteracoes.EscolherMenu(), Saldo);
            Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}{Environment.NewLine}");
            Console.WriteLine($"O que deseja fazer agora?");
        }

    }

    // METODO USADO PARA AGIR DEPOIS QUE UMA ESCOLHA NO MENU E CONFIRMADA
    private void MenuEscolhas(string escolha, double valorEmConta)
    {
        double atualizarSaldo = valorEmConta;
        try
        {
            switch (escolha.ToUpper())
            {
                case "DEPOSITAR SALÁRIO":

                    Console.WriteLine("Qual valor deseja Depositar:");
                    double valorDepositoSalario = ValidadorEConversorNumerico.ConverterParaDouble();
                    Depositar(valorDepositoSalario);
                    atualizarSaldo = valorEmConta + valorDepositoSalario;
                    IncluirTransacaoNoExtrato(TipoOperacao.DEPOSITO_SALARIO, valorDepositoSalario);
                    break;


                case "DEPOSITAR":

                    Console.WriteLine("Qual valor deseja Depositar:");
                    double valorDeposito = ValidadorEConversorNumerico.ConverterParaDouble();
                    Depositar(valorDeposito);
                    atualizarSaldo = valorEmConta + valorDeposito;
                    IncluirTransacaoNoExtrato(TipoOperacao.DEPOSITO, valorDeposito);
                    break;

                case "SAQUE":

                    Console.WriteLine("Qual valor deseja Sacar:");
                    double valorSaque = ValidadorEConversorNumerico.ConverterParaDouble();
                    Sacar(valorSaque);
                    atualizarSaldo = valorEmConta - valorSaque;
                    IncluirTransacaoNoExtrato(TipoOperacao.SAQUE, valorSaque);
                    break;

                case "EXTRATO":

                    atualizarSaldo = valorEmConta;
                    MostrarExtrato();
                    if (ContaInvestimento.painel_Investimento != null)
                        ContaInvestimento.painel_Investimento.MostrarInvestimentos();
                    break;

                case "COMPRAR AÇÃO":

                    double valorCompradoDeAcao = ContaInvestimento.ComprarAcao(valorEmConta);
                    atualizarSaldo = valorCompradoDeAcao;
                    IncluirTransacaoNoExtrato(TipoOperacao.COMPRA_ACAO, (valorEmConta - valorCompradoDeAcao));
                    break;


                case "SAIR":

                    Environment.Exit(0);
                    break;

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Saldo = atualizarSaldo;

    }


}
