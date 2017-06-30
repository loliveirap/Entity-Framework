using Aplicacao;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var appCategoria = new CategoriaAplicacao();

            //Categoria
            //var objCategoria = new Categoria
            //{
            //    Descricao = "Enlatados"
            //};
            //appCategoria.Salvar(objCategoria);

            //var listaDeCategorias = appCategoria.Listar();

            //foreach (var listaDeCategoria in listaDeCategorias)
            //{
            //    Console.WriteLine("{0}", listaDeCategoria.Descricao);
            //}

            //Produto
            var appProduto = new ProdutoAplicacao();
            //var objProduto = new Produto
            //{
            //    Nome = "Sardinha",
            //    Categoria = appCategoria.Listar().FirstOrDefault()
            //};
            //appProduto.Salvar(objProduto);
            //var listaProdutos = appProduto.Listar();

            //foreach (var listaDeProduto in listaProdutos)
            //{
            //    Console.WriteLine("{0} - {1}", listaDeProduto.Nome, listaDeProduto.Categoria.Descricao);
            //}

            //Lista de Produtos

            var appLista = new ListaDeProdutosAplicacao();

            var objListaProdutos = new ListaDeProduto
            {
                Descricao = "Lista de Compras do Leandro"
            };


            var produto1 = appProduto.Listar().FirstOrDefault();
            objListaProdutos.Produtos = new List<Produto> { produto1 };

            objListaProdutos.Produtos.Add(produto1);
            appLista.Salvar(objListaProdutos);

            var listas = appLista.Listar();
            foreach (var lista in listas)
            {
                Console.WriteLine("{0}", lista.Descricao);
                foreach (var produto in lista.Produtos)
                {
                    Console.WriteLine("     {0} - {1}", produto.Nome, produto.Categoria.Descricao);
                }
            }

            //ListaDeProdutosAplicacao appLista = new ListaDeProdutosAplicacao();
            //ProdutoAplicacao appProduto = new ProdutoAplicacao();

            //var lista01 = new ListaDeProduto();
            //lista01.Descricao = "Cesta Basica";
            //lista01.Produtos = appProduto.Listar().Where(x=> x.Categoria.Id == 2).ToList();

            //appLista.Salvar(lista01);

            //var listas = appLista.Listar();
            //foreach (var lista in listas)
            //{
            //    Console.WriteLine("{0} - {1}", lista.Id, lista.Descricao);
            //    foreach (var produto in lista.Produtos)
            //    {
            //        Console.WriteLine("     {0} - {1}", produto.id, produto.Nome);
            //    }
            //}

            //CategoriaAplicacao appCategoria = new CategoriaAplicacao();

            //Categoria cat01 = new Categoria();
            //cat01.Id = 1;
            //cat01.Descricao = "Enlatados Grandes";

            ////appCategoria.Salvar(cat01);
            //appCategoria.Alterar(cat01);

            //ProdutoAplicacao appProduto = new ProdutoAplicacao();
            //Produto prod01 = new Produto();

            //prod01.Nome = "Açucar";
            //prod01.Categoria = appCategoria.Listar().Where(x => x.Id == 3).FirstOrDefault();

            ////appProduto.Salvar(prod01);
            ////appProduto.Alterar(prod01);
            ////appProduto.Excluir(prod01.id);

            //Console.WriteLine("Listagem de Produtos");

            //var listaDeProdutos = appProduto.Listar();

            //foreach (var produto in appProduto.Listar())
            //{
            //    Console.WriteLine("{0} - {1} - {2}", produto.id, produto.Nome, produto.Categoria.Descricao);
            //}

            //Console.WriteLine("Listagem de Categorias");
            //var listaDeCategorias = appCategoria.Listar();
            //foreach (var categoria in appCategoria.Listar())
            //{
            //    Console.WriteLine("{0} - {1}", categoria.Id, categoria.Descricao);
            //}                    

            //Produto produto01 = new Produto();
            ////produto01.id = 2;         
            //produto01.Nome = "Feijão";
            ////produto01.Categoria = "Alimentos";

            //app.Salvar(produto01);
            ////app.Alterar(produto01);
            ////app.Excluir(produto01.id);

            //foreach( var produtoNaLista in app.Listar())
            //{
            //    Console.WriteLine("{0} - {1} - {2}", produtoNaLista.id, produtoNaLista.Nome, produtoNaLista.Categoria);
            //}
            Console.ReadKey();
        }
    }
}

//Habilitar o Migration -> Enable-Migrations

//Add-Migration "BdInicial" -> Criar o Migration com os códigos que ira para o banco ser criado
//Update-Database -script -> Cria o script para gerar o banco - Neste caso ele não cria o banco
//Update-Database -verbose -> Cria o banco e mostra o que esta acontecendo
//Install-Package entityframework -> Comando utilizado para instalar pacotes do Nuget

/*Add-Migration AdicionadoListaDeProdutos -> Após realizar as alterações nas tabelas, 
    executar o comando para criar o Migration + o nome da migração */

//Update-Database -> Comando utilizado após a criação do Migration, neste comando o banco e as alterações serão criados de fato.
//Update-Database -force -> Para Criar o Banco e as Tabelas