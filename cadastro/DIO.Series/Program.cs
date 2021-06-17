using System;
using static System.Console;

namespace DIO.Series
{
    class Program : SerieRepositorio
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario != "S") {
                switch (OpcaoUsuario)
                {
                    case "1": {
                        ListarSeries();
                        break;
                    }
                    case "2": {
                        InserirSerie();
                        break;
                    }                    
                    default : {
                        WriteLine();
                        break;
                    }
                }
            }
        }

        private static void InserirSerie()
        {
            WriteLine("Lista de gêneros:");
            foreach(int i in Enum.GetValues(typeof(Genero))) // imprime todos os gêneros
            {
                WriteLine($"Id {i} - {Enum.GetName(typeof(Genero), i)}");
            }
            //entrada de valores do usuário
            WriteLine("Informe o número referente ao gênero da série: ");
            var genero = ReadLine();
            WriteLine("Informe o título da série: ");
            var titulo = ReadLine();
            WriteLine("Informe o ano de lançamento da série: ");
            var ano = ReadLine();
            WriteLine("Informe a descrição da série: ");
            var descricao = ReadLine();

            repositorio.Insere
                (new Serie(repositorio.ProximoId(), (Genero)int.Parse(genero), titulo, descricao, int.Parse(ano)));
        }

        private static void ListarSeries()
        {
            if (repositorio.listaSerie == null)  {
                WriteLine("Não há séries cadastradas.");
                return; 
            }
            foreach(var serie in repositorio.listaSerie) {
                WriteLine($"Id {serie.Id} - {serie.RetornaTitulo()}");
            }
        }
        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            WriteLine("DIO Séries a seu dispor!");
            WriteLine("Informe a opção desejada:");
            WriteLine("1 - Listar séries");
            WriteLine("2 - Inserir nova série");
            WriteLine("3 - Atualizar série");
            WriteLine("4 - Excluir série");
            WriteLine("5 - Visualizar série");
            WriteLine("C - Limpar tela");
            WriteLine("S - Sair");
            WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
