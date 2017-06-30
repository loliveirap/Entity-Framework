using Dominio;
using Repositorio;
using System.Collections.Generic;
using System.Linq;
//Teste
namespace Aplicacao
{
    public class CategoriaAplicacao
    {
        public DBProduto banco { get; set; }
        public CategoriaAplicacao()
        {
            banco = new DBProduto();
        }
        public void Salvar(Categoria categoria)
        {
            banco.Categorias.Add(categoria);
            banco.SaveChanges();
        }
        public IEnumerable<Categoria> Listar()
        {
            return banco.Categorias.ToList();
        }
        public void Alterar(Categoria categoria)
        {
            Categoria categoriaSalvar = banco.Categorias.Where(x => x.Id == categoria.Id).First();
            categoriaSalvar.Descricao = categoria.Descricao;
            banco.SaveChanges();
        }
        public void Excluir(int id)
        {
            Categoria categoriaExcluir = banco.Categorias.Where(x => x.Id == id).First();
            banco.Categorias.Remove(categoriaExcluir);
            banco.SaveChanges();
        }
    }
}
