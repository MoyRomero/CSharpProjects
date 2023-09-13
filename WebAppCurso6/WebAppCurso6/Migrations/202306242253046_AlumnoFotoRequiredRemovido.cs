namespace WebAppCurso6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlumnoFotoRequiredRemovido : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alumnos", "FotoNombre", c => c.String());
            AlterColumn("dbo.Alumnos", "FotoBytes", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alumnos", "FotoBytes", c => c.Binary(nullable: false));
            AlterColumn("dbo.Alumnos", "FotoNombre", c => c.String(nullable: false));
        }
    }
}
