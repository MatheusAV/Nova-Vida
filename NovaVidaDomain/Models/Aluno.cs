using System.ComponentModel.DataAnnotations;

namespace NovaVidaDomain.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valor da Mensalidade")]
        public decimal ValorMensalidade { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Vencimento")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "ID do Professor")]
        public int IdProfessor { get; set; }
    }
}
