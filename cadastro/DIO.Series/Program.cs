using System;
using static System.Console;

namespace DIO.Series
{
    class Program : SerieRepositorio
    {
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
            return OpcaoUsuario;
        }
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();
            Console.WriteLine();
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
                    case "3": {
                        AtualizarSerie();
                        break;
                    }
                    case "4": {
                        ExcluirSerie();
                        break;
                    }
                    case "5": {
                        VisualizarSerie();
                        break;
                    }
                    case "C": {
                        LimparTela();
                        break;
                    }
                    default : {
                        WriteLine();
                        break;
                    }
                }
            }
        }

        private static void LimparTela()
        {
            Console.Clear();
        }

        private static void ExcluirSerie()
        {
            ListarSeries();
            WriteLine("Digite um número de série para deletar:");
            int id = int.Parse(Console.ReadLine());
            if (SerieValida(id)) {
                if (SerieNaoFoiExcluida(id)) {
                var serieEscolhida = repositorio.listaDeSeries[id];
                serieEscolhida.Exclui();
                WriteLine($"A série {serieEscolhida.Titulo} foi excluída.");
                }
                else WriteLine("Série já foi excluída.");
            }
                
            else 
                WriteLine("Id de série inválido.");
        }
        private static void VisualizarSerie()
        {
            ListarSeries();
            WriteLine("Digite um número de série para visualizar:");
            int id = int.Parse(Console.ReadLine());
            if (SerieValida(id))
                if (SerieNaoFoiExcluida(id))
                    // imprime o retorno do método ToString() da classe série;
                    WriteLine(repositorio.listaDeSeries[id]);
                else
                    WriteLine("Série foi excluída.");
            else 
                WriteLine("Id de série inválido.");
        }
        public static bool SerieValida(int id) {
            return repositorio.RetornaPorId(id) != null;
        }
        public static bool SerieNaoFoiExcluida(int id) {
            return !repositorio.RetornaPorId(id).Excluido;
        }

        private static void AtualizarSerie()
        {
            ListarSeries();
            WriteLine("Escolha um Id de série para atualizar.");
            var idEscolhido = int.Parse(Console.ReadLine());
            if (SerieValida(idEscolhido)) {
                if (SerieNaoFoiExcluida(idEscolhido)) {
                ListarGeneros();
                WriteLine("Número do novo gênero da série:");
                var novoGenero = ReadLine();
                WriteLine("Novo título da série:");
                var novoTitulo = ReadLine();
                WriteLine("Novo ano de publicação da série:");
                var novoAno = ReadLine();
                WriteLine("Nova descrição da série:");
                var novaDescricao = ReadLine();
                
                var serieAtualizada = 
                    new Serie(idEscolhido, (Genero) int.Parse(novoGenero), novoTitulo, novoAno, int.Parse(novaDescricao));
                repositorio.Atualizar(idEscolhido, serieAtualizada);
                }
                else WriteLine("Série já foi excluída.");
            }
            else {
                WriteLine("Id de série inválido.");
            }
        }

        private static void InserirSerie()
        {
            ListarGeneros();
            //entrada de valores do usuário
            WriteLine("Informe o número referente ao gênero da série: ");
            var genero = ReadLine();
            WriteLine("Informe o título da série: ");
            var titulo = ReadLine();
            WriteLine("Informe o ano de lançamento da série: ");
            var ano = ReadLine();
            WriteLine("Informe a descrição da série: ");
            var descricao = ReadLine();

            var NovaSerie = 
                new Serie(repositorio.ProximoId(), (Genero)int.Parse(genero), titulo, descricao, int.Parse(ano));
            repositorio.Inserir(NovaSerie);
            
        }

        private static void ListarGeneros()
        {
            WriteLine("Lista de gêneros:");
            foreach (int i in Enum.GetValues(typeof(Genero))) // imprime todos os gêneros
            {
                WriteLine($"Id {i} - {Enum.GetName(typeof(Genero), i)}");
            }
        }

        private static void ListarSeries()
        {
            if (repositorio.listaDeSeries == null)  {
                WriteLine("Não há séries cadastradas.");
                return; 
            }
            WriteLine("Lista de séries");
            foreach(var serie in repositorio.listaDeSeries) {
                if (SerieNaoFoiExcluida(serie.Id))
                    WriteLine($"Id {serie.Id} - {serie.Titulo}");
            }
        }
    }
}