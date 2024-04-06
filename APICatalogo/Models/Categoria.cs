using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Models;

public class Categoria
{
    public Categoria()
    {
        produtos = new List<Produto>(); 
    }

    [Key]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    public ICollection<Produto>? produtos { get; set; }
}
