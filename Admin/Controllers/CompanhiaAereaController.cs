using Admin.Models;
using Dominio.Servico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin.Controllers
{
    [Authorize]
    public class CompanhiaAereaController : Controller
    {

        private readonly ICompanhiaAereaServico _servico;
        public CompanhiaAereaController(ICompanhiaAereaServico servico)
        {
            _servico = servico;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get(CompanhiaAereaViewModel item)
        {
            item.Itens = await _servico.Get(item.Convert(), item.Skip, item.Take);
            return Ok(item);
        }

        public IActionResult Insert()
        {
            return View(new CompanhiaAereaViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CompanhiaAereaViewModel item)
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

            return View(new CompanhiaAereaViewModel(item));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CompanhiaAereaViewModel item)
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
