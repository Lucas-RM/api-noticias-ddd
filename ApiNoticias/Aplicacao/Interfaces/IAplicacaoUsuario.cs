using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoUsuario
    {
        Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular);
        Task<bool> ExisteUsuario(string email, string senha);
    }
}
