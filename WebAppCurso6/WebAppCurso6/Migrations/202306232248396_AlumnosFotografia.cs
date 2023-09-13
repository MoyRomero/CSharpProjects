namespace WebAppCurso6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlumnosFotografia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alumnos", "FotoNombre", c => c.String(nullable: false));
            AddColumn("dbo.Alumnos", "FotoBytes", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alumnos", "FotoBytes");
            DropColumn("dbo.Alumnos", "FotoNombre");
        }
    }
}
