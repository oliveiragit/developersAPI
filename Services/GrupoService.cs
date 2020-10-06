using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DevelopersTeste.Models;

namespace DevelopersTeste.Services
{
  public class GrupoService
  {
    DevelopersContext context;
    public GrupoService(DevelopersContext contexto)
    {
      this.context = contexto;
    }
    public IAsyncEnumerable<Grupo> GetList()
    {
      return context.Grupos.AsAsyncEnumerable<Grupo>();
    }
    public Task<int> Add(Grupo grupo)
    {
      context.Grupos.Add(grupo);
      return context.SaveChangesAsync();

    }
    public ValueTask<Grupo> FetchById(int grupoId)
    {
      return context.Grupos.FindAsync(grupoId);
    }
    public Task<int> Update(Grupo grupo)
    {
      context.Entry(grupo).State = EntityState.Modified;
      return context.SaveChangesAsync();
    }
    public Task<int> Remove(int numero)
    {
      var grupo = context.Grupos.Single(grupo => grupo.GrupoId == numero);
      //Caso queira apagar também os clientes
      // var clientes = context.Clientes
      // .Where(c => c.GrupoId == numero);
      //  context.Clientes.RemoveRange(clientes);
      context.Grupos.Remove(grupo);
      return context.SaveChangesAsync();
    }
  }
}