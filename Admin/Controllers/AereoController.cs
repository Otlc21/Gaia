using Admin.Models;
using Dominio.Entidade;
using Dominio.Servico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using System.Diagnostics;

namespace Admin.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AereoController : Controller
    {
        private readonly IAereoServico _servico;
        public AereoController(IAereoServico servico)
        {
            _servico = servico;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get(AereoViewModel item)
        {
            var itens = await _servico.Get(item.Convert(), item.Skip, item.Take);
            return Ok(itens);
        }

        public IActionResult Insert()
        {
            return View(new AereoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] AereoViewModel item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _servico.Insert(item.Convert());
            return CreatedAtAction(nameof(Insert), new { id = item.Id }, item);
        }

        public async Task<IActionResult> Update(int id)
        {
            var item = await _servico.Get(id);
            if (item == null)
                return NotFound();

            return View(new AereoViewModel(item));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AereoViewModel item)
        {
            if (id != item.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            await _servico.Update(item.Convert());
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _servico.Delete(id);
            return NoContent();
        }
    }
}
