using System.Globalization;

namespace ContaBancaria_Grupo2
{
    //CLASSE EXLUSIVA PARA TRATAR DO EXTRATO, VISTA POR TODAS AS CONTAS PARA SER POSSIVEL A INCLUSÃO DAS TRANSAÇÃO
    public class ExtratoBancario
    {
        public DateTime DataOperacao { get; set; }
        public enum TipoOperacao
        {
            SAQUE,
            DEPOSITO,
            TRANSFERÊNCIA,
            TRANSFERÊNCIA_COFRINHO,
            RESGATE_COFRINHO,
            COMPRA_ACAO,
            DEPOSITO_SALARIO,
            TAXA_MANUTENÇAO
        }
        public TipoOperacao Tipo { get;  set; }
        public double ValorOperacao { get;  set; }


    }

    public class ListaExtrato : ExtratoBancario
    {
        public List<ExtratoBancario> LstExtrato { get; set; } = new List<ExtratoBancario>();
        public void IncluirTransacaoNoExtrato(TipoOperacao tipo, double valor)
        {
            LstExtrato.Add(new ExtratoBancario
            {
                DataOperacao = DateTime.Now,
                ValorOperacao = valor,
                Tipo = tipo
            });
        }

        //ESTA OPCAO USO PRA CONTA POUPANÇA QUANDO ACESSADA PELA OPÇÃO CONTA ABERTA
        //PARA QUE O DIA DE ABERTURA DA CONTA SEJA ANTES DA DATA ACESSADA
        public void IncluirTransacaoNoExtrato(TipoOperacao tipo, double valor, int diaQueAbriuAConta)
        {
            DateTime diaAntes = DateTime.Now;

            LstExtrato.Add(new ExtratoBancario
            {

                DataOperacao = diaAntes.AddDays(diaQueAbriuAConta),
                ValorOperacao = valor,
                Tipo = tipo
            });
        }
        public void MostrarExtrato()
        {
            var cabecalho = "Data                     Tipo                 Valor";
            var corpo = "";
            foreach (var item in LstExtrato)
            {
                corpo += $"{item.DataOperacao.ToString("dd/MM/yy HH:mm:ss")}        {item.Tipo}          {item.ValorOperacao.ToString("F2", CultureInfo.InvariantCulture)} {Environment.NewLine}";
            }
            Console.WriteLine(cabecalho);
            Console.WriteLine(corpo);
        }
    }
}
