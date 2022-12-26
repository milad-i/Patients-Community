using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PatientsCommunity.Data;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Models;

namespace PatientsCommunity.Services
{
    public class AdminService : IAdmin
    {
        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }
        //==============================================================================================
        #region Answers
        public async Task<List<AnswerModel>> GetAnswers()
        {
            return await _context.tbl_Answers.OrderByDescending(a => a.Id).ToListAsync();
        }
        public async Task<AnswerModel> GetAnswer(int id)
        {
            return await _context.tbl_Answers.FindAsync(id);
        }
        #endregion

        #region Questions
        public async Task<List<QuestionModel>> GetQuestions()
        {
            return await _context.tbl_Question.OrderByDescending(q => q.Id).ToListAsync();
        }
        public async Task<QuestionModel> GetQuestion(Guid id)
        {
            return await _context.tbl_Question.Include(q => q.Answers).FirstOrDefaultAsync(a => a.Id == id);
        }
        #endregion

        #region Users
        public async Task<IdentityUser> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
        #endregion
    }
}
