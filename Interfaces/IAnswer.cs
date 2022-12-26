using PatientsCommunity.Models;

namespace PatientsCommunity.Interfaces
{
    public interface IAnswer
    {
        Task<AnswerModel> GetAnswer(int id);
        Task<List<AnswerModel>> GetAnswers();
        void CreateAnswer(AnswerModel answer);
        void UpdateAnswer(int id, AnswerModel answer);
        void DeleteAnswer(int id);
        bool AnswerExist(int id);
    }
}
