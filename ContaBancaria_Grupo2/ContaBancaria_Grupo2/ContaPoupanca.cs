using ContaBancaria_Grupo2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ContaPoupanca : Conta
{


    public ContaPoupanca(int numeroConta, int numeroAgencia, string nomeCompleto, long cpf, double saldoInicial) : base(numeroConta, numeroAgencia, nomeCompleto, cpf)
    {
        double primeiroDeposito = saldoInicial;


        if (primeiroDeposito < 50.00)
        {
            do
            {
                Console.WriteLine("Para finalizar é necessario, fazer uma transferência de valor minimo R$ 50,00.\n Digite o valor que deseja tranferir:");
                primeiroDeposito = ValidadorEConversorNumerico.ConverterParaDouble();

            } while (primeiroDeposito < 50);

            Depositar(primeiroDeposito);
            IncluirTransacaoNoExtrato(TipoOperacao.DEPOSITO, primeiroDeposito);
            Console.Clear();
            Saudacao("Poupança");
            Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
        }
        else
        {
            //mensagem de boas vindas para conta existente
            // nesta opção a conta inicia com saldo minimo.
            Console.Clear();
            Saldo = primeiroDeposito;
            IncluirTransacaoNoExtrato(TipoOperacao.DEPOSITO, primeiroDeposito,-2);
            Console.WriteLine($"Bem Vindo(a),{NomeCompleto}\nAg:{NumeroAgencia} conta poupança:{NumeroConta}");
            Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
        }
        //apos iniciar a conta aparecerá o menu mostrando as possibilidades com novas interações
        // o menu aparece no console, indeterminadas vezes, até que a opção 5 seja acionada, assim ele encerrará

        int escolhaDigitadaNoMenu = MenuDeInteracoes.MenuContaPoupanca();
        do
        {


            Saldo = MenuEscolhas(escolhaDigitadaNoMenu, Saldo);
            Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");

            escolhaDigitadaNoMenu = MenuDeInteracoes.MenuContaPoupanca();

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
                    IncluirTransacaoNoExtrato(TipoOperacao.DEPOSITO, valorDeposito);
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return atualizarSaldo;

    }
    public override void Depositar(double valor)
    {
        base.Depositar(valor);
    }

}





