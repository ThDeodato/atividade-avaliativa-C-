using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atv_01
{


    class Program
    {
        static void Main()
        {
            
            Console.Write("Digite um número inteiro: ");

            
            string input = Console.ReadLine();

           
            if (int.TryParse(input, out int numero))
            {
                
                string representacaoPorExtenso = ConverteNumeroPorExtenso(numero);

                
                Console.WriteLine($"Número por extenso: {representacaoPorExtenso}");
            }
            else
            {
                Console.WriteLine("Por favor, insira um número inteiro válido.");
            }

            
            Console.ReadLine();
        }

        static string ConverteNumeroPorExtenso(int numero)
        {
            
            return NumberToWords(numero);
        }

        static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "menos " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " milhão ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " mil ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " cem ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "e ";

                var unidades = new[] { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "catorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
                var dezenas = new[] { "", "", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
                var centenas = new[] { "", "cem", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seisentos", "setesentos", "oitocentos", "novecentos", "mil" };
                if (number < 20)
                    words += unidades[number];
                else
                {
                    words += dezenas[number / 10];
                    if ((number % 10) > 0)
                        words += " e " + unidades[number % 10];
                }
            }

            return words;
        }
    }
}


