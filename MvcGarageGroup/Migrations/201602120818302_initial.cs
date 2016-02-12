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
                        StopTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ParkedVehicleID);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        VehicleTypeID = c.Int(nullable: false),
                        Color = c.String(),
                        LicencePlate = c.String(),
                    })
                .PrimaryKey(t => t.VehicleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicle");
            DropTable("dbo.ParkedVehicle");
            DropTable("dbo.Owner");
        }
    }
}
