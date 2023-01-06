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
    public string TipoConta { get; protected set; }
    public long CPF { get; protected set; }
    public double Saldo { get; protected set; }
    public double SaldoCofrinho { get; protected set; }

    public string TipoAcaoDaConta { get; protected set; } = "";

    public Conta(int numeroConta, int numeroAgencia, string nomeCompleto, long cpf, string tipoConta)
    {
        NumeroConta = numeroConta;
        NumeroAgencia = numeroAgencia;
        NomeCompleto = nomeCompleto;
        CPF = cpf;
        TipoConta = tipoConta;
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
    public virtual void Resgatar(double valor)
    {
        if (SaldoCofrinho < valor)
        {
            //SE O SALDO FOR MENOR QUE A OPERAÇÃO, INDICO UM ERRO
            throw new Exception("Operação Negada por falta de limite disponivel.");

        }
        else
        {
            Saldo += valor;
            SaldoCofrinho -= valor;
        }

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

    public virtual void Tranferir(double valor)
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
    public virtual void Saudacao()
    {
        var mensagem = $"Olá, {NomeCompleto.Split(" ")[0]}, Bem Vindo(a)!!Sua conta {TipoConta} foi aberta.\nSeus Dados:\nConta: {NumeroConta}\nAgencia: {NumeroAgencia}.{Environment.NewLine}";
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
    public void AcoesDaConta(string tipoContaQueChamou)
    {
        if (tipoContaQueChamou == "INVESTIMENTO" || tipoContaQueChamou == "SALARIO")
        {
            while (true)
            {
                MenuDeInteracoes.MostrarMenu(" ", TipoAcaoDaConta);
                TipoAcaoDaConta = "";
                MenuEscolhas(MenuDeInteracoes.EscolherMenu(), Saldo);

                Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"Cofrinho {SaldoCofrinho.ToString("F2", CultureInfo.InvariantCulture)}{Environment.NewLine}");
                Console.WriteLine($"O que deseja fazer agora?");
            }
        }
        else if (tipoContaQueChamou == "POUPANÇA")
        {
            while (true)
            {
                MenuDeInteracoes.MostrarMenu("POUPANÇA", TipoAcaoDaConta);
                TipoAcaoDaConta = "";
                string escolhaUsuario = MenuDeInteracoes.EscolherMenu();

                if (escolhaUsuario == "Transferência")
                {
                    MenuEscolhas("SAIDA", Saldo);

                }
                else
                {
                    MenuEscolhas(escolhaUsuario, Saldo);

                }


                Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine($"O que deseja fazer agora?");
            }

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

                //Resgatar Cofrinho verificar com o grupo
                case "RESGATAR COFRINHO":

                    Console.WriteLine("Qual valor deseja Resgatar:");
                    double valorResgate = ValidadorEConversorNumerico.ConverterParaDouble();
                    Resgatar(valorResgate);

                    atualizarSaldo = valorEmConta + valorResgate;
                    IncluirTransacaoNoExtrato(TipoOperacao.RESGATE_COFRINHO, valorResgate);
                    break;

                case "SAQUE":

                    Console.WriteLine("Qual valor deseja Sacar:");
                    double valorSaque = ValidadorEConversorNumerico.ConverterParaDouble();
                    Sacar(valorSaque);
                    atualizarSaldo = valorEmConta - valorSaque;
                    IncluirTransacaoNoExtrato(TipoOperacao.SAQUE, valorSaque);
                    break;

                case "TRANSFERÊNCIA":
                    int escolhaUsuario = 0;
                    int numeroAgencia, numeroConta = 0;
                    double valorTransferido = 0;

                    do
                    {
                        Console.WriteLine("Determine o tipo de Transferência:\n(1)Transferência entre Contas\n(2)Transferência para Cofrinho");
                        escolhaUsuario = ValidadorEConversorNumerico.ConverterParaNumero();

                    } while (escolhaUsuario < 1 || escolhaUsuario > 2);

                    if (escolhaUsuario == 1)
                    {
                        Console.WriteLine("Digite os dados da Agência de Destino:");
                        numeroAgencia = ValidadorEConversorNumerico.ConverterParaNumero();

                        Console.WriteLine("Digite os dados da Conta de Destino:");
                        numeroConta = ValidadorEConversorNumerico.ConverterParaNumero();

                        Console.WriteLine("Digite o valor:");
                        valorTransferido = ValidadorEConversorNumerico.ConverterParaDouble();

                        Tranferir(valorTransferido);
                        atualizarSaldo = valorEmConta - valorTransferido;
                        IncluirTransacaoNoExtrato(TipoOperacao.TRANSFERÊNCIA, valorTransferido);


                    }
                    else if (escolhaUsuario == 2)
                    {
                        Console.WriteLine("Digite o valor:");
                        valorTransferido = ValidadorEConversorNumerico.ConverterParaDouble();
                        SaldoCofrinho += valorTransferido;

                        Tranferir(valorTransferido);
                        atualizarSaldo = valorEmConta - valorTransferido;
                        IncluirTransacaoNoExtrato(TipoOperacao.TRANSFERÊNCIA_COFRINHO, valorTransferido);

                    }
                    break;

                //Console.WriteLine("Digite o valor:");
                //double valorTransferido = ValidadorEConversorNumerico.ConverterParaDouble();

                //Tranferir(valorTransferido);
                //atualizarSaldo = valorEmConta - valorTransferido;
                //IncluirTransacaoNoExtrato(TipoOperacao.TRANSFERÊNCIA, valorTransferido);
                //break;

                case "SAIDA":

                    int agencia, conta = 0;
                    double valorTransferencia = 0;

                    Console.WriteLine("Digite os dados da Agência de Destino:");
                    agencia = ValidadorEConversorNumerico.ConverterParaNumero();

                    Console.WriteLine("Digite os dados da Conta de Destino:");
                    conta = ValidadorEConversorNumerico.ConverterParaNumero();

                    Console.WriteLine("Digite o valor:");
                    valorTransferencia = ValidadorEConversorNumerico.ConverterParaDouble();

                    Tranferir(valorTransferencia);
                    atualizarSaldo = valorEmConta - valorTransferencia;
                    IncluirTransacaoNoExtrato(TipoOperacao.TRANSFERÊNCIA, valorTransferencia);
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

                    if (valorCompradoDeAcao != valorEmConta)
                    {
                        IncluirTransacaoNoExtrato(TipoOperacao.COMPRA_ACAO, (valorEmConta - valorCompradoDeAcao));

                    }

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
