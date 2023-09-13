namespace WebAppCurso6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlumnoFotoArregloBytes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alumnos", "FotoBytes", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alumnos", "FotoBytes", c => c.Byte(nullable: false));
        }
    }
}
