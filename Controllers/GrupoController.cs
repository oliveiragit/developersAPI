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
  [Route("api/TesteGrupos")]
  [ApiController]
  public class GrupoController : Controller
  {
    private readonly ILogger<GrupoController> _logger;
    DevelopersContext _context;
    public GrupoController(ILogger<GrupoController> logger, DevelopersContext context)
    {
      _logger = logger;
      this._context = context;
    }

    [HttpGet]
    public async Task<ActionResult<Grupo>> index()
    {
      try
      {
        IAsyncEnumerable<Grupo> gruposList = new GrupoService(_context).GetList();
        var grupos = new List<Grupo>();
        await foreach (Grupo grupo in gruposList)
        {
          grupos.Add(grupo);
        }
        return Json(grupos);
      }
      catch
      {
        return BadRequest(Json(new { error = "Bad Request - Database error" }));
      }
    }

    [HttpGet("{id:int:min(1)}")]
    public async Task<ActionResult<Grupo>> getById(int id)
    {
      try
      {
        Grupo grupo = await new GrupoService(_context).FetchById(id);
        if (grupo == null)
          throw new Exception();
        return grupo;
      }
      catch
      {
        return NotFound(
          Json(new { error = $"Not Found - id {id}" }));

      }
    }
    [HttpPost]
    public async Task<ActionResult<Grupo>> Add([FromBody] Grupo grupo)
    {
      try
      {
        await new GrupoService(_context).Add(grupo);
        return grupo;
      }
      catch
      {
        return BadRequest(Json(new { error = "Bad Request - Database error" }));
      }
    }
    [HttpPut]
    public async Task<ActionResult<Grupo>> Update([FromBody] Grupo grupo)
    {
      try
      {
        await new GrupoService(_context).Update(grupo);
        return grupo;
      }
      catch
      {
        return BadRequest(Json(new { error = "Bad Request - Database error" }));
      }
    }

    [HttpDelete]
    public async Task<ActionResult<Grupo>> Remove(int grupoId)
    {

      if (grupoId == 0)
        return BadRequest();
  
      try
      {
        await new GrupoService(_context).Remove(grupoId);
        return NoContent();
      }
      catch
      {
        return BadRequest(Json(new { error = "Bad Request - remove fails" }));
      }
    }
  }
}