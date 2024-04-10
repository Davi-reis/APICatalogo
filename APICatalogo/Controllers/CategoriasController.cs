using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos(int id)
        {
            var categoria = _context.categorias.Include(p=>p.produtos).ToList();

            
            return categoria;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> get()
        {
            return _context.categorias.AsNoTracking().ToList();
                       
        }

        [HttpGet("{id:int}", Name ="ObterProduto")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.categorias.FirstOrDefault(p => p.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrado....");
            }

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest("Dados inválidos");
            }

            _context.categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if ( id != categoria.CategoriaId )
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("id:int")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.produtos.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound("Categoria não localizado.....");
            }

            _context.produtos.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }

    }
}
