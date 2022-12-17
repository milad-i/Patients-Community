using Microsoft.EntityFrameworkCore;
using PatientsCommunity.Data;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Models;

namespace PatientsCommunity.Services
{
    public class AnswerServices : IAnswer
    {
        private readonly ApplicationDbContext _context;
        public AnswerServices(ApplicationDbContext context)
        {
            _context= context;
        }
        public bool AnswerExist(int id)
        {
            return (_context.tbl_Answers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public void CreateAnswer(AnswerModel answer)
        {
            _context.tbl_Answers.Add(answer);
            _context.SaveChanges();
        }
        public void DeleteAnswer(int id)
        {
            var answer = _context.tbl_Answers.Find(id);
            if (answer != null)
            {
                _context.tbl_Answers.Remove(answer);
                _context.SaveChanges();
            }
        }
        public async Task<List<AnswerModel>> GetAnswers()
        {
            return await _context.tbl_Answers.OrderByDescending(a => a.Id).ToListAsync();
        }
        public async Task<AnswerModel> GetAnswer(int id)
        {
            return await _context.tbl_Answers.FindAsync(id);
        }
        public void UpdateAnswer(int id, AnswerModel answer)
        {
            var findedAnswer = _context.tbl_Answers.Find(id);
            if (findedAnswer != null)
            {
                findedAnswer.Description = answer.Description;
                findedAnswer.UpdateDate = DateTime.Now;
            }
            _context.SaveChanges();
        }
    }
}
