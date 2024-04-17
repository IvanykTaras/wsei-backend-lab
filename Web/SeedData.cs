using ApplicationCore.Interfaces.Repository;
using BackendLab01;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();

            
            quizItemRepo.Add(new QuizItem(
                    0,
                    "Some question1",
                    new List<string>()
                    {
                        "Some incorrect answer",
                        "Some incorrect answer",
                        "Some incorrect answer",
                    },
                    "Correct answer"
                ));
            quizItemRepo.Add(new QuizItem(
                    1,
                    "Some question2",
                    new List<string>()
                    {
                        "Some incorrect answer",
                        "Some incorrect answer",
                        "Some incorrect answer",
                    },
                    "Correct answer"
                ));
            quizItemRepo.Add(new QuizItem(
                    2,
                    "Some question3",
                    new List<string>()
                    {
                        "Some incorrect answer",
                        "Some incorrect answer",
                        "Some incorrect answer",
                    },
                    "Correct answer"
                ));
            quizItemRepo.Add(new QuizItem(
                    3,
                    "Some question4",
                    new List<string>()
                    {
                        "Some incorrect answer",
                        "Some incorrect answer",
                        "Some incorrect answer",
                    },
                    "Correct answer"
                ));

            quizRepo.Add(new Quiz(
                    0,
                    quizItemRepo.FindAll(),
                    "Some Title"
                ));

            quizRepo.Add(new Quiz(
                    1,
                    quizItemRepo.FindAll(),
                    "Some Title"
                ));

        }
    }
}