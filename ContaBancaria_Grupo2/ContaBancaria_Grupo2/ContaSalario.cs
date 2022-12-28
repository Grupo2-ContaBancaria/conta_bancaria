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
    public ContaSalario(int numeroConta, int numeroAgencia, string nomeCompleto, long cpf, string empregador="") : base(numeroConta, numeroAgencia, nomeCompleto, cpf)
    {

        SolicitarDadosHolerite(empregador);
    }

    public void SolicitarDadosHolerite(string empregador = "")
    {
        if(empregador == "")
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
        
    }

    public override void Depositar(double valor)
    {
        Console.WriteLine("informe o CNPJ do Empregador:");
        long numeroCnpj = ValidadorEConversorNumerico.ConverterParaLong();
        if(numeroCnpj != Cnpj)
        {
            Console.WriteLine("Dado Inválido!");
        }
        else
        {
            base.Depositar(valor);
        }

        

        //Precisa incluir a movimentação no extrato, com um DateTime e o valor informando que é Deposito e o valor
    }



}





