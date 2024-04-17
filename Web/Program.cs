using ApplicationCore.Interfaces.Repository;
using BackendLab01;
using Infrastructure.Memory;
using Infrastructure.Memory.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IGenericRepository<Quiz, int>>(
        new MemoryGenericRepository<Quiz, int>(new IntGenerator())
    );
builder.Services.AddSingleton<IGenericRepository<QuizItem, int>>(
        new MemoryGenericRepository<QuizItem,int>(new IntGenerator())
    );
builder.Services.AddSingleton<IGenericRepository<QuizItemUserAnswer, string>>(
        new MemoryGenericRepository<QuizItemUserAnswer, string>()
    );
builder.Services.AddSingleton<IQuizUserService,QuizUserService>();


builder.Services.AddRazorPages();


var app = builder.Build();

;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.Seed();
app.Run();