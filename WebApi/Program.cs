using AeC.AutomationChallenge.Application;
using AeC.AutomationChallenge.Infrastructure;
using AeC.AutomationChallenge.Infrastructure.Persistence;
using AeC.AutomationChallenge.Services;
using AeC.AutomationChallenge.WebApi;
using AeC.AutomationChallenge.WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName);
    options.SchemaGeneratorOptions.SchemaIdSelector = type => type.FullName;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();

    var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
    await initializer.InitializeAsync();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapHomePageEndpoints();

app.Run();
