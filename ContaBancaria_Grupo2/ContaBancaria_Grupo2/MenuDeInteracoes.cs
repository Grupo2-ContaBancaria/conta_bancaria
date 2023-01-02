using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria_Grupo2
{
    public class MenuDeInteracoes
    {
        //MENU DINAMICO, AS ALTERNATIVAS COMUM NAS CLASSES ESTÃO FIXADAS NA LISTA
        // AS ALTERATIVAS EXCUSIVAS SÃO DEFINIDAS EM CADA CONTA E ACRESCENTAS NA LISTA
        public static List<string> ItensMenu { get; set; } = new List<string>() { "Depositar", "Saque", "Extrato", "Sair" };

        //METODO QUE ADICIONA O NOVO NOME DA TRANSAÇAO NO MENU
        public static void MostrarMenu(string novoItem = "")
        {
            string descricaoMenu = "";

            if(novoItem != "")
                ItensMenu.Insert(0, novoItem);

            for (int i = 1; i <= ItensMenu.Count; i++)
            {
                descricaoMenu += $"({i}) {ItensMenu[i-1]} {Environment.NewLine}";
            }

            Console.WriteLine(descricaoMenu);
        }

        //METODO QUE VERIFICA SE A OPÇÃO DIGITADA NO MENU EXISTE NAS ALTERNATIVAS LISTADAS
        public static string EscolherMenu()
        {
            int retorno = ValidadorEConversorNumerico.ConverterParaNumero();
            var itemExiste = retorno <= ItensMenu.Count;
            if (itemExiste)
            {
                Console.WriteLine($"Você escolheu o item {retorno}");
                return ItensMenu[retorno - 1];
            }
            else
            {
                Console.WriteLine("Menu não existe, por favor escolha um número válido.");
                return EscolherMenu();
            }
            
        }



       

    }
}
