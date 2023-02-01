using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", builder => {
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddApiVersioning();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    string? serviceVersion = typeof(Program).Assembly.GetName().Version?.ToString();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Weather Forcast - Minimal Api",
        Version = "v1",
        Description = $" (current deployed version : {serviceVersion})",
        Contact = new OpenApiContact
        {
            Name = "Pokerface(-__-)",
            Email = "1.2@gmail.com",
        }
    });

    c.ResolveConflictingActions(apiDescription => apiDescription.First());
});


var app = builder.Build();

app.UseCors("CorsPolicy");

// the default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();

app.UseForwardedHeaders();

app.UseSwagger();
app.UseSwaggerUI(cc =>
{
    cc.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseRouting();

app.UseEndpoints(endPoints =>
{
    endPoints.MapGet("/ping", context =>
    {
        context.Response.StatusCode = 200;
        return Task.CompletedTask;
    });
    endPoints.MapControllers();
});


app.Run();
