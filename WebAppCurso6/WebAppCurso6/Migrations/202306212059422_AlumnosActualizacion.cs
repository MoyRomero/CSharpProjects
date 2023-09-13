namespace WebAppCurso6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlumnosActualizacion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alumnos", "Nombre", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Alumnos", "ApPaterno", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Alumnos", "ApMaterno", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Alumnos", "TelefonoPadre", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Alumnos", "TelefonoMadre", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alumnos", "TelefonoMadre", c => c.String());
            AlterColumn("dbo.Alumnos", "TelefonoPadre", c => c.String());
            AlterColumn("dbo.Alumnos", "ApMaterno", c => c.String());
            AlterColumn("dbo.Alumnos", "ApPaterno", c => c.String());
            AlterColumn("dbo.Alumnos", "Nombre", c => c.String());
        }
    }
}
