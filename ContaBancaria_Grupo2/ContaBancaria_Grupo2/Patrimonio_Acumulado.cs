using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContaBancaria_Grupo2.ExtratoBancario;

namespace ContaBancaria_Grupo2
{
    //CLASSE DESTINADA A TRATAR INFORMAÇÕES EXCLUSIVAS DE CONTA INVESTIMENTO, ELA E INSTANCIADA NO CONSTRUTOR DA CLASSE DE INVESTIMENTO COM VALORES NULL
    public class Patrimonio_Acumulado
    {
        
        public DateTime DataCompraAcao { get; protected set; } = DateTime.Now;
        public string NomeAcao { get; protected set; }
        public double Patrimonio_Total { get; protected set; }

        public double ValorInvestido { get; protected set; }

        public List<Patrimonio_Acumulado> LstPainel { get; protected set; } = new List<Patrimonio_Acumulado>();

        public Patrimonio_Acumulado(string nomeAcao, double valorInvestido)
        {
            NomeAcao = nomeAcao;
            ValorInvestido = valorInvestido;

        }
    }

    public class Painel_Investimento : Patrimonio_Acumulado
    {
        public Painel_Investimento(string nomeAcao, double valorInvestido) : base(nomeAcao, valorInvestido)
        {
            NomeAcao = nomeAcao;
            ValorInvestido = valorInvestido;

        }

        //METODOS PARA INCLUIR TRANSAÇAÕ DE COMPRA NO EXTRATO E TAMBEM QUE ADICIONA O VALOR DA COMPRA NO TOTAL DE PATRIMONIO.
        public void IncluirTransacaoNoPainel(string papel, double valor)
        {
            LstPainel.Add(new Patrimonio_Acumulado(papel, valor));
            Patrimonio_Total += valor;
        }

        //METODO QUE INCLUI AS AÇÕES COMPRADAS NO EXTRATOS
        public void MostrarInvestimentos()
        {
            var cabecalho = "Data                     Papel                 Valor";
            var corpo = "";
            foreach (var item in LstPainel)
            {
                corpo += $"{item.DataCompraAcao.ToString("dd/MM/yy HH:mm:ss")}        {item.NomeAcao}          {item.ValorInvestido.ToString("F2", CultureInfo.InvariantCulture)} {Environment.NewLine}";
            }
            Console.WriteLine("------ Extrato de Ações ---------");

            Console.WriteLine(cabecalho);
            Console.WriteLine(corpo);
            Console.WriteLine("Valor Total Investido em Ações: " + Patrimonio_Total.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
