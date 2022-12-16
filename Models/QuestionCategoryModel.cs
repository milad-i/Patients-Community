using System.ComponentModel.DataAnnotations.Schema;

namespace PatientsCommunity.Models
{
    public class QuestionCategoryModel
    {
        public int Id { get; set; }
        public Guid QuestionId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual QuestionModel? Question { get; set; }
    }
}
