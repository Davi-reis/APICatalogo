namespace APICatalogo.Models;

public class Categoria
{
    public Categoria()
    {
        produtos = new List<Produto>(); 
    }

    public int CategoriaId { get; set; }

    public string? Nome { get; set; }

    public string? ImageUrl { get; set; }

    public ICollection<Produto>? produtos { get; set; }
}
