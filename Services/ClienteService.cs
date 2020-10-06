using System;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using DevelopersTeste.Models;

namespace DevelopersTeste.Services
{
  public class ClienteService
  {
    DevelopersContext context;
    public ClienteService(DevelopersContext contexto)
    {
      this.context = contexto;
    }
    public IAsyncEnumerable<Cliente> GetList()
    {
      return context.Clientes.Include("Grupo").AsAsyncEnumerable<Cliente>();
    }
    public Task<int> Add(Cliente cliente)
    {
      context.Clientes.Add(cliente);
      return context.SaveChangesAsync();

    }
    public ValueTask<Cliente> FetchById(int clienteId)
    {
      return context.Clientes.FindAsync(clienteId);
    }
    public Task<int> Update(Cliente cliente)
    {
      context.Entry(cliente).State = EntityState.Modified;
      return context.SaveChangesAsync();
    }
    public Task<int> Remove(int numero)
    {
      var cliente = context.Clientes.Single(cliente => cliente.ClienteId == numero);
      context.Clientes.Remove(cliente);
      return context.SaveChangesAsync();
    }
  }
}