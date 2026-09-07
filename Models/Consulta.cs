using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaConsultasUVV.Models
{
    public class Consulta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória.")]
        [StringLength(80, ErrorMessage = "A especialidade deve ter no máximo 80 caracteres.")]
        public string Especialidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data e hora são obrigatórias.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data e Hora")]
        public DateTime DataHora { get; set; }

        [StringLength(500, ErrorMessage = "A descrição pode ter no máximo 500 caracteres.")]
        [Display(Name = "Descrição / Observações")]
        public string? Descricao { get; set; }

        // Chave estrangeira
        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }
    }
}