using CadastroNumeros.Implementations;
using CadastroNumeros.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IContatoCadastro, ContatoCadastro>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
