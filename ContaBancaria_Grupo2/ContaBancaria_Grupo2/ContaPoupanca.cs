using ContaBancaria_Grupo2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ContaPoupanca : Conta
{
    //ESTA CLASSE HERDA AS PROPRIEDADES OBRIGATORIAS DA CLASSE CONTA 

    public ContaPoupanca(int numeroConta, int numeroAgencia, string nomeCompleto, long cpf, double saldoInicial) : base(numeroConta, numeroAgencia, nomeCompleto, cpf)
    {
        double primeiroDeposito = saldoInicial;
        
        //A POUPANÇA PRECISA DE SALDO INICIAL, ENTÃO ESTA CONDIÇÃO CHAMA O METODO DEPOSITO PARA FINALIZAR A OPERAÇÃO DE ABERTURA DA CONTA

        if (primeiroDeposito < 50.00)
        {
            //WHILE GARANTE QUE O 1° DEPOSITO SEJA 50,00 OU MAIOR
            do
            {
                Console.WriteLine($"{Environment.NewLine}{NomeCompleto.Split(" ")[0]}, Para finalizar é necessario, fazer uma transferência de valor minimo R$ 50,00.\n Digite o valor que deseja tranferir:");
                primeiroDeposito = ValidadorEConversorNumerico.ConverterParaDouble();

            } while (primeiroDeposito < 50);

            //CHAMA O METODO DE DEPOSITO
            Depositar(primeiroDeposito);

            //REGISTRA NO EXTRATO
            IncluirTransacaoNoExtrato(TipoOperacao.DEPOSITO, primeiroDeposito);

            //INICIA UMA NOVA TELA
            ConfiguracaoLayout.ClearLayout();

            Saudacao("Poupança");
            Console.WriteLine($"Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}{Environment.NewLine}");
        }
        else
        {
            //CASO A OPÇÃO SELCIONADA SEJA CONTA EXISTENTE, AS PROPRIEDADES DA CLASSE SERÃO PREENHIDAS COM AS ENTRADAS DESTES CAMPOS
            //IMAGINA-SE QUE A CONTA FOI ABERTA NUM DIA ANTERIOR E O PROCCESSO DE DEPOSITO FOI REALIZADO COM O VALOR MINIMO

            ConfiguracaoLayout.ClearLayout();

            //NESTE CAMPO O SALDO VEM COMO ARGUMENTO NO VALOR MINIMO
            Saldo = primeiroDeposito;

            //O REGISTRO DA OPERAÇÃO E FEITO COM DATA RETROATIVA
            IncluirTransacaoNoExtrato(TipoOperacao.DEPOSITO, primeiroDeposito,-2);

            Console.WriteLine($"{Environment.NewLine}Bem Vindo(a),{NomeCompleto}\nAg:{NumeroAgencia} conta poupança:{NumeroConta}");
            Console.WriteLine($"{Environment.NewLine}Seu Saldo Atual {Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
        }
        //CONTA CRIADA, CHAMADA DOS METODOS DE TAXA E MENU DE OPÇÕES
        TaxaBancaria();
      

        AcoesDaConta("POUPANÇA");
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
        double TaxaManutencao = 0.35;

        Saldo -= TaxaManutencao;
        IncluirTransacaoNoExtrato(TipoOperacao.TAXA_MANUTENÇAO, TaxaManutencao);
    }
        

}





