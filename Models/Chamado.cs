using System.ComponentModel.DataAnnotations;

namespace Teste_Codificar.Models;

public class Chamado
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Adicione um título.")]
    [StringLength(100)]
    [Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Adicione uma descrição.")]
    [StringLength(1000)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Selecione uma prioridade.")]
    public Prioridade Prioridade { get; set; }
   
    public StatusChamado Status { get; set; }

    [Required(ErrorMessage = "Selecione um responsável.")]
    [Display(Name = "ID do Responsável")]
    public int ResponsavelId { get; set; }

    public Responsavel? Responsavel { get; set; }
    [Display(Name = "Data da Abertura")]
    public DateTime DataAbertura { get; set; } = DateTime.Now;
}