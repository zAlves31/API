
var builder = WebApplication.CreateBuilder(args);

// Adiciona o servico de Controller
builder.Services.AddControllers();

var app = builder.Build();

//Adiciona mapeamento dos Controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
