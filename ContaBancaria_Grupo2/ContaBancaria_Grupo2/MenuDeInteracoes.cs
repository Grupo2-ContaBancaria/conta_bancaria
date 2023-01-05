using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria_Grupo2
{
    public static class MenuDeInteracoes
    {
        //MENU DINAMICO, AS ALTERNATIVAS COMUM NAS CLASSES ESTÃO FIXADAS NA LISTA
        // AS ALTERATIVAS EXCUSIVAS SÃO DEFINIDAS EM CADA CONTA E ACRESCENTAS NA LISTA
        public static List<string> ItensMenu { get; set; } = new List<string>() { "Depositar", "Saque", "Transferência", "Extrato", "Resgatar Cofrinho", "Sair" };

        //METODO QUE ADICIONA O NOVO NOME DA TRANSAÇAO NO MENU
        public static void MostrarMenu(string tipoConta, string novoItem = "")
        {
            string descricaoMenu = "";

            if (tipoConta == "POUPANÇA")
            {
                ItensMenu.Remove("Resgatar Cofrinho");
               
            }
            if (novoItem != "")
                ItensMenu.Insert(0, novoItem);

            //O I REPRESENTA AS INDICAÇÕES DISPONIVEIS NO MENU, FICA VISIVE PARA O USUARIO,
            //POR ESTE MOTIVO ELE INICIA NO 1
            //NA INDICAÇÃO DE ITENSMENU MOSTRA I-1 PARA INDICAR A POSIÇÃO DOS NOMES REAJUSTADOS, CONSIDERANDO SUA POSIÇÃO NA LISTA(INDEX)
            for (int i = 1; i <= ItensMenu.Count; i++)
            {
                descricaoMenu += $"({i}) {ItensMenu[i - 1]} {Environment.NewLine}";
            }

            Console.WriteLine(descricaoMenu);
           
            //SE A CONTA TIVER UMA OPÇÃO NOVA NO MENU, SERÁ ENVIADA AQUI E ACRESCENTA NESTE METODO NA POSIÇÃO ZERO DA LISTA


            
        }

        //METODO QUE VERIFICA SE A OPÇÃO DIGITADA NO MENU EXISTE NAS ALTERNATIVAS LISTADAS
        public static string EscolherMenu()
        {
            int retorno = ValidadorEConversorNumerico.ConverterParaNumero();
            bool itemExiste = retorno <= ItensMenu.Count;

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
