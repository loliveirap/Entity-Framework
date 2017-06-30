using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Repositorio;
using Dominio;

namespace Aplicacao
{
    public class ProdutoAplicacao
    {
        public DBProduto banco { get; set; }

        public ProdutoAplicacao()
        {
            banco = new DBProduto();
        }

        public void Salvar(Produto produto)
        {
            //Atachar a Categoria para não duplicar
            produto.Categoria = banco.Categorias.ToList().Where(x => x.Id == produto.Categoria.Id).FirstOrDefault();
            banco.Produtos.Add(produto);
            banco.SaveChanges();
        }

        public IEnumerable<Produto> Listar()
        {
            //LazyLoad(Include)
            return banco.Produtos.Include(x=>x.Categoria).ToList();
        }

        public void Alterar(Produto produto)
        {
            Produto produtoSalvar = banco.Produtos.Where(x => x.id == produto.id).First();
            produtoSalvar.Nome = produto.Nome;
            banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            //Produto produtoExcluir = banco.Produtos.Where(x => x.id == id).First();
            //ou
            Produto produtoExcluir = banco.Produtos.First(x => x.id == id);
            banco.Produtos.Remove(produtoExcluir);
            banco.SaveChanges();
        }
    }
}
