namespace PatientsCommunity.Models
{
    public class QuestionModel
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<AnswerModel>? Answers { get; set; }
        public virtual ICollection<QuestionCategoryModel>? QuestionCategories { get; set; }
    }
}
