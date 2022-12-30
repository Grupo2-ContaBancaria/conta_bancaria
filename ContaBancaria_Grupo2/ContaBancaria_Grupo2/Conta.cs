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


    public double Saldo { get; protected set; }

    public virtual void Depositar(double valor)
    {
        Saldo += valor;
    }
    public virtual void Sacar(double valor)
    {
        if (Saldo < valor)
        {
            //Indica que o valor no saldo é menor que o solicitado para saque
            throw new Exception("Operação Negada por falta de limite disponivel.");
            
        }
        else
        {
            Saldo -= valor;
        }

    }

    public virtual void Saudacao(string tipo_conta = "")
    {
        var mensagem = $"Olá, {NomeCompleto.Split(" ")[0]}, Bem Vindo(a). Sua conta {tipo_conta} foi aberta. Sua conta: {NumeroConta} - Sua agencia: {NumeroAgencia}.";
        Console.WriteLine(mensagem);
    }

    

    public virtual void TaxaBancaria()
    {
        



    }



}
