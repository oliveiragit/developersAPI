using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using DevelopersTeste.DAO;
using DevelopersTeste.Models;

namespace DevelopersTeste.Controllers
{
  [Route("api/TesteClientes")]
  public class ClienteController : Controller
  {
    private readonly ILogger<ClienteController> _logger;
    DevelopersContext context;
    public ClienteController(ILogger<ClienteController> logger, DevelopersContext context)
    {
      _logger = logger;
      this.context = context;
    }

    [HttpGet]
    public IActionResult index()
    {
      try
      {
        IList<Cliente> dao = new ClienteDAO(context).Lista();
        return Json(dao);
      }
      catch
      {
        return BadRequest(Json(new { error = "Bad Request - Database error" }));
      }
    }
    [HttpGet("{id:int:min(1)}")]
    public IActionResult ClienteCliente(int id)
    {
      ClienteDAO dao = new ClienteDAO(context);
      try
      {
        Cliente cliente = dao.FetchById(id);
        if (cliente == null)
        {
          throw new Exception("e");
        }

        return Json(cliente);
      }
      catch
      {
        return BadRequest(
          Json(new { error = $"Bad Request - Not found with id ${id}" }));
      }

    }

    [HttpPost]
    public IActionResult Add([FromBody] Cliente cliente)
    {
      ClienteDAO dao = new ClienteDAO(context);
      try
      {
        if (!ModelState.IsValid)
          throw new Exception();
        dao.Add(cliente);
        return Json(cliente);
      }
      catch
      {
        return BadRequest(
          Json(new { error = "Bad Request - Your request is missing parameters" }));
      }
    }

    [HttpPut]
    public IActionResult Editar([FromBody] Cliente cliente)
    {
      ClienteDAO dao = new ClienteDAO(context);
      try
      {
        if (!ModelState.IsValid)
          throw new Exception();
        dao.Update(cliente);
        return Json(cliente);
      }
      catch
      {
        return BadRequest(
          Json(new { error = "Bad Request - Not found" }));
      }

    }

    [HttpDelete]
    public IActionResult Apagar(int clienteId)
    {
      ClienteDAO dao = new ClienteDAO(context);
      try
      {
        dao.Remove(clienteId);
        return NoContent();
      }
      catch
      {
        return BadRequest(
          Json(new { error = $"Bad Request - Not found with ID: {clienteId}" }));
      }
    }
  }
}