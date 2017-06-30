namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BdInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ListaDeProdutoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Categoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.ProdutoListaDeProdutoes",
                c => new
                    {
                        Produto_id = c.Int(nullable: false),
                        ListaDeProduto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_id, t.ListaDeProduto_Id })
                .ForeignKey("dbo.Produtoes", t => t.Produto_id, cascadeDelete: true)
                .ForeignKey("dbo.ListaDeProdutoes", t => t.ListaDeProduto_Id, cascadeDelete: true)
                .Index(t => t.Produto_id)
                .Index(t => t.ListaDeProduto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoListaDeProdutoes", "ListaDeProduto_Id", "dbo.ListaDeProdutoes");
            DropForeignKey("dbo.ProdutoListaDeProdutoes", "Produto_id", "dbo.Produtoes");
            DropForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.ProdutoListaDeProdutoes", new[] { "ListaDeProduto_Id" });
            DropIndex("dbo.ProdutoListaDeProdutoes", new[] { "Produto_id" });
            DropIndex("dbo.Produtoes", new[] { "Categoria_Id" });
            DropTable("dbo.ProdutoListaDeProdutoes");
            DropTable("dbo.Produtoes");
            DropTable("dbo.ListaDeProdutoes");
            DropTable("dbo.Categorias");
        }
    }
}
