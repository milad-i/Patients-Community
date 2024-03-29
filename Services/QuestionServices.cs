﻿using Microsoft.EntityFrameworkCore;
using PatientsCommunity.Data;
using PatientsCommunity.Interfaces;
using PatientsCommunity.Models;
using System.Diagnostics.CodeAnalysis;

namespace PatientsCommunity.Services
{
    public class QuestionServices : IQuestion
    {
        private readonly ApplicationDbContext _context;
        public QuestionServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool QuestionExist(Guid id)
        {
            return (_context.tbl_Question?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public void CreateQuestion(QuestionModel question, List<int> categoryIds)
        {
            //Create Question
            //---------------------------------------------------------------------------------------------
            question.Id = Guid.NewGuid();
            _context.tbl_Question.Add(question);

            //Create Question's Categories
            //------------------------------------------------------------------------------------------
            List<QuestionCategoryModel> questionCategories = new List<QuestionCategoryModel>();
            foreach (var item in categoryIds)
            {
                questionCategories.Add(new QuestionCategoryModel
                {
                    CategoryId = item,
                    QuestionId = question.Id
                });
            }
            _context.tbl_QuestionCategory.AddRange(questionCategories);


            //Save to database
            //-------------------------------------------------------------------------------------------
            _context.SaveChanges();
        }
        public void DeleteQuestion(Guid id)
        {
            var question = _context.tbl_Question.Find(id);
            if (question != null)
            {
                _context.tbl_Question.Remove(question);
                _context.SaveChanges();
            }
        }
        public async Task<List<QuestionModel>> GetQuestions()
        {
            var result = await _context.tbl_Question.Include(q => q.Answers).Include(q => q.QuestionCategories).OrderByDescending(q => q.Id).ToListAsync();
            return result;
        }
        public async Task<List<QuestionModel>> GetQuestionsByCategory(int catId)
        {
            return await  _context.tbl_QuestionCategory.Include(q => q.Question).Where(q => q.CategoryId == catId).Select(q => q.Question).ToListAsync();
        }
        public async Task<QuestionModel> GetQuestion(Guid id)
        {
            return await _context.tbl_Question.Include(q => q.Answers).FirstOrDefaultAsync(q => q.Id == id);
        }
        public void UpdateQuestion(Guid id, QuestionModel question, List<int> categoryIds)
        {
            //Update Question
            //---------------------------------------------------------------------------------------------
            var findedQuestion = _context.tbl_Question.Find(id);
            if (findedQuestion != null)
            {
                findedQuestion.Description = question.Description;
                findedQuestion.Title = question.Title;
                findedQuestion.UpdateDate = DateTime.Now;
            }

            //Update Question's Categories
            //------------------------------------------------------------------------------------------
            if (categoryIds.Any())
            {
                //Delete all current categories in BD
                var currentCategories = _context.tbl_QuestionCategory.Where(c => c.QuestionId== id).ToList();
                _context.tbl_QuestionCategory.RemoveRange(currentCategories);

                //create new categories
                List<QuestionCategoryModel> questionCategories = new List<QuestionCategoryModel>();
                foreach (var item in categoryIds)
                {
                    questionCategories.Add(new QuestionCategoryModel
                    {
                        CategoryId = item,
                        QuestionId = question.Id
                    });
                }
                _context.tbl_QuestionCategory.AddRange(questionCategories);
            }


            //Save to database
            //-------------------------------------------------------------------------------------------
            _context.SaveChanges();
        }
    }
}
