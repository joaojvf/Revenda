var builder = DistributedApplication.CreateBuilder(args);
var sqlPwd = builder.AddParameter("sql-pwd");
var db1 = builder
    .AddSqlServer("sql-aspire", password: sqlPwd, port: 1433)
    .WithDataVolume()
    .AddDatabase("revendaDb");

var migration = builder
    .AddProject<Projects.Revenda_MigrationService>("revenda-migration-service")
    .WithReference(db1)
    .WaitFor(db1);

builder.AddProject<Projects.Revenda_UI>("revenda-ui-api")
        .WithReference(db1)
        .WaitFor(db1)
        .WithReference(migration); ;

builder.Build().Run();
