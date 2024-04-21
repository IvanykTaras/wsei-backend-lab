using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace WebAPI.Dto
{
    public class QuizItemDto: IIdentity<int>
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }


        public QuizItemDto(int id, string quistion, List<string> options) { 
            this.Id = id;
            this.Question = quistion;   
            this.Options = options; 
        }

        public static QuizItemDto of(QuizItem quiz)
        {
            var options = new List<string>(quiz.IncorrectAnswers);
            options.Add(quiz.CorrectAnswer);

            return new QuizItemDto(
                    quiz.Id,
                    quiz.Question,
                    options
                ); ;
        }
    }

    
}
