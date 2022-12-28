using ContaBancaria_Grupo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ContaPoupanca : Conta
{
    
   
    public ContaPoupanca(int numeroConta, int numeroAgencia, string nomeCompleto, long cpf) : base(numeroConta, numeroAgencia, nomeCompleto, cpf)
    {
        double primeiroDeposito = 0.0;
        Console.WriteLine("Para finalizar é necessario, fazer uma transferência de valor minimo R$ 50,00.\n Digite o valor que deseja tranferir:");
        primeiroDeposito = ValidadorEConversorNumerico.ConverterParaDouble();
        Depositar(primeiroDeposito);

        Console.Clear();
        Saudacao("Poupança");
        Console.WriteLine($"Seu Saldo Atual {Saldo}");
    }

    public override void Depositar(double valor)
    {
        base.Depositar(valor);
    }


}
