using System.ComponentModel.DataAnnotations;

namespace Survey.WebUI.Data.Questionnaires
{
    public class QuestionnaireVM
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; } = DateTime.Now;

        [Required]
        public DateTime EndDateTime { get; set; } = DateTime.Now.AddDays(1);
        public string StatusName { get; set; }
        public string NextStatusName { get; set; }
        public bool IsUpdatable { get; set; } = true;
    }
}
