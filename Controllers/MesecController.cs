using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebProjDarko.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MesecController : ControllerBase
    {
        public FilmotekaContext Context { get; set ;}
        public MesecController(FilmotekaContext context)
        {
            Context=context;
        }

        
        //[EnableCors("CORS")]
        [Route("PreuzmiMesec")]
        [HttpGet]
        public async Task<ActionResult> Preuzmi()
        {
            try
            {
                return Ok(await Context.Meseci.Select( p => new{ p.ID, p.Naziv }).ToListAsync() );
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}