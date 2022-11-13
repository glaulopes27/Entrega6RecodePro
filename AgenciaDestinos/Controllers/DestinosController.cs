
using AgenciaDestinos.Model;
using AgenciaDestinos.Repository;
using Microsoft.AspNetCore.Mvc;


namespace AgenciaDestinos.Controllers
{
    [ApiController]
    [Route("api/[destinos]")]
    public class DestinosController : ControllerBase
    {
         private readonly IDestinosRepository _repository;

        public DestinosController(IDestinosRepository repository)
        {
            _repository = repository;
        }
        //listar todos 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var destinostodos = await _repository.GetDestinostodos();
            return destinostodos.Any() ? Ok(destinostodos) : NoContent();
        }
        //busca por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var destinos = await _repository.GetDestinosById(id);
            return destinos != null
            ? Ok(destinos) : NotFound("Destino não encontrado.");
        }
         //post
        [HttpPost]
        public async Task<IActionResult> Post(Destinos destinos)
        {
            _repository.AddDestinos(destinos);
            return await _repository.SaveChangesAsnyc()
            ? Ok("Destino adicionado") : BadRequest("Ocorreu algo fora do esperado.");
        }
        //put por id

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Destinos destinos)
        {
            var destinosExiste = await _repository.GetDestinosById(id);
            if (destinosExiste == null) return NotFound("Destino não foi encontrado");

            destinosExiste.Nome = destinos.Nome ?? destinosExiste.Nome;
            destinosExiste.Descricao = destinos.Descricao ?? destinosExiste.Descricao;
            destinosExiste.DataPacote = destinos.DataPacote != new DateTime()
            ? destinos.DataPacote : destinosExiste.DataPacote;

            _repository.AtualizarDestinos(destinosExiste);

            return await _repository.SaveChangesAsnyc()
            ? Ok("Destino atualizado.") : BadRequest("Destino NÃO atualizado.");
        }
        // deletar por id
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var destinosExiste = await _repository.GetDestinosById(id);
            if (destinosExiste == null)
                return NotFound("Destino NÃO encontrado");

            _repository.DeletarDestinos(destinosExiste);

            return await _repository.SaveChangesAsnyc()
            ? Ok("Destino deletado.") : BadRequest("Destino NÃO Deletado devido à erro.");
        }
    }

}      
    