using ExpenseManagement.Repository.DataAccess;
using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;

namespace ExpenseManagement.Repository.Service
{
    public class QuestionService
    {
        private readonly QuestionRepository _QuestionRepo;

        public QuestionService()
        {
            _QuestionRepo = new QuestionRepository();
        }

        public List<Question> GetAllQuestions()
        {
            return _QuestionRepo.GetAllQuestions();
        }

        public Question GetQuestionById(short id)
        {
            return _QuestionRepo.GetQuestionById(id);
        }

        public bool AddQuestion(QuestionModel questionModel)
        {
            return _QuestionRepo.AddQuestion(questionModel);
        }

        public bool EditQuestion(QuestionModel questionModel)
        {
            return _QuestionRepo.EditQuestion(questionModel);
        }

        public bool DeleteQuestion(short id)
        {
            return _QuestionRepo.DeleteQuestion(id);
        }
    }
}