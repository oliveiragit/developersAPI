using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevelopersTeste.Services;
using DevelopersTeste.Models;

namespace DevelopersTeste.Controllers
{
  [Route("api/TesteClientes")]
  [ApiController]
  public class ClienteController : Controller
  {
    private readonly ILogger<ClienteController> _logger;
    DevelopersContext _context;
    public ClienteController(ILogger<ClienteController> logger, DevelopersContext context)
    {
      _logger = logger;
      this._context = context;
    }

    [HttpGet]
    public async Task<ActionResult<Cliente>> index()
    {
      try
      {
        IAsyncEnumerable<Cliente> clientesList = new ClienteService(_context).GetList();
        var clientes = new List<Cliente>();
        await foreach (Cliente cliente in clientesList)
        {
          clientes.Add(cliente);
        }
        return Json(clientes);
      }
      catch
      {
        return BadRequest(Json(new { error = "Bad Request - Database error" }));
      }
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<ActionResult<Cliente>> getById(int id)
    {
      try
      {
        Cliente cliente = await new ClienteService(_context).FetchById(id);
        if (cliente == null)
          throw new Exception();
        return cliente;
      }
      catch
      {
        return NotFound(
          Json(new { error = $"Not Found - id {id}" }));

      }
    }
    [HttpPost]
    public async Task<ActionResult<Cliente>> Add([FromBody] Cliente cliente)
    {
      try
      {
        await new ClienteService(_context).Add(cliente);
        return cliente;
      }
      catch
      {
        return BadRequest(Json(new { error = "Bad Request - Database error" }));
      }
    }
    [HttpPut]
    public async Task<ActionResult<Cliente>> Update([FromBody] Cliente cliente)
    {
      try
      {
        await new ClienteService(_context).Update(cliente);
        return cliente;
      }
      catch
      {
        return BadRequest(Json(new { error = "Bad Request - Database error" }));
      }
    }

    [HttpDelete]
    public async Task<ActionResult<Cliente>> Remove(int clienteId)
    {

      if (clienteId == 0)
        return BadRequest();
  
      try
      {
        await new ClienteService(_context).Remove(clienteId);
        return NoContent();
      }
      catch
      {
        return BadRequest(Json(new { error = "Bad Request - remove fails" }));
      }
    }
  }
}