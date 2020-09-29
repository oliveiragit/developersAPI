using DevelopersTeste.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevelopersTeste.DAO
{
  public class GrupoDAO
  {
    DevelopersContext context;
    public GrupoDAO(DevelopersContext contexto)
    {
      this.context = contexto;
    }
    public IList<Grupo> Lista()
    {
      return context.Grupos.ToList();
    }
    public Grupo Add(Grupo grupo)
    {
      context.Grupos.Add(grupo);
      context.SaveChanges();
      return grupo;
    }
    public Grupo Update(Grupo grupo)
    {
      context.Entry(grupo).State = EntityState.Modified;
      context.SaveChanges();
      return grupo;
    }
    public void Remove(int numero)
    {
      var grupo = context.Grupos.Single(grupo => grupo.GrupoId == numero);
      //Caso queira apagar também os clientes
      // var clientes = context.Clientes
      // .Where(c => c.GrupoId == numero);
      //  context.Clientes.RemoveRange(clientes);
      context.Grupos.Remove(grupo);
      context.SaveChanges();
    }

    public Grupo FetchById(int numero)
    {

      return context.Grupos
          .Where(c => c.GrupoId == numero)
          .FirstOrDefault();
    }
  }
}