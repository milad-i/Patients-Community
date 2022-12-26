using PatientsCommunity.Models;
using Microsoft.AspNetCore.Identity;

namespace PatientsCommunity.Interfaces
{
    public interface IAdmin
    {
        #region Answers

        Task<List<AnswerModel>> GetAnswers();
        Task<AnswerModel> GetAnswer(int id);
        #endregion

        #region Questions
        Task<List<QuestionModel>> GetQuestions();
        Task<QuestionModel> GetQuestion(Guid id);
        #endregion

        #region Users
        Task<IdentityUser> GetUserById(Guid id);
        #endregion
    }
}
