using System.ComponentModel.DataAnnotations.Schema;

namespace PatientsCommunity.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public Guid CreatorId { get; set; }
        public Guid QuestionId { get; set; }
        public required string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [ForeignKey("QuestionId")]
        public virtual QuestionModel? Question{ get; set; }
    }
}
