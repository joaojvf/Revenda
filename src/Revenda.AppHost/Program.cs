var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Revenda_UI>("revenda-ui");

builder.Build().Run();
