using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series {
    public class SerieRepositorio : IRepositorio<Serie>
    {
        public List<Serie> listaDeSeries = new List<Serie>();
        //esse método pode ser removido da interface
        // public List<Serie> Listar()
        // {
        //     return listaDeSeries;
        // }
        public void Atualizar(int id, Serie entidade)
        {
            listaDeSeries[id] = entidade;
        }
        public void Excluir(int id)
        {
            // listaDeSeries.Remove(listaDeSeries[id]); // não iremos remover de fato. Será feito um soft delete.
            listaDeSeries[id].Exclui();
        }
        public void Inserir(Serie entidade)
        {
            listaDeSeries.Add(entidade);
        }
        public int ProximoId()
        {
            return listaDeSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaDeSeries[id];
        }
    }
}