using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria_Grupo2
{
    public class MenuDeInteracoes
    {
        public static int MenuContaInvestimento()
        {
            Console.WriteLine("O que deseja fazer?\n" +
            "(1) Deposito\n" +
            "(2) Saque\n" +
            "(3) Comprar Ações\n" +
            "(4) Extrato\n" +
            "(5) Sair");


            int retorno = ValidadorEConversorNumerico.ValidarEntradaMenuInvestidor();

            return retorno;
        }

        public static int MenuContaSalario()
        {
            Console.WriteLine("O que deseja fazer?\n" +
           "(1) Depositar Salário\n" +
           "(2) Saque\n" +
           "(3) Extrato\n" +
           "(4) Sair");


            int retorno = ValidadorEConversorNumerico.ValidarEntradaMenuInvestidor();

            return retorno;

        }
        public static int MenuContaPoupanca()
        {
            Console.WriteLine("O que deseja fazer?\n" +
           "(1) Tranferência para Poupança\n" +
           "(2) Saque\n" +
           "(3) Extrato\n" +
           "(4) Sair");


            int retorno = ValidadorEConversorNumerico.ValidarEntradaMenuInvestidor();

            return retorno;

        }

    }
}
