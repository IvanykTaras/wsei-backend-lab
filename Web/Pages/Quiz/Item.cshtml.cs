using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BackendLab01.Pages
{
    
    public class QuizModel : PageModel
    {
        private readonly IQuizUserService _userService;

        private readonly ILogger _logger;
        
        public QuizModel(IQuizUserService userService, ILogger<QuizModel> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [BindProperty]
        public string Question { get; set; }
        [BindProperty]
        public List<string> Answers { get; set; }
        
        [BindProperty]
        public String UserAnswer { get; set; }
        
        [BindProperty]
        public int QuizId { get; set; }
        
        [BindProperty]
        public int ItemId { get; set; }
       
        
        public IActionResult RedirectSummary() => RedirectToPage("Summary");
      
        public void OnGet(int quizId, int itemId)
        {
/*
            QuizId = quizId;
            ItemId = itemId;*/
            var quiz = _userService.FindQuizById(quizId);

            if (quiz is not null)
            {
                if (quiz.Items.Count >= ItemId)
                {
                    var quizItem = quiz.Items[itemId - 1];
                    Question = quizItem.Question;
                    Answers = new List<string>();
                    
                    if (quizItem is not null)
                    {
                        Answers.AddRange(quizItem?.IncorrectAnswers);
                        Answers.Add(quizItem?.CorrectAnswer);
                    }



                }
                
            }
            
        }

        public IActionResult OnPost()
        {
            _userService.SaveUserAnswerForQuiz(QuizId,0, ItemId,UserAnswer);

            if (ItemId >= _userService.FindQuizById(QuizId).Items.Count) return RedirectToPage("Summary", new { quizId = QuizId, userId = 0});
            return RedirectToPage("Item", new {quizId = QuizId, itemId = ItemId + 1});
        }

    }
}
