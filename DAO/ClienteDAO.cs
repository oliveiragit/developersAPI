using DevelopersTeste.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevelopersTeste.DAO
{
  public class ClienteDAO
  {
    DevelopersContext context;
    public ClienteDAO(DevelopersContext contexto)
    {
      this.context = contexto;
    }
    public IList<Cliente> Lista()
    {
      return context.Clientes.ToList();
    }
    public Cliente Add(Cliente cliente)
    {
      context.Clientes.Add(cliente);
      context.SaveChanges();
      return cliente;
    }
    public Cliente Update(Cliente cliente)
    {
      context.Entry(cliente).State = EntityState.Modified;
      context.SaveChanges();
      return cliente;
    }
    public void Remove(int numero)
    {
      var cliente = context.Clientes.Single(cliente => cliente.ClienteId == numero);
    
      context.Clientes.Remove(cliente);
      context.SaveChanges();
    }

    public Cliente FetchById(int numero)
    {

      return context.Clientes
          .Where(c => c.ClienteId == numero)
          .FirstOrDefault();
    }
  }
}