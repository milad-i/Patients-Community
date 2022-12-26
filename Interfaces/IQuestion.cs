using PatientsCommunity.Models;

namespace PatientsCommunity.Interfaces
{
    public interface IQuestion
    { 
        Task<QuestionModel> GetQuestion(Guid id);
        Task<List<QuestionModel>> GetQuestions();
        void CreateQuestion(QuestionModel Question, List<int> categoryIds);
        void UpdateQuestion(Guid id, QuestionModel Question, List<int> categoryIds);
        void DeleteQuestion(Guid id);
        bool QuestionExist(Guid id);
    }
}
