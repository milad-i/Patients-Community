using PatientsCommunity.Models;

namespace PatientsCommunity.Interfaces
{
    public interface IQuestion
    { 
        public Task<QuestionModel> GetQuestion(Guid id);
        public Task<List<QuestionModel>> GetQuestions();
        public void CreateQuestion(QuestionModel Question, List<int> categoryIds);
        public void UpdateQuestion(Guid id, QuestionModel Question, List<int> categoryIds);
        public void DeleteQuestion(Guid id);
        public bool QuestionExist(Guid id);
    }
}
