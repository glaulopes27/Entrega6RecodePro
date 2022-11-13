
using AgenciaDestinos.Database;
using AgenciaDestinos.Model;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDestinos.Repository
{
    public class DestinosRepository : IDestinosRepository

    {
        
        private readonly UsuarioDbContext _context;

        public DestinosRepository(UsuarioDbContext context) {
            _context = context; 

        }
        
        public void AddDestinos(Destinos destinos)
        {
            _context.Add(destinos);
        }

        public void AtualizarDestinos(Destinos destinos)

        {
            _context.Update(destinos);
        }

        public void DeletarDestinos(Destinos destinos)
        {
            throw new NotImplementedException();
        }

        public void DeleteDestinos(Destinos destinos)

        {
            _context.Remove(destinos);
        }

        public Task<IEnumerable<Destinos>> GetDestinos()
        {
            throw new NotImplementedException();
        }

        public async Task<Destinos> GetDestinosById(int id)

        {
            return await _context.Destinostodos.Where(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Destinos>> GetDestinostodos()
        {
            return await _context.Destinostodos.ToListAsync();
        }
       
        public Task<bool> SaveChangesAsnyc()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
    



