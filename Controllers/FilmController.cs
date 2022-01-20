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
    public class FilmController : ControllerBase
    {
        public FilmotekaContext Context { get; set ;}
        public FilmController(FilmotekaContext context)
        {
            Context=context;
        }

        [Route("PreuzmiFilm/{filmoteka}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiFilm (int filmoteka)
        {
            
            var filmot = await Context.Filmoteke.Where(p => p.ID == filmoteka).FirstOrDefaultAsync();    

            var filmovi = Context.Filmovi
            .Include(p => p.Zanr)
            .Include(p => p.Filmoteka)
            .Where(p => p.Filmoteka == filmot);

            var film = await filmovi.ToListAsync();
            return Ok(
                film.Select(p =>
                new
                { 
                    ID=p.ID,
                    Sifra = p.Sifra,
                    Naziv = p.Naziv,
                    Zanr = p.Zanr.Naziv,
                    Filmoteka = p.Filmoteka.Naziv
                }).ToList()
            );


        }

        [Route("DodajFilm/{sifra}/{naziv}/{zanr}/{filmoteka}")]
        [HttpPost]
        public async Task<ActionResult> DodajFilm(int sifra, string naziv, int zanr, int filmoteka)
        {
            if(sifra < 100 || sifra > 999)
                return BadRequest("Pogresna vrednost sifre");

            if(string.IsNullOrWhiteSpace(naziv) || naziv.Length > 50  )
                return BadRequest("Pogresan naziv");

            var z = Context.Zanrovi.Where( p => p.ID == zanr ).FirstOrDefault();
            if(z == null)
                return BadRequest("Izabrani zanr ne postoji");

            var fil = await Context.Filmoteke.Where(p => p.ID == filmoteka).FirstOrDefaultAsync();
            if(fil == null)
                    return BadRequest("Filmoteka ne postoji");  

            var film =  Context.Filmovi.Where(p => p.Sifra == sifra).FirstOrDefault();
            if(film!=null)
                return BadRequest("Postoji vec Film sa tom  sifrom");  
            var filmN =  Context.Filmovi.Where(p => p.Naziv == naziv).FirstOrDefault();
            if(filmN!=null)
            {
                return BadRequest("Postoji vec Film sa tim  imenom");
            }

            try{
                Film k = new Film
                {
                    Sifra = sifra,
                    Naziv = naziv,
                    Zanr = z,
                    Filmoteka = fil
                };
                Context.Filmovi.Add(k);
                await Context.SaveChangesAsync();
                return Ok("Film je dodat");    
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }

        }
        [Route("PromeniFilm/{Sifra}/{Naziv}/{Zanr}/{filmoteka}")]
        [HttpPut]
        public async Task<ActionResult> PromeniFilm(int Sifra, string Naziv, int Zanr, int filmoteka)
        {
            if(Sifra < 100 || Sifra > 999)
                return BadRequest("Pogresna vrednost sifre");

            if(string.IsNullOrWhiteSpace(Naziv) || Naziv.Length > 50)
                return BadRequest("Naziv nije validan"); 

            var fil = await Context.Filmoteke.Where(p => p.ID == filmoteka).FirstOrDefaultAsync();
            if(fil == null)
                    return BadRequest("Filmoteka ne postoji");

            var x = Context.Zanrovi.Where( p => p.ID == Zanr ).FirstOrDefault();

            try
            {

                var film = Context.Filmovi.Where( p => p.Sifra == Sifra ).FirstOrDefault();
                if(film != null)
                {

                    film.Naziv=Naziv;
                    film.Zanr=x;
                    film.Filmoteka = fil;
                    await Context.SaveChangesAsync();
                    return Ok("Uspesno promenjen film sa ID: "+film.ID);
                }
                else
                    return BadRequest("Film nije pronadjen");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("IzbrisiFilm/{Sifra}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiFilm(int Sifra)
        {
            if(Sifra < 100 || Sifra > 999)
                return BadRequest("Pogresna vrednost sifre");
                
            var filmovi = Context.Filmovi.Where( p => p.Sifra == Sifra ).FirstOrDefault();
            try
            {
                if(filmovi != null)
                {
                    Context.Filmovi.Remove(filmovi);
                    await Context.SaveChangesAsync();
                    return Ok("Izbrisan film sa ID: "+filmovi.ID);

                }
                else   
                    return BadRequest("Film nije pronadjen");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}