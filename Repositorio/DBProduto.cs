using System.Data.Entity;
using Dominio;

namespace Repositorio
{
    public class DBProduto : DbContext
    {
        //Construtor da ConnectionString
        public DBProduto():base(/*Nome do Banco*/)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ListaDeProduto> ListaDeProdutos { get; set; }
    }
}
