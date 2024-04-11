using BackendNotificacaoDeAudiecia.Data;
using BackendNotificacaoDeAudiecia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BackendNotificacaoDeAudiecia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacaoController : ControllerBase
    {
        private readonly NotificacaoDbContext _context;
        public NotificacaoController(NotificacaoDbContext context)
        {
            _context = context;       
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AudienciaModels>>> GetAudiencia()
        {
            TimeSpan horarioAtual = DateTime.Now.TimeOfDay;
            TimeSpan horarioInicial = new TimeSpan(10, 30, 0);  // -> MUDAR O HORARIO AO ENTREGAR
            TimeSpan horarioFinal = new TimeSpan(20, 20, 0);

            if (horarioAtual >= horarioInicial && horarioFinal >= horarioAtual)
            {
                var audiencias = await _context.Audiencia.ToListAsync();
                int totalDePessoas = audiencias.Sum(a => a.QuantidadeDePessoas);
                var computadores = await _context.Audiencia.CountAsync();
                return Ok(new { Audiencias = audiencias, TotalDepessoas = totalDePessoas, Computadores = computadores });
            }
            else
            {
                try
                {
                    var audienciaContext = _context.Audiencia;
                    audienciaContext.RemoveRange(audienciaContext);
                    _context.SaveChanges();
                    return Ok("Todas as audiências foram excluídas por estar fora do horário.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Deu erro ao excluir as audiências: {ex.Message}");
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult<AudienciaModels>> PostAudiencias(AudienciaModels audiencia)
        {
            TimeSpan horarioAtual = DateTime.Now.TimeOfDay;
            TimeSpan horarioInicial = new TimeSpan(10, 30, 0);// -> MUDAR O HORARIO AO ENTREGAR
            TimeSpan horarioFinal = new TimeSpan(20, 20, 0);

            if (horarioAtual >= horarioInicial && horarioFinal >= horarioAtual)
            {
                _context.Audiencia.Add(audiencia);
                _context.SaveChanges();
                return CreatedAtAction("GetAudiencia", new { id = audiencia.Id }, audiencia);
            }
            else
            {
                return BadRequest("Audiência não pode ser agendada antes das 15:30 e depois das 20:20");
            }
        }

        [HttpPut]
        public async Task<ActionResult<AudienciaModels>> UpdateAudiencia(int id, AudienciaModels audiencia)
        {
            var user = await _context.Audiencia.FindAsync(id);
            if(user != null)
            {
                user.Nome = audiencia.Nome;
                user.QuantidadeDePessoas = audiencia.QuantidadeDePessoas;
                user.Cidade = audiencia.Cidade;
                user.Uf = audiencia.Uf;
                _context.SaveChanges();
                return Ok(audiencia);
            }
            return BadRequest("O Id digitado está inválido");
        }

        [HttpDelete]
        public async Task<ActionResult<AudienciaModels>> DeleteAll()
        {
           try
            {
                _context.Audiencia.RemoveRange(_context.Audiencia);
                _context.SaveChanges();
                return Ok(new List<AudienciaModels>());
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Deu erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AudienciaModels>> DeleteForId(int id)
        {
            var user = await _context.Audiencia.FindAsync(id);
            if(user != null)
            {
                _context.Audiencia.Remove(user);
                _context.SaveChanges();
                return Ok(user);
            }
            else
            {
                return BadRequest("Infelismente não contem usuário com esse id");
            }
        }
    }
}
