namespace CarritoDeCompras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Producto", "CategoriaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producto", "CategoriaId", c => c.Int(nullable: false));
        }
    }
}
