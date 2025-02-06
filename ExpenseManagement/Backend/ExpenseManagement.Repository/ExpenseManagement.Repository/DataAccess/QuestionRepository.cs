using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel.Context;
using ExpenseManagement.Repository.Model.EntityModel;

namespace ExpenseManagement.Repository.DataAccess
{
    internal class QuestionRepository
    {
        internal List<Question> GetAllQuestions()
        {
            try
            {
                List<Question> questions = new();
                using var context = new ExpenseManagementContext();
                questions = context.Questions.ToList<Question>();

                return questions;
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal Question GetQuestionById(short id)
        {
            try
            {
                Question question = new();
                using var context = new ExpenseManagementContext();
                question = context.Questions.First(u => u.Id == id);

                return question;
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal bool AddQuestion(QuestionModel questionModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingQuestion = context.Questions.First(u => u.Questions == questionModel.Questions);
                if (existingQuestion == null)
                {

                    Question question = new()
                    {
                        Questions = questionModel.Questions
                    };

                    context.Questions.Add(question);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        internal bool EditQuestion(QuestionModel questionModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingQuestion = context.Questions.First(u => u.Id == questionModel.Id);
                if (existingQuestion != null)
                {
                    existingQuestion.Questions = questionModel.Questions;
                   
                    context.Questions.Update(existingQuestion);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        internal bool DeleteQuestion(short id)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingQuestion = context.Questions.First(u => u.Id == id);
                if (existingQuestion != null)
                {
                    context.Questions.Remove(existingQuestion);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}