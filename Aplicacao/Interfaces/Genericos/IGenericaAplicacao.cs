using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Genericos
{
    public interface IGenericaAplicacao <T> where T : class
    {
        Task Adicionar(T objeto);

        Task Atualizar(T objeto);

        Task Excluir(T objeto);

        Task<T> BuscarPorId(int Id);

        Task<List<T>> Listar();
    }
}
