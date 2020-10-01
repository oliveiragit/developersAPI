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
  [Route("api/TesteGrupos")]
  public class GrupoController : Controller
  {
    private readonly ILogger<GrupoController> _logger;
    DevelopersContext context;
    public GrupoController(ILogger<GrupoController> logger, DevelopersContext context)
    {
      _logger = logger;
      this.context = context;
    }

    [HttpGet]
    public IActionResult index()
    {
      try
      {
        IList<Grupo> dao = new GrupoDAO(context).Lista();
        return Json(dao);
      }
      catch
      {
        return BadRequest(Json(new { error = "Bad Request - Database error" }));
      }
    }
    [HttpGet("{id:int:min(1)}")]
    public IActionResult GrupoGrupo(int id)
    {
      GrupoDAO dao = new GrupoDAO(context);
      try
      {
        Grupo grupo = dao.FetchById(id);
        if (grupo == null)
        {
          throw new Exception();
        }

        return Json(grupo);
      }
      catch
      {
        return BadRequest(
          Json(new { error = $"Bad Request - Not found with id ${id}" }));
      }

    }

    [HttpPost]
    public IActionResult Add([FromBody] Grupo grupo)
    {
      GrupoDAO dao = new GrupoDAO(context);
      try
      {
        if (!ModelState.IsValid)
          throw new Exception();
        dao.Add(grupo);
        return Json(grupo);
      }
      catch
      {
        return BadRequest(
          Json(new { error = "Bad Request - Your request is missing parameters" }));
      }
    }

    [HttpPut]
    public IActionResult Editar([FromBody] Grupo grupo)
    {
      GrupoDAO dao = new GrupoDAO(context);
      try
      {
        if (!ModelState.IsValid)
          throw new Exception();
        dao.Update(grupo);
        return Json(grupo);
      }
      catch
      {
        return BadRequest(
          Json(new { error = "Bad Request - Not found" }));
      }

    }

    [HttpDelete]
    public IActionResult Apagar(int grupoId)
    {
      GrupoDAO dao = new GrupoDAO(context);
      try
      {
        dao.Remove(grupoId);
        return NoContent();
      }
      catch
      {
        return BadRequest(
          Json(new { error = $"Bad Request - Not found with ID: {grupoId}" }));
      }
    }
  }
}