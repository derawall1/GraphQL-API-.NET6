using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
using CommanderGQL.Extensions;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.GraphQL.Commands;

    var builder = WebApplication.CreateBuilder(args);




// configure servieces section
#region  Configure Services

        builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr"))
            );
        builder.Services.AddScoped<AppDbContext>(p => p.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext());
        builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddType<PlatformType>()
                .AddType<AddPlatformInputType>()
                .AddType<AddPlatformPayloadType>()
                .AddType<CommandType>()
                .AddType<AddCommandInputType>()
                .AddType<AddCommandPayloadType>()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions();



#endregion

    var app = builder.Build();
    IConfiguration config = app.Configuration;
    IWebHostEnvironment env = app.Environment;
    // configure midelwares e.g. configure section
#region  Configure 
        app.ApplyMigrations();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseWebSockets();

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
// database migrations

    app.Run();
