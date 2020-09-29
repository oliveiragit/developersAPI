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
  public class ClienteController : Controller
  {
    private readonly ILogger<ClienteController> _logger;
    DevelopersContext context;
    public ClienteController(ILogger<ClienteController> logger, DevelopersContext contexto)
    {
      _logger = logger;
      this.context = contexto;
    }

    [Route("TesteClientes")]
    public JsonResult index()
    {
      IList<Cliente> dao = new ClienteDAO(context).Lista();
      return Json(dao);
    }

    [HttpPost("TesteClientes")]
    [ApiConventionMethod(typeof(DefaultApiConventions),
                       nameof(DefaultApiConventions.Post))]
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
        return BadRequest();
      }
    }

    [HttpPut("TesteClientes")]
    [ApiConventionMethod(typeof(DefaultApiConventions),
                           nameof(DefaultApiConventions.Put))]
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
        return BadRequest();
      }

    }

    [HttpDelete("TesteClientes")]
    [ApiConventionMethod(typeof(DefaultApiConventions),
                       nameof(DefaultApiConventions.Delete))]
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
        return BadRequest();
      }
    }

    [HttpGet("TesteClientes/{clienteId}")]
    public IActionResult ClienteCliente(int clienteId)
    {
      ClienteDAO dao = new ClienteDAO(context);
      try
      {
        Cliente cliente = dao.FetchById(clienteId);
        if (cliente == null)
        {
          throw new Exception("e");
        }

        return Json(cliente);
      }
      catch
      {
        return NotFound();
      }

    }
  }
}