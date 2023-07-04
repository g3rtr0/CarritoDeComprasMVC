namespace CarritoDeCompras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Producto", "VentaModels_Id", c => c.Int());
            CreateIndex("dbo.Producto", "VentaModels_Id");
            AddForeignKey("dbo.Producto", "VentaModels_Id", "dbo.Venta", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "VentaModels_Id", "dbo.Venta");
            DropIndex("dbo.Producto", new[] { "VentaModels_Id" });
            DropColumn("dbo.Producto", "VentaModels_Id");
        }
    }
}
