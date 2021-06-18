using System;
using System.IO;
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
            WriteLine("6 - Exportar séries para CSV");
            WriteLine("7 - Importar séries de arquivo CSV");
            WriteLine("C - Limpar tela");
            WriteLine("S - Sair");
            WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            return OpcaoUsuario;
        }
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = "";
            while (OpcaoUsuario != "S") {
                OpcaoUsuario = ObterOpcaoUsuario();
                Console.WriteLine();
                switch (OpcaoUsuario)
                {
                    case "1": {
                        ListarSeries();
                        Console.ReadLine();
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
                    case "6": {
                        ExportarParaCSV();
                        break;
                    }
                    case "7": {
                        ImportarDeCSV(new StreamReader("arquivo.csv"));
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

        private static void ExportarParaCSV()
        {
            using (var arquivo = new StreamWriter("arquivo.csv")) {
            foreach (var serie in repositorio.listaDeSeries) {
                string linha = $"{serie.Genero};{serie.Titulo};{serie.Ano};{serie.Descricao};{serie.Excluido};";
                arquivo.WriteLine(linha);
            }
            }
        }
        private static void ImportarDeCSV(StreamReader arquivo) {
            using (arquivo) {
                while (!arquivo.EndOfStream) {
                var linha = arquivo.ReadLine().Split(";");
                // linha é um vetor de string com 5 elementos
                //série com genero, titulo, descrição e ano sem seu construtor
                try {
                var generoLido = (Genero)Enum.Parse(typeof(Genero),linha[0]);
                var novaSerie = new Serie(repositorio.ProximoId(),generoLido,linha[1],linha[3],int.Parse(linha[2]));
                repositorio.Inserir(novaSerie);
                }
                catch (ArgumentException e) {
                    WriteLine("Erro de argumento: ", e.Message);
                }
                catch (FormatException e){
                    WriteLine("Erro de formato: ", e.GetBaseException().Message, e.Message);
                }
                catch (Exception e) {
                    WriteLine("Erro: ",e.Message);
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
                Console.ReadLine();
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
            Console.ReadLine();
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
            int idEscolhido;
            try {
            idEscolhido = int.Parse(Console.ReadLine());
            }
            catch {
                    WriteLine("Conversão inválida!");
                    return;
            }
            if (SerieValida(idEscolhido)) {
                if (SerieNaoFoiExcluida(idEscolhido)) {
                ListarGeneros();
                WriteLine("Número do novo gênero da série:");
                string novoGenero = ReadLine();
                WriteLine("Novo título da série:");
                string novoTitulo = ReadLine();
                WriteLine("Novo ano de publicação da série:");
                string novoAno = ReadLine();
                WriteLine("Nova descrição da série:");
                string novaDescricao = ReadLine();

                try {
                Serie serieAtualizada = new Serie
                    (idEscolhido, (Genero) int.Parse(novoGenero), novoTitulo, novaDescricao, int.Parse(novoAno));
                repositorio.Atualizar(idEscolhido, serieAtualizada);
                }
                catch {
                    WriteLine("Conversão inválida! Não foi possível atualizar!");
                }

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
            //entrada de valores do usuário para inserção
            WriteLine("Informe o número referente ao gênero da série: ");
            var genero = ReadLine();
            WriteLine("Informe o título da série: ");
            var titulo = ReadLine();
            WriteLine("Informe o ano de lançamento da série: ");
            var ano = ReadLine();
            WriteLine("Informe a descrição da série: ");
            var descricao = ReadLine();

            try {
            var NovaSerie = new Serie
                (repositorio.ProximoId(), (Genero) int.Parse(genero), titulo, descricao, int.Parse(ano));
            repositorio.Inserir(NovaSerie);
            }
            catch {
                WriteLine("Conversão inválida! Não foi possível inserir!");
                }
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
            if (repositorio.listaDeSeries.Count == 0)  {
                WriteLine("Não há séries cadastradas.");
                return; 
            }
            WriteLine("Lista de séries");
            //TODO: verificar o caso em que todas as séries foram excluídas.
            foreach(var serie in repositorio.listaDeSeries) {
                string excluida = serie.Excluido ? " *Excluída*" : "";
                WriteLine($"Id {serie.Id} - {serie.Titulo} { excluida }");
            }
        }
    }
}