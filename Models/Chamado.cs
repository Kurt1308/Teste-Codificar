using System.ComponentModel.DataAnnotations;

namespace Teste_Codificar.Models;

public class Chamado
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [StringLength(1000)]
    public string Descricao { get; set; } = string.Empty;

    [Required]
    public Prioridade Prioridade { get; set; }

    [Required]
    public StatusChamado Status { get; set; }

    public int ResponsavelId { get; set; }

    public Responsavel? Responsavel { get; set; }

    public DateTime DataAbertura { get; set; } = DateTime.Now;
}