namespace CarritoDeCompras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Producto", "FechaCreacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producto", "FechaCreacion", c => c.DateTime(nullable: false));
        }
    }
}
