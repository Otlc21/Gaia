using Admin.Models;
using Dominio.Servico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin.Controllers
{
    [Authorize]
    public class LocalizacaoController : Controller
    {

        private readonly ILocalizacaoServico _servico;
        public LocalizacaoController(ILocalizacaoServico servico)
        {
            _servico = servico;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get(LocalizacaoViewModel item)
        {
            var itens = await _servico.Get(item.Convert(), item.Skip, item.Take);
            return Ok(itens);
        }

        public IActionResult Insert()
        {
            return View(new LocalizacaoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] LocalizacaoViewModel item)
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

            return View(new LocalizacaoViewModel(item));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LocalizacaoViewModel item)
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
