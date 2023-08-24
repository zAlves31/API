
var builder = WebApplication.CreateBuilder(args);

// Adiciona o servico de Controller
builder.Services.AddControllers();

//Adiciona o servico de Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Aqui comeca a config do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Finaliza a config do Swagger
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//Adiciona mapeamento dos Controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
