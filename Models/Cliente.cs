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
    [MinLength(2)]
    public string Cpf { get; set; }
    public int Telefone { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
    public int? GrupoId { get; set; }
    public Grupo Grupo { get; set; }


  }
}