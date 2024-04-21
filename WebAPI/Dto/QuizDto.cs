using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace WebAPI.Dto
{
    public class QuizDto: IIdentity<int>
    {

        public int Id { get; set; }

        public string Title { get; }

        public List<QuizItem> Items { get; }


        public QuizDto(int id, List<QuizItem> items, string title)
        {
            Id = id;
            Items = items;
            Title = title;
        }

        public static QuizDto of(Quiz quiz)
        {
            return new QuizDto(quiz.Id,quiz.Items,quiz.Title);
        }
    }
}
