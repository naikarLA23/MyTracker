using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.SettingsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(ILogger<QuestionController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllQuestions")]
        public Task GetAllQuestions()
        {
            QuestionService questionService = new();
            questionService.GetAllQuestions();
            return Task.CompletedTask;
        }

        [HttpGet("GetQuestionById")]
        public Task GetQuestionById(short userId)
        {
            QuestionService questionService = new();
            questionService.GetQuestionById(userId);
            return Task.CompletedTask;
        }

        [HttpPost("AddQuestion")]
        public Task AddQuestion(QuestionModel questionModel)
        {
            QuestionService questionService = new();
            questionService.AddQuestion(questionModel);
            return Task.CompletedTask;
        }

        [HttpPost("EditEmailSetting")]
        public Task EditQuestion(QuestionModel questionModel)
        {
            QuestionService questionService = new();
            questionService.EditQuestion(questionModel);
            return Task.CompletedTask;
        }

        [HttpDelete("DeleteQuestion")]
        public Task DeleteQuestion(short userId)
        {
            QuestionService questionService = new();
            questionService.DeleteQuestion(userId);
            return Task.CompletedTask;
        }
    }
}