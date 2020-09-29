using DevelopersTeste.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

namespace DevelopersTeste.DAO
{
  public class DevelopersContext : DbContext
  {
    public DevelopersContext(DbContextOptions<DevelopersContext> options) : base(options)
    {
    }
    public DbSet<Grupo> Grupos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
  }
}