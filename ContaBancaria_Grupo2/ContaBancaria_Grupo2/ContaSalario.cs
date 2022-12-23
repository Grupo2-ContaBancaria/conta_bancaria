using ContaBancaria_Grupo2;
using System;
using System.Collections.Generic;
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
    public ContaSalario(int numeroConta, int numeroAgencia, string nomeCompleto, long cpf) : base(numeroConta, numeroAgencia, nomeCompleto, cpf)
    {
        
        SolicitarDadosHolerite();
    }

    public void SolicitarDadosHolerite()
    {
        Console.WriteLine("Para finalizar a abertura da Conta Salario responda:");

        Console.WriteLine("Nome da Empresa: ");
        this.NomeEmpregador = Console.ReadLine();

        Console.WriteLine("CNPJ da Empresa: ");
        this.Cnpj = ValidadorEConversorNumerico.ConverterParaLong();
        
        Console.WriteLine("Seu Cargo: ");
        this.Cargo = Console.ReadLine();

        Console.WriteLine("Seu Salário Bruto: ");
        this.Salario =  ValidadorEConversorNumerico.ConverterParaDouble();
        //chamar a função que converte ****Pendente

        Console.Clear();
        Saudacao("Salário");

    }

    public override void Depositar(double valor)
    {
        Console.WriteLine("informe o CNPJ do Empregador:");
        string cnpj = Console.ReadLine();

        //incluir um conversor de string para long e validar que tudo é numero. ***Pendente

        base.Depositar(valor);

        //Precisa incluir a movimentação no extrato, com um DateTime e o valor informando que é Deposito e o valor
    }

    public override void ExibirMenu(string opcaoDigitada)
    {
        Console.WriteLine("Escolha o que deseja fazer: \n" +
            "(01) Deposito\n" +
            "(02) Saque\n" +
            "(03) Consultar Extrato\n" +
            "(04) Depositar Salário");
        
    }

}





