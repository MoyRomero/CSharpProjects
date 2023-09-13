namespace WebAppCurso6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlumnosTipoUsuarioMod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alumnos", "TipoUsuarioId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alumnos", "TipoUsuarioId", c => c.Boolean(nullable: false));
        }
    }
}
