using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria_Grupo2
{
    public static class ValidadorEConversorNumerico
    {
        // METODO DE CONVERSÃO, ELE RECEBE A ENTRADA DO USUARIO, VALIDA E CONVERTE (ATRAVES DA RECURSIVIDADE E POSSIVEL GARATIR QUE A ENTRADA SERÁ UM NÚMERO.
        public static int ConverterParaNumero()
        {
            string valorDigitado = Console.ReadLine();

            bool validador = int.TryParse(valorDigitado, out int numeroConvertido);

            if (!validador)
            {
                Console.WriteLine("O valor digitado é inválido. Digite novamente:");
                return ConverterParaNumero();

            }
            return numeroConvertido;
        }
        //METODO DE CONVERSAO PARA LONG, UTLIZADO NO CPF
        public static long ConverterParaLong()
        {
            string valorDigitado = Console.ReadLine();

            bool validador = long.TryParse(valorDigitado, out long numeroConvertido);

            ValidarTamanhoDoCpf(valorDigitado);


            if (!validador)
            {
                Console.WriteLine("O valor digitado é inválido. Digite novamente:");
                return ConverterParaLong();
            }


            return numeroConvertido;
        }
        public static long ConverterParaLongCnpj()
        {
            string valorDigitado = Console.ReadLine();

            bool validador = long.TryParse(valorDigitado, out long numeroConvertido);

            ValidarTamanhoDoCnpj(valorDigitado);


            if (!validador)
            {
                Console.WriteLine("O valor digitado é inválido. Digite novamente:");
                return ConverterParaLongCnpj();
            }


            return numeroConvertido;
        }

        // METODO DE CONVERSAO PARA DOUBLE, UTILIZADO NO SALARIO
        public static double ConverterParaDouble()
        {
            string valorDigitado = Console.ReadLine();
            bool validador = double.TryParse(valorDigitado, out double numeroConvertido);


            if (!validador)
            {
                Console.WriteLine("O valor digitado é inválido. Digite novamente:");
                return ConverterParaLong();
            }


            return numeroConvertido;
        }

        //METODOS DE VALIDAÇÃO

        public static int ValidarEntradaFormularioInvestidor()
        {
            var numeroAlternativa = ConverterParaNumero();
            if (numeroAlternativa > 3)
            {
                Console.WriteLine("Alternativa inválida.");
                ValidarEntradaFormularioInvestidor();
            }
            return numeroAlternativa;
        }

        public static void ValidarTamanhoDoCpf(string cpf)
        {
            int tamanhoDaString = cpf.Length;

            if (tamanhoDaString != 11)
            {
                Console.WriteLine("Você não digitou corretamente. Digite novamente:");
                ConverterParaLong();
            }


        }
        public static void ValidarTamanhoDoCnpj(string cpf)
        {
            int tamanhoDaString = cpf.Length;

            if (tamanhoDaString != 14)
            {
                Console.WriteLine("Você não digitou corretamente. Digite novamente:");
                ConverterParaLongCnpj();
            }


        }
        
    }
}

