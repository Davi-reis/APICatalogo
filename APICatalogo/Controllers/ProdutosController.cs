using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> get()
        {
            var produtos = _context.produtos.ToList();

            if (produtos is null)
            {
                return NotFound("Produtos não encontrados...");
            }

            return produtos;
        }

        [HttpGet(("id:int"), Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produtos = _context.produtos.FirstOrDefault(p=> p.ProdutoId == id);

            if (produtos is null)
            {
                return NotFound("Produto não encontrado ....");
            }

            return produtos;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {
                return BadRequest("Dados inválidos...");
            }

            _context.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("id:int")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("id:int")]
        public ActionResult Delete(int id)
        {
            var produto = _context.produtos.FirstOrDefault(p=> p.ProdutoId == id);

            if (produto is null)
            {
                return NotFound("Produto não localizado.....");
            }

            _context.produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

    }
}
