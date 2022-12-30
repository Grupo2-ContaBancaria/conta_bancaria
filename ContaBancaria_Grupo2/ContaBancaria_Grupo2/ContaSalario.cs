using ContaBancaria_Grupo2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


class ContaSalario : Conta
{
    public string NomeEmpregador { get; protected set; }
    public long Cnpj { get; protected set; }

    public string Cargo { get; protected set; }
    public double Salario { get; protected set; }
    public ContaSalario(int numeroConta, int numeroAgencia, string nomeCompleto, long cpf, string empregador = "") : base(numeroConta, numeroAgencia, nomeCompleto, cpf)
    {

        SolicitarDadosHolerite(empregador);
    }

    private void SolicitarDadosHolerite(string empregador = "")
    {
        if (empregador == "")
        {
            Console.WriteLine("Para finalizar a abertura da Conta Salario responda:");

            Console.WriteLine("Nome da Empresa: ");
            this.NomeEmpregador = Console.ReadLine();

            Console.WriteLine("CNPJ da Empresa: ");
            this.Cnpj = ValidadorEConversorNumerico.ConverterParaLong();

            Console.WriteLine("Seu Cargo: ");
            this.Cargo = Console.ReadLine();

            Console.WriteLine("Seu Salário Bruto: ");
            this.Salario = ValidadorEConversorNumerico.ConverterParaDouble();

            Console.Clear();
            Saudacao("Salário");
            Console.WriteLine($"Seu Saldo Atual {Saldo}");
        }
        else
        {
            //se o acesso for atraves da opçao acessar conta existente, iniciara por aqui
            //com os dados do holerites setados.
            NomeEmpregador = empregador;
            Cnpj = 00112112000139;
            Cargo = "Vendedor";
            Salario = 2500.00;

            Console.Clear();

            //mensagem de boas vindas
            Console.WriteLine($"Bem Vindo(a),{NomeCompleto}\nAg:{NumeroAgencia} conta Salário:{NumeroConta}");
            Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
        }
        //apos iniciar a conta aparecerá o menu mostrando as possibilidades com novas interações
        // o menu aparece no console, indeterminadas vezes, até que a opção 5 seja acionada, assim ele encerrará

        int escolhaDigitadaNoMenu = MenuDeInteracoes.MenuContaSalario();
        do
        {


            Saldo = MenuEscolhas(escolhaDigitadaNoMenu, Saldo);
            Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");

            escolhaDigitadaNoMenu = MenuDeInteracoes.MenuContaSalario();

        } while (escolhaDigitadaNoMenu < 5);



    }
    private double MenuEscolhas(int escolha, double valorEmConta)
    {
        double atualizarSaldo = valorEmConta;
        try
        {
            
            switch (escolha)
            {

                case 1:
                    Console.WriteLine("Qual valor deseja Depositar:");
                    double valorDeposito = ValidadorEConversorNumerico.ConverterParaDouble();
                    Depositar(valorDeposito);
                    atualizarSaldo = valorEmConta + valorDeposito;
                    IncluirTransacaoNoExtrato(TipoOperacao.DEPOSITO_SALARIO, valorDeposito);
                    break;

                case 2:
                    Console.WriteLine("Qual valor deseja Sacar:");
                    double valorSaque = ValidadorEConversorNumerico.ConverterParaDouble();
                    Sacar(valorSaque);
                    atualizarSaldo = valorEmConta - valorSaque;
                    IncluirTransacaoNoExtrato(TipoOperacao.SAQUE, valorSaque);
                    break;

                case 3:
                    atualizarSaldo = valorEmConta;
                    MostrarExtrato();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;

            }
        }
        catch (Exception e )
        {

            Console.WriteLine(e.Message); 
        }
        return atualizarSaldo;

    }

    public override void Depositar(double valor)
    {
        Console.WriteLine("informe o CNPJ do Empregador:");
        long numeroCnpj = ValidadorEConversorNumerico.ConverterParaLong();
        if (numeroCnpj != Cnpj)
        {
            throw new Exception("Dado Inválido!");
        }
        else
        {
            base.Depositar(valor);
        }




    }



}





