using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
.AddApiVersioning(options =>
{
options.DefaultApiVersion = new ApiVersion(1, 0);
options.AssumeDefaultVersionWhenUnspecified = false;
options.ReportApiVersions = true;
})
.AddMvc()
.AddApiExplorer(options =>
{
options.GroupNameFormat = "'v'VVV";
options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddOpenApi("v1");
builder.Services.AddOpenApi("v2");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
app.MapOpenApi("/openapi/{documentName}.json");


app.MapScalarApiReference(options =>
{
    options.AddDocument("v1", "API Version 1");
    options.AddDocument("v2", "API Version 2");
});


}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
