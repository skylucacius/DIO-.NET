using System;
using System.Collections.Generic;

namespace C__101
{
    class Program
    {
        static void M1() {
            Console.WriteLine("Por favor, escolha uma opção:");
            Console.Write("1 - Para Hello World");
            var option = Console.ReadKey().ToString();

            switch(option)
            {
                case "1" :
                    Console.WriteLine("Hello World ! " + "Hoje é " + DateTime.Now);
                    break;
            }
        }
        static void M2() {
            var nomes = new List<String> { "Lucas", "Maria", "João"};
            foreach (string nome in nomes) {
                Console.WriteLine($"Olá, {nome}");

            }
        }
        static void Main(string[] args)
        {
            M1();
            M2();
        }
    }
}
