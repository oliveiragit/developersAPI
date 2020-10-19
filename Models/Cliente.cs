using System;
using System.ComponentModel.DataAnnotations;

namespace DevelopersTeste.Models

{
  public class Cliente
  {
    public int ClienteId { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    [MinLength(11)]
    [MaxLength(11)]
    public string Cpf { get; set; }
    [MaxLength(13)]
    public string Telefone { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
    [Required]
    public int? GrupoId { get; set; }
    public Grupo Grupo { get; set; }


  }
}