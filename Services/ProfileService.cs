using Microsoft.EntityFrameworkCore;
using PatientsCommunity.Data;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Models;

namespace PatientsCommunity.Services
{
    public class ProfileService : IProfile
    {
        private readonly ApplicationDbContext _context;
        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
        }
        //==============================================================================================
        #region Answers

        public async Task<List<AnswerModel>> GetUserAnswers(Guid userId)
        {
            return await _context.tbl_Answers.Where(a => a.CreatorId == userId).OrderByDescending(a => a.Id).ToListAsync();
        }
        public async Task<AnswerModel> GetUserAnswer(int id, Guid userId)
        {
            return await _context.tbl_Answers.OrderBy(a => a.Id).FirstOrDefaultAsync(a => a.CreatorId == userId && a.Id == id);
        }
        #endregion

        #region Questions
        public async Task<List<QuestionModel>> GetUserQuestions(Guid userId)
        {
            return await _context.tbl_Question.Where(a => a.CreatorId == userId).OrderByDescending(q => q.Id).ToListAsync();
        }
        public async Task<QuestionModel> GetUserQuestion(Guid id, Guid userId)
        {
            return await _context.tbl_Question.Include(q => q.Answers).OrderBy(a => a.Id).FirstOrDefaultAsync(a => a.CreatorId == userId && a.Id == id);
        }
        #endregion
    }
}
