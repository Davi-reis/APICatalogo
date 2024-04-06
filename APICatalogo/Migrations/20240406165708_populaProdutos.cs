using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class populaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, Datacadastro, CategoriaId)" +
                "Values('Coca-Cola Diet','Refrigerante  de cola  350 ml','5.45','cocacola.jpg',50,GETDATE(),1)");

            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, Datacadastro, CategoriaId)" +
                "Values('Lanche de atum','Lanche de atum com maionese','8.50','Atum.jpg',10,GETDATE(),2)");

            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, Datacadastro, CategoriaId)" +
                "Values('Pudim 100 g','Pudim de leite condensado  100 ml','6.75','Pudim.jpg',20,GETDATE(),3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
