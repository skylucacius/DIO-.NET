# Aplicativo de console em C# para cadastro de séries em memória

Baseado no treinamento da DIO - Digital Innovation One - para o bootcamp GFT #2 .Net. Há algumas diferenças em relação a aplicação desenvolvida pelo instrutor:

> Foram usados Getters públicos e Setters privados para as propriedades da classe Serie.cs;

> Há um método serieValida(int id) que retorna se a série existe (mesmo que tenha sido feito "soft delete" dela). E há também o método SerieNaoFoiExcluida(int id) que retorna se a série não foi excluída. Esse último método foi realizado na aula.

> É feito uso de try-catch onde há conversão de variável através de entrada de usuário.

> Ao atualizar uma série, é exibido a lista de séries.

> Foi implementada uma funcionalidade de importar/exportar séries para um arquivo CSV. É necessário que o mesmo tenha a estrutura:

<Gênero>;<Título>;<Ano>;<Descrição>;<Se o arquivo foi excluído (true, false)>

Para evitar uma maior complexidade, essa funcionalidade não lida com os Ids das séries.