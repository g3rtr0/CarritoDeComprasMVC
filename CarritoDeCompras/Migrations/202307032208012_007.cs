namespace CarritoDeCompras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _007 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Venta", "Precio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venta", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
