using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HealHub.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }

        [DisplayName("Nome Completo")]
        [Required(ErrorMessage = "Campo não pode ser nulo")]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Campo não pode ser nulo")]
        public string Email { get; set; }

        [DisplayName("Comentários")]
        [Required(ErrorMessage = "Campo não pode ser nulo")]
        public string Texto { get; set; }

        [Range(1, 5)]
        [DisplayName("Avaliação")]
        [Required(ErrorMessage = "Campo não pode ser nulo")]
        public float Stars { get; set; }

        public bool Authorized { get; set; }

        public int? PrognosisId { get; set; }
        public Prognosis prognosis { get; set; }
    }
}
