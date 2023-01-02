using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria_Grupo2
{
    internal class ConfiguracaoLayout
    {
        public static void LayoutDoConsole()
        {
            Console.Title = "BANCO GRUPO 2";
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Clear();

            Console.WriteLine(" --------------------------------");
            Console.WriteLine(" ------- 《 NOSSO BANCO 》 ------");
            Console.WriteLine(" -------------(♥  ♥)-------------");
           
        }

        //LIMPA O CONSOLE E CHAMA DE NOVO AS CONFIGURAÇÕES
        public static void ClearLayout()
        {
            Console.Clear();
            LayoutDoConsole();
            Console.WriteLine("\n");
        }
    }
}
