using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages;

public class Summary : PageModel
{
    private readonly IQuizUserService _service;
    private readonly ILogger _logger;

    public Summary(IQuizUserService service, ILogger<Summary> logger)
    {
        _service = service; 
        _logger = logger;
    }

    [BindProperty]
    public int QuizId { get; set; }

    [BindProperty]
    public int UserId { get; set; }

    [BindProperty]
    public int CountOfCorrectAnswers { get; set; }

    public void OnGet(int quizId, int userId)
    {
        CountOfCorrectAnswers = _service.CountCorrectAnswersForQuizFilledByUser(quizId, userId);   
    }
}