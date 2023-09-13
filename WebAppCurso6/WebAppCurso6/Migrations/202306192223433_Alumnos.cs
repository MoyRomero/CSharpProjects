namespace WebAppCurso6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alumnos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ApPaterno = c.String(),
                        ApMaterno = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        SexoId = c.Int(nullable: false),
                        TelefonoPadre = c.String(),
                        TelefonoMadre = c.String(),
                        NumeroHermanos = c.Int(nullable: false),
                        Bhabilitado = c.Boolean(nullable: false),
                        TipoUsuarioId = c.Boolean(nullable: false),
                        bTieneUsuario = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Alumnos");
        }
    }
}
