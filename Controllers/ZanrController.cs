using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebProjDarko.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZanrController : ControllerBase
    {
        public FilmotekaContext Context { get; set ;}
        public ZanrController(FilmotekaContext context)
        {
            Context=context;
        }
        
        [Route("PreuzmiZanr")]
        [HttpGet]
        public async Task<ActionResult> Preuzmi()
        {
            try
            {
                return Ok(await Context.Zanrovi.Select( p => new{ p.ID, p.Naziv }).ToListAsync() );
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}