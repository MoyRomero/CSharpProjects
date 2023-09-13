namespace WebAppCurso6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Periodos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Periodos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Bhabilitado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Periodos");
        }
    }
}
