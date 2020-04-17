
dotnet ef migrations add IdentityInitialCreate --context ApplicationDbContext --output-dir Data/Migrations/Identity
dotnet ef database update --context ApplicationDbContext
dotnet ef migrations remove --context ApplicationDbContext

---------------------------------------------------------------------------------------
dotnet ef migrations add DataAccesInitialCreate --context DataAccesDbContext --output-dir Data/Migrations/DataAcces
dotnet ef database update --context DataAccesDbContext
dotnet ef migrations remove --context DataAccesDbContext
------
add-migration "Migration_Name" -Context "DbContext_Name"

update-database -Context "DbContext_Name"

update-database -TargetMigration:"Migration_Name"


-----
add-migration InitialIdentity -Context ApplicationDbContext

add-migration InitialDataAccess -Context VroomAutoDbContext

update-database -Context ApplicationDbContext

update-database -Context VroomAutoDbContext

---------------

cosmineala@gmail.com
Password12#$
