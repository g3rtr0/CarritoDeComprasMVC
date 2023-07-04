namespace CarritoDeCompras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _004 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venta", "Usuario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venta", "Usuario");
        }
    }
}
