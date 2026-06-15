using System.ComponentModel.DataAnnotations;

namespace Teste_Codificar.Models;

public class Chamado
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [StringLength(1000)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Required]
    public Prioridade Prioridade { get; set; }

    [Required]
    public StatusChamado Status { get; set; }
    [Display(Name = "ID do Responsável")]
    public int ResponsavelId { get; set; }

    public Responsavel? Responsavel { get; set; }
    [Display(Name = "Data da Abertura")]
    public DateTime DataAbertura { get; set; } = DateTime.Now;
}