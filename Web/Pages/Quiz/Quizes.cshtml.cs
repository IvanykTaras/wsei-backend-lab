using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages.Quiz
{
    public class QuizesModel : PageModel
    {
        private readonly IQuizUserService _service;

        public QuizesModel(IQuizUserService service)
        {
            _service = service;
        }


        [BindProperty]
        public List<int> quizes { get; set; }
        public void OnGet()
        {
            quizes = _service.FindAllQuiz().Select( e => e.Id).ToList();
        }
    }
}
 