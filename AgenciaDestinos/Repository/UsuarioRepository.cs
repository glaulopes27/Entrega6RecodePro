
using AgenciaDestinos.Database;
using AgenciaDestinos.Model;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDestinos.Repository
{
    public class UsuarioRepository : IUsuarioRepository

    {
        //injetar dependencia do contexto
        private readonly UsuarioDbContext _context;
        //instancia 
        public UsuarioRepository(UsuarioDbContext context)
        {
            _context = context; //contrutor
        }
        // adicionar
        public void AddUsuario(Usuario usuario)
        {
            _context.Add(usuario);
        }
        //atualizar 
        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Update(usuario);
        }
         //deletar 
        public void DeletarUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
        }
        //buscar pelo ID
        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Usuarios
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    
        //gerar novos usuarios
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}