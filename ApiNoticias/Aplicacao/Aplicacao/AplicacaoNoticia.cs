using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacao
{
    public class AplicacaoNoticia : IAplicacaoNoticia
    {
        INoticia _INoticia;
        IServicoNoticia _IServicoNoticia;

        public AplicacaoNoticia(INoticia INoticia, IServicoNoticia IServicoNoticia)
        {
            _INoticia = INoticia;
            _IServicoNoticia = IServicoNoticia;
        }

        #region Métodos Customizados
        public async Task AdicionaNoticia(Noticia noticia)
        {
            await _IServicoNoticia.AdicionaNoticia(noticia);
        }

        public async Task AtualizaNoticia(Noticia noticia)
        {
            await _IServicoNoticia.AtualizaNoticia(noticia);
        }

        public async Task<List<Noticia>> ListarNoticiasAtivas()
        {
            return await _IServicoNoticia.ListarNoticiasAtivas();
        }
        #endregion

        #region Métodos Genericos
        public async Task Adicionar(Noticia Objeto)
        {
            await _INoticia.Adicionar(Objeto);
        }

        public async Task Atualizar(Noticia Objeto)
        {
            await _INoticia.Atualizar(Objeto);
        }

        public async Task<Noticia> BuscarPorId(int id)
        {
            return await _INoticia.BuscarPorId(id);
        }

        public async Task Excluir(Noticia Objeto)
        {
            await _INoticia.Excluir(Objeto);
        }

        public async Task<List<Noticia>> Listar()
        {
            return await _INoticia.Listar();
        }
        #endregion
    }
}
