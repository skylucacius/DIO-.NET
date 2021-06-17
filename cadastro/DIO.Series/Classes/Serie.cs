using System;

namespace DIO.Series {
    public class Serie : EntidadeBase
    {
        public Genero Genero {get;private set;}
        public string Titulo {get;private set;}
        public string Descricao {get;private set;}
        public int Ano {get;private set;}
        public bool Excluido {get; private set;}
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }
        public void Exclui() {
            Excluido = true;
        }
        public override string ToString()
        {
            var mensagem = "";
            mensagem +=   "Gênero: " + Genero + Environment.NewLine;
            mensagem += "Título: " + Titulo + Environment.NewLine;
            mensagem += "Descrição: " + Descricao + Environment.NewLine;
            mensagem += "Ano de Início: " + Ano + Environment.NewLine;
            return mensagem;
        }
        
        //Titulo e Id terão seus getters públicos. O mesmo para os demais.
        // public string RetornaTitulo() {
        //     return Titulo;
        // }
        // public int RetornaId() {
        //     return Id;
        // }
    }
}