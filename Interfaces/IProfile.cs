using PatientsCommunity.Models;

namespace PatientsCommunity.Interfaces
{
    public interface IProfile
    {
        #region Answers

        Task<List<AnswerModel>> GetUserAnswers(Guid userId);
        Task<AnswerModel> GetUserAnswer(int id, Guid userId);
        #endregion

        #region Questions
        Task<List<QuestionModel>> GetUserQuestions(Guid userId);
        Task<QuestionModel> GetUserQuestion(Guid id, Guid userId);
        #endregion
    }
}
