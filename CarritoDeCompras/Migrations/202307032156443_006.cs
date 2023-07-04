namespace CarritoDeCompras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Venta", "producto_Id", "dbo.Producto");
            DropIndex("dbo.Venta", new[] { "producto_Id" });
            AddColumn("dbo.Venta", "Folio", c => c.String());
            DropColumn("dbo.Venta", "Codigo");
            DropColumn("dbo.Venta", "Subtotal");
            DropColumn("dbo.Venta", "producto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venta", "producto_Id", c => c.Int());
            AddColumn("dbo.Venta", "Subtotal", c => c.Single(nullable: false));
            AddColumn("dbo.Venta", "Codigo", c => c.String());
            DropColumn("dbo.Venta", "Folio");
            CreateIndex("dbo.Venta", "producto_Id");
            AddForeignKey("dbo.Venta", "producto_Id", "dbo.Producto", "Id");
        }
    }
}
