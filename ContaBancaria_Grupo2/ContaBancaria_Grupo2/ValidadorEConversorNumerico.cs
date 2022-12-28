using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria_Grupo2
{
    public static class ValidadorEConversorNumerico
    {
        // metodos de conversão, eles fazem a pergunta, recebem o retornam, convertem e em caso de erro entram no loop (recursividade)
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
        //usei o long para o CPF, mas precisa incluir algo que valide a quantidade de caracter digitado **Verificar um metodo ou ação de validação
        public static long ConverterParaLong()
        {
            string valorDigitado = Console.ReadLine();
            bool validador = long.TryParse(valorDigitado, out long numeroConvertido);


            if (!validador)
            {
                Console.WriteLine("O valor digitado é inválido. Digite novamente:");
                return ConverterParaLong();
            }


            return numeroConvertido;
        }

        // usei para converter salario
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

        // para verificar o formulario de investidor nas alternativas, se for maior que as opções
        
        public static bool ValidarEntradaFormularioInvestidor(int numeroEscolhido)
        {
           return numeroEscolhido > 3 ? false:true;
        }

        public static void ValidadorDeNumeroDigitado(int numeroDigitado, int qtdDeAlternativas)
        {
            if(numeroDigitado > qtdDeAlternativas)
            {
                Console.WriteLine("Número Inválido");
            }
        }
    }
}

