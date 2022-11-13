

using AgenciaDestinos.Model;

namespace AgenciaDestinos.Repository
{
    public interface IDestinosRepository
    {   
        Task<IEnumerable<Destinos>> GetDestinostodos();
      
        Task<Destinos> GetDestinosById(int id);

        void AtualizarDestinos(Destinos destinos);

        void DeletarDestinos(Destinos destinos);

        Task<bool> SaveChangesAsnyc();
        void AddDestinos(Destinos destinos);
    }
}