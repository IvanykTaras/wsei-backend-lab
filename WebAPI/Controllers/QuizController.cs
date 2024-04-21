using BackendLab01;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Dto;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("/api/v1/quizzes")]
    public class QuizController : Controller
    {
        private readonly IQuizUserService _service;


        public QuizController(IQuizUserService service) { 
            _service = service; 
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDto> FindById(int id)
        {
            var quiz = _service.FindQuizById(id);
            if(quiz is not null) return QuizDto.of(quiz);

            return NotFound();
        }

        [HttpGet]
        public IEnumerable<QuizDto> FindAll()
        {
            
            var quizes = _service.FindAllQuizzes().Select( e => QuizDto.of(e));

            return quizes;
            
        }

        [HttpPost]
        [Route("{quizId}/items/{itemId}")]
        public void SaveAnswer([FromBody] QuizItemAnswerDto dto, [FromRoute] int quizId, [FromRoute] int itemId)
        {
            _service.SaveUserAnswerForQuiz(quizId, dto.UserId, itemId, dto.Answer);
        }

        [HttpGet]
        [Route("{quizId}/{userId}")]
        public ActionResult<int> CountCorrectAnswers([FromRoute] int quizId, [FromRoute] int userId)
        {
            return _service.CountCorrectAnswersForQuizFilledByUser(quizId,userId);
        }
    }
}
