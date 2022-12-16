using PatientsCommunity.Models;

namespace PatientsCommunity.Interfaces
{
    public interface IAnswer
    {
        public Task<AnswerModel> GetAnswer(int id);
        public Task<List<AnswerModel>> GetAnswers();
        public void CreateAnswer(AnswerModel answer);
        public void UpdateAnswer(int id, AnswerModel answer);
        public void DeleteAnswer(int id);
        public bool AnswerExist(int id);
    }
}
