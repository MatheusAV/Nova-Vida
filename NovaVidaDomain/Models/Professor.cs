using System.ComponentModel.DataAnnotations;

namespace NovaVidaDomain.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Contratação")]
        public DateTime DataContratacao { get; set; }
        
        [Required(ErrorMessage = "O campo Departamento é obrigatório.")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "O campo Matéria é obrigatório.")]
        public string Materia { get; set; }
       
    }
}