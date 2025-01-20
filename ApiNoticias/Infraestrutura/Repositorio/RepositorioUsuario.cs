using Dominio.Interfaces;
using Entidades.Entidades;
using Entidades.Enums;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
                            Celular = celular,
                            Tipo = ETipoUsuario.Comum
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

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            try
            {
                using (var banco = new Contexto(_optionsBuilder))
                {
                    return await banco.ApplicationUser
                        .Where(u => u.Email.Equals(email) && u.PasswordHash.Equals(senha))
                        .AsNoTracking()
                        .AnyAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
