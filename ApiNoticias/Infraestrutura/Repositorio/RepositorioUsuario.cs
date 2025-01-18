using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioUsuario : RepositorioGenerico<ApplicationUser>, IUsuario
    {
        private readonly DbContextOptions<Contexto> _optionsBuilder;

        public RepositorioUsuario()
        {
            _optionsBuilder = new DbContextOptions<Contexto>();
        }

        public async Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular)
        {
            try
            {
                using (var banco = new Contexto(_optionsBuilder))
                {
                    await banco.ApplicationUser.AddAsync(
                        new ApplicationUser
                        {
                            Email = email,
                            PasswordHash = senha,
                            Idade = idade,
                            Celular = celular
                        });

                    await banco.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
