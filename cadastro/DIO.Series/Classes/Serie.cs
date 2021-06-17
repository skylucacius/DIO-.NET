using System;

namespace DIO.Series {
    //inserir a entidade base como classe pai de série
    public class Serie : EntidadeBase
    {
        private Genero Genero {get; set;}
        private string Titulo {get;set;}
        private string Descricao {get;set;}
        private int Ano {get;set;}
        private bool Excluido {get;set;}
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
        public string RetornaTitulo() {
            return Titulo;
        }
        public int RetornaId() {
            return Id;
        }
    }
}