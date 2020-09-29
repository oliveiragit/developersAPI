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
  public class GrupoController : Controller
  {
    private readonly ILogger<GrupoController> _logger;
    DevelopersContext context;
    public GrupoController(ILogger<GrupoController> logger, DevelopersContext contexto)
    {
      _logger = logger;
      this.context = contexto;
    }

    [Route("TesteGrupos")]
    public JsonResult index()
    {
      IList<Grupo> dao = new GrupoDAO(context).Lista();
      return Json(dao);
    }

    [HttpPost("TesteGrupos")]
    [ApiConventionMethod(typeof(DefaultApiConventions),
                       nameof(DefaultApiConventions.Post))]
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
        return BadRequest();
      }
    }

    [ApiConventionMethod(typeof(DefaultApiConventions),
                       nameof(DefaultApiConventions.Put))]
    [HttpPut("TesteGrupos")]
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
        return BadRequest();
      }

    }

    [HttpDelete("TesteGrupos")]
    [ApiConventionMethod(typeof(DefaultApiConventions),
                       nameof(DefaultApiConventions.Delete))]
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
        return BadRequest();
      }
    }

    [HttpGet("TesteGrupos/{grupoId}")]
    public IActionResult GrupoGrupo(int grupoId)
    {
      GrupoDAO dao = new GrupoDAO(context);
      try
      {
        Grupo grupo = dao.FetchById(grupoId);
        if (grupo == null)
        {
          throw new Exception("e");
        }

        return Json(grupo);
      }
      catch
      {
        return NotFound();
      }

    }
  }
}