DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.RegisterDbContext();
builder.RegisterAuthentication();
builder.RegisterCors();
builder.RegisterAppServices();
builder.RegisterGraphQLServer();

var app = builder.Build();
app.ExecuteMigrations();
app.UseWebCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapGraphQL();

app.MapGet("/", () => "");

//KUBERNETES
//liveness, readiness and startup probes for containers
app.MapGet("/liveness", () => "Liveness Template");
app.MapGet("/readiness", () => "Readiness Template");

await app.RunAsync();