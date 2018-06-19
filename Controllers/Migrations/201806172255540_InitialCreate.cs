namespace Controllers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Email = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        Cpf = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Comandas",
                c => new
                    {
                        ComandaID = c.Int(nullable: false, identity: true),
                        Total = c.Single(nullable: false),
                        ComandaStatusID = c.Int(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        FuncionarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComandaID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.ComandaStatus", t => t.ComandaStatusID, cascadeDelete: true)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioID, cascadeDelete: true)
                .Index(t => t.ComandaStatusID)
                .Index(t => t.ClienteID)
                .Index(t => t.FuncionarioID);
            
            CreateTable(
                "dbo.ComandaStatus",
                c => new
                    {
                        ComandaStatusID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.ComandaStatusID);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        FuncionarioID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        Cpf = c.Long(nullable: false),
                        Administrador = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FuncionarioID);
            
            CreateTable(
                "dbo.ComandaItems",
                c => new
                    {
                        ComandaItemID = c.Int(nullable: false, identity: true),
                        ComandaID = c.Int(nullable: false),
                        ServicoID = c.Int(nullable: false),
                        PacoteID = c.Int(nullable: false),
                        Valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComandaItemID)
                .ForeignKey("dbo.Comandas", t => t.ComandaID, cascadeDelete: true)
                .ForeignKey("dbo.Pacotes", t => t.PacoteID, cascadeDelete: true)
                .ForeignKey("dbo.Servicoes", t => t.ServicoID, cascadeDelete: true)
                .Index(t => t.ComandaID)
                .Index(t => t.ServicoID)
                .Index(t => t.PacoteID);
            
            CreateTable(
                "dbo.Pacotes",
                c => new
                    {
                        PacoteID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Codigo = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PacoteID);
            
            CreateTable(
                "dbo.Servicoes",
                c => new
                    {
                        ServicoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Codigo = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        Valor = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ServicoID);
            
            CreateTable(
                "dbo.PacoteServicoes",
                c => new
                    {
                        PacoteServicoID = c.Int(nullable: false, identity: true),
                        ServicoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PacoteServicoID)
                .ForeignKey("dbo.Servicoes", t => t.ServicoID, cascadeDelete: true)
                .Index(t => t.ServicoID);
            
            CreateTable(
                "dbo.Vagas",
                c => new
                    {
                        VagaID = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Andar = c.Int(nullable: false),
                        Ocupada = c.Boolean(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        VagaTipoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VagaID)
                .ForeignKey("dbo.VagaTipoes", t => t.VagaTipoID, cascadeDelete: true)
                .Index(t => t.VagaTipoID);
            
            CreateTable(
                "dbo.VagaTipoes",
                c => new
                    {
                        VagaTipoID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.VagaTipoID);
            
            CreateTable(
                "dbo.Veiculoes",
                c => new
                    {
                        VeiculoID = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        VeiculoTipoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VeiculoID)
                .ForeignKey("dbo.VeiculoTipoes", t => t.VeiculoTipoID, cascadeDelete: true)
                .Index(t => t.VeiculoTipoID);
            
            CreateTable(
                "dbo.VeiculoTipoes",
                c => new
                    {
                        VeiculoTipoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Rodas = c.Int(nullable: false),
                        Eixos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VeiculoTipoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veiculoes", "VeiculoTipoID", "dbo.VeiculoTipoes");
            DropForeignKey("dbo.Vagas", "VagaTipoID", "dbo.VagaTipoes");
            DropForeignKey("dbo.PacoteServicoes", "ServicoID", "dbo.Servicoes");
            DropForeignKey("dbo.ComandaItems", "ServicoID", "dbo.Servicoes");
            DropForeignKey("dbo.ComandaItems", "PacoteID", "dbo.Pacotes");
            DropForeignKey("dbo.ComandaItems", "ComandaID", "dbo.Comandas");
            DropForeignKey("dbo.Comandas", "FuncionarioID", "dbo.Funcionarios");
            DropForeignKey("dbo.Comandas", "ComandaStatusID", "dbo.ComandaStatus");
            DropForeignKey("dbo.Comandas", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Veiculoes", new[] { "VeiculoTipoID" });
            DropIndex("dbo.Vagas", new[] { "VagaTipoID" });
            DropIndex("dbo.PacoteServicoes", new[] { "ServicoID" });
            DropIndex("dbo.ComandaItems", new[] { "PacoteID" });
            DropIndex("dbo.ComandaItems", new[] { "ServicoID" });
            DropIndex("dbo.ComandaItems", new[] { "ComandaID" });
            DropIndex("dbo.Comandas", new[] { "FuncionarioID" });
            DropIndex("dbo.Comandas", new[] { "ClienteID" });
            DropIndex("dbo.Comandas", new[] { "ComandaStatusID" });
            DropTable("dbo.VeiculoTipoes");
            DropTable("dbo.Veiculoes");
            DropTable("dbo.VagaTipoes");
            DropTable("dbo.Vagas");
            DropTable("dbo.PacoteServicoes");
            DropTable("dbo.Servicoes");
            DropTable("dbo.Pacotes");
            DropTable("dbo.ComandaItems");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.ComandaStatus");
            DropTable("dbo.Comandas");
            DropTable("dbo.Clientes");
        }
    }
}
