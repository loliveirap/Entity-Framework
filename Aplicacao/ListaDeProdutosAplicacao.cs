using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Repositorio;
using Dominio;

namespace Aplicacao
{
    public class ListaDeProdutosAplicacao
    {
        public DBProduto banco { get; set; }
        public ListaDeProdutosAplicacao()
        {
            banco = new DBProduto();
        }

        public void Salvar(ListaDeProduto listaDeProduto)
        {
            listaDeProduto.Produtos = 
                listaDeProduto.Produtos.Select(produto => banco.Produtos.FirstOrDefault(x => x.id == produto.id)).ToList();
            banco.ListaDeProdutos.Add(listaDeProduto);
            banco.SaveChanges();
        }
        public IEnumerable<ListaDeProduto> Listar()
        {
            return banco.ListaDeProdutos
                .Include(x => x.Produtos)
                .Include(x => x.Produtos.Select(categoria => categoria.Categoria))
                .ToList();
        }
        public void Alterar(ListaDeProduto listaDeProduto)
        {
            ListaDeProduto listaSalvar = banco.ListaDeProdutos.Where(x => x.Id == listaDeProduto.Id).First();
            listaSalvar.Produtos =
                listaDeProduto.Produtos.Select(produto => banco.Produtos.FirstOrDefault(x => x.id == produto.id)).ToList();
            listaSalvar.Descricao = listaDeProduto.Descricao;
            banco.SaveChanges();
        }
        public void Excluir(int Id)
        {
            ListaDeProduto listaExcluir = banco.ListaDeProdutos.Where(x => x.Id == Id).First();
            banco.ListaDeProdutos.Remove(listaExcluir);
            banco.SaveChanges();
        }
    }
}
