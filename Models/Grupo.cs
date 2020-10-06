using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevelopersTeste.Models
{
  public class Grupo
  {
    public int GrupoId { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public bool Ativo { get; set; }
  }
}