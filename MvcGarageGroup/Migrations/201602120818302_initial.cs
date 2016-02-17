namespace MvcGarageGroup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owner",
                c => new
                    {
                        OwnerID = c.Int(nullable: false, identity: true),
                        SSN = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OwnerID);
            
            CreateTable(
                "dbo.ParkedVehicle",
                c => new
                    {
                        ParkedVehicleID = c.Int(nullable: false, identity: true),
                        VehicleID = c.Int(nullable: false),
                        ParkingSpotID = c.Int(nullable: false),
                        OwnerID = c.Int(nullable: false),
                        Present = c.Boolean(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        StopTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ParkedVehicleID)
                .ForeignKey("dbo.Owner", t => t.OwnerID, cascadeDelete: true)
                .ForeignKey("dbo.Vehicle", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        VehicleTypeID = c.Int(nullable: false),
                        Color = c.String(),
                        LicencePlate = c.String(),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.VehicleType", t => t.VehicleTypeID, cascadeDelete: true)
                .Index(t => t.VehicleTypeID);
            
            CreateTable(
                "dbo.VehicleType",
                c => new
                    {
                        VehicleTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.VehicleTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkedVehicle", "VehicleID", "dbo.Vehicle");
            DropForeignKey("dbo.Vehicle", "VehicleTypeID", "dbo.VehicleType");
            DropForeignKey("dbo.ParkedVehicle", "OwnerID", "dbo.Owner");
            DropIndex("dbo.Vehicle", new[] { "VehicleTypeID" });
            DropIndex("dbo.ParkedVehicle", new[] { "OwnerID" });
            DropIndex("dbo.ParkedVehicle", new[] { "VehicleID" });
            DropTable("dbo.VehicleType");
            DropTable("dbo.Vehicle");
            DropTable("dbo.ParkedVehicle");
            DropTable("dbo.Owner");
        }
    }
}
