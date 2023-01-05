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
            this.Cnpj = ValidadorEConversorNumerico.ConverterParaLongCnpj();

            Console.WriteLine("Seu Cargo: ");
            this.Cargo = Console.ReadLine();

            Console.WriteLine("Seu Salário Bruto: ");
            this.Salario = ValidadorEConversorNumerico.ConverterParaDouble();


            //CONTA CRIADA, EXIBIÇÃO DE NOVA TELA DE ACESSO
            ConfiguracaoLayout.ClearLayout(); 
            Saudacao("Salário");
            Console.WriteLine($"Seu Saldo Atual {Saldo}{Environment.NewLine}");
        }
        else
        {

            //NESTE CASO HABILITA O ACESSO PELA CONTA EXISTENTE, ENTÃO OS ARGUMENTOS PARA ATRIBUIÇÃO DAS PROPRIEDADES SÃO DIFERENTES
            
            NomeEmpregador = empregador;
            Cnpj = 11111111111111;
            Cargo = "CargoTeste Sr.";
            Salario = 25000.00;

            ConfiguracaoLayout.ClearLayout(); ;

            Console.WriteLine($"{Environment.NewLine}Bem Vindo(a),{NomeCompleto}\nAg:{NumeroAgencia} conta Salário:{NumeroConta} {Environment.NewLine}");
            Console.WriteLine($"{Environment.NewLine}Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
        }
        
        TaxaBancaria();
        TipoAcaoDaConta = "Depositar Salário";
        
        AcoesDaConta("SALARIO");

    }
   

    //O METODO DE DEPOSITO E INCLUIDO UMA CONDIÇÃO
    public override void Depositar(double valor)
    {
        Console.WriteLine("informe o CNPJ do Empregador:");
        long numeroCnpj = ValidadorEConversorNumerico.ConverterParaLongCnpj();

        if (numeroCnpj != Cnpj)
        {
            throw new Exception("Dado Inválido!");
        }
        else
        {
            base.Depositar(valor);
        }


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
        double TaxaManutencao = 0.3;

        Saldo -= TaxaManutencao;
        IncluirTransacaoNoExtrato(TipoOperacao.TAXA_MANUTENÇAO, TaxaManutencao);
    }

    /*
     * 
    - Para a contaInvestimento: taxa de 0.8
    - Para a contaPoupanca: taxa de 0.3,5
    - Para a contaSalario: taxa de 0.3
    */

}





