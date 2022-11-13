using AgenciaDestinos.Model;

namespace AgenciaDestinos.Repository
{
    public interface IUsuarioRepository // crud
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        void AddUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        void DeletarUsuario(Usuario usuario);
        Task<bool> SaveChangesAsync();// executar no banco
        
    }
}