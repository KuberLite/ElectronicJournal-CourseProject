namespace electronic_journal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Guid(nullable: false),
                        FacultyName = c.String(),
                    })
                .PrimaryKey(t => t.FacultyId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Guid(nullable: false),
                        NumberGroup = c.Int(nullable: false),
                        FacultyId = c.Guid(nullable: false),
                        ProfessionId = c.Guid(nullable: false),
                        Course = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .ForeignKey("dbo.Professions", t => t.ProfessionId, cascadeDelete: true)
                .Index(t => t.FacultyId)
                .Index(t => t.ProfessionId);
            
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        ProfessionId = c.Guid(nullable: false),
                        FacultyId = c.Guid(nullable: false),
                        ProfessionName = c.String(),
                        Qualification = c.String(),
                    })
                .PrimaryKey(t => t.ProfessionId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: false)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Guid(nullable: false),
                        PersonName = c.String(),
                        Gender = c.String(),
                        PulpitId = c.Guid(nullable: false),
                        GroupId = c.Guid(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Photo = c.Binary(storeType: "image"),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Pulpits", t => t.PulpitId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.PulpitId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Pulpits",
                c => new
                    {
                        PulpitId = c.Guid(nullable: false),
                        PulpitName = c.String(),
                        FacultyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PulpitId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: false)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        PasswordHash = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Guid(nullable: false),
                        SubjectName = c.String(),
                        PulpitId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Pulpits", t => t.PulpitId, cascadeDelete: true)
                .Index(t => t.PulpitId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Subjects", "PulpitId", "dbo.Pulpits");
            DropForeignKey("dbo.People", "PersonId", "dbo.Users");
            DropForeignKey("dbo.People", "PulpitId", "dbo.Pulpits");
            DropForeignKey("dbo.Pulpits", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.People", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "ProfessionId", "dbo.Professions");
            DropForeignKey("dbo.Professions", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Groups", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Subjects", new[] { "PulpitId" });
            DropIndex("dbo.Pulpits", new[] { "FacultyId" });
            DropIndex("dbo.People", new[] { "GroupId" });
            DropIndex("dbo.People", new[] { "PulpitId" });
            DropIndex("dbo.People", new[] { "PersonId" });
            DropIndex("dbo.Professions", new[] { "FacultyId" });
            DropIndex("dbo.Groups", new[] { "ProfessionId" });
            DropIndex("dbo.Groups", new[] { "FacultyId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Subjects");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Pulpits");
            DropTable("dbo.People");
            DropTable("dbo.Professions");
            DropTable("dbo.Groups");
            DropTable("dbo.Faculties");
        }
    }
}
