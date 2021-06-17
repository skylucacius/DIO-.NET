# Aplicativo de console em C# para cadastro de séries em memória

Baseado no treinamento da DIO - Digital Innovation One - para o bootcamp GFT #2 .Net. Há algumas diferenças em relação a aplicação desenvolvida pelo instrutor:

> Foram usados Getters públicos e Setters privados para as propriedades da classe Serie.cs;

> Há um método serieValida(int id) que retorna se a série existe (mesmo que tenha sido feito "soft delete" dela). E há também o método SerieNaoFoiExcluida(int id) que retorna se a série não foi excluída. Pois essas verificações são feitas em mais de um lugar na aplicação.