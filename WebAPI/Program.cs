using ApplicationCore.Interfaces.Repository;
using BackendLab01;
using Infrastructure.Memory;
using Infrastructure.Memory.Repository;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSingleton<IGenericRepository<Quiz, int>>(
        new MemoryGenericRepository<Quiz, int>(new IntGenerator())
    );
builder.Services.AddSingleton<IGenericRepository<QuizItem, int>>(
        new MemoryGenericRepository<QuizItem, int>(new IntGenerator())
    );
builder.Services.AddSingleton<IGenericRepository<QuizItemUserAnswer, string>>(
        new MemoryGenericRepository<QuizItemUserAnswer, string>()
    );
builder.Services.AddSingleton<IQuizUserService, QuizUserService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
app.Seed();
app.Run();
