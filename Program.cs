using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
var builder = WebApplication.CreateBuilder(args);




// configure servieces section
#region  Configure Services

builder.Services.AddPooledDbContextFactory<AppDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr"))
    );
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

#endregion

var app = builder.Build();
IConfiguration config = app.Configuration;
IWebHostEnvironment env = app.Environment;
// configure midelwares e.g. configure section
#region  Configure 

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, "/graphql-voyager");

#endregion
app.Run();
