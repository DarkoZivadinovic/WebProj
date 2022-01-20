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
    public class KorisnikController : ControllerBase
    {
        public FilmotekaContext Context { get; set ;}
        public KorisnikController(FilmotekaContext context)
        {
            Context=context;
        }
        [Route("PreuzmiKorisnikaa/{idFilmoteka}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiKorisnikaa (int idFilmoteka)
        {
           
             var filmot = await Context.Filmoteke.Where(p => p.ID == idFilmoteka).FirstOrDefaultAsync();    

            var filmovi = Context.Filmovi
            .Include(p => p.Zanr)
            .Include(p => p.Filmoteka)
            .Where(p => p.Filmoteka == filmot);

            var korisnici = Context.Korisnici
            .Include(p => p.Filmoteka)
            .Where(p => p.Filmoteka == filmot);

            var korisnik = await korisnici.ToListAsync();
            return Ok(
                korisnik.Select(p =>
                new
                { 
                    ID=p.ID,
                    RegistarskiBroj = p.RegistarskiBroj,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Filmoteka=p.Filmoteka
                }).ToList()
           
            );


        }

        [Route("PreuzmiKorisnika/{regBroj}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiKorisnika (int regBroj)
        {
            if(regBroj < 100 || regBroj > 999)
                return BadRequest("Pogresna vrednost Registarskog broja");

            var x = Context.Korisnici.Where(p => p.RegistarskiBroj == regBroj).FirstOrDefault();
            if(x == null)
                return BadRequest("Ne postoji Korisnik sa izabranim registarskim brojem");

            var korisnici = Context.Korisnici
            .Include(p => p.Filmoteka)
            .Where(p => p.RegistarskiBroj == regBroj);

            var korisnik = await korisnici.ToListAsync();
            return Ok(
                korisnik.Select(p =>
                new
                { 
                    ID=p.ID,
                    RegistarskiBroj = p.RegistarskiBroj,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Filmoteka=p.Filmoteka
                }).ToList()
            );


        }

        [Route("DodajKorisnika/{regBroj}/{ime}/{prezime}/{filmoteka}")]
        [HttpPost]
        public async Task<ActionResult> DodajKorisnika(int regBroj, string ime, string prezime, int filmoteka)
        {
            bool isDigitPresent = ime.Any(c => char.IsDigit(c));
            bool isDigitPresent2 = prezime.Any(c => char.IsDigit(c));

            if(string.IsNullOrWhiteSpace(ime) || ime.Length > 30 || isDigitPresent==true)
                return BadRequest("Pogresno ime");

            if(string.IsNullOrWhiteSpace(prezime) || prezime.Length > 30  || isDigitPresent2==true)
                return BadRequest("Pogresno prezime");  

            if(regBroj < 100 || regBroj > 999)
                return BadRequest("Pogresna vrednost registarskog broja");    

            var film = await Context.Filmoteke.Where(p => p.ID == filmoteka).FirstOrDefaultAsync();
            if(film == null)
                    return BadRequest("Filmoteka ne postoji");

             var korisnik =  Context.Korisnici.Where(p => p.RegistarskiBroj == regBroj).FirstOrDefault();
            if(korisnik!=null)
                return BadRequest("Postoji vec korisnik sa tim registarskim brojem");

            try{
                Korisnik c = new Korisnik
                {
                    RegistarskiBroj = regBroj,
                    Ime = ime,
                    Prezime = prezime,
                    Filmoteka = film
                };
                Context.Korisnici.Add(c);
                await Context.SaveChangesAsync();
                return Ok("Korisnik je dodat");    
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }

        }
        [Route("PromeniKorisnika")]
        [HttpPut]
        public async Task<ActionResult> PromeniKorisnika(int regBroj, string ime, string prezime, int filmoteka)
        {
            bool isDigitPresent = ime.Any(c => char.IsDigit(c));
            bool isDigitPresent2 = prezime.Any(c => char.IsDigit(c));

            if(string.IsNullOrWhiteSpace(ime) || ime.Length > 30 || isDigitPresent==true)
                return BadRequest("Pogresno ime");

            if(string.IsNullOrWhiteSpace(prezime) || prezime.Length > 30  || isDigitPresent2==true)
                return BadRequest("Pogresno prezime");  

            if(regBroj < 100 || regBroj > 999)
                return BadRequest("Pogresna vrednost registarskog broja");    

            var film = await Context.Filmoteke.Where(p => p.ID == filmoteka).FirstOrDefaultAsync();
            if(film == null)
                    return BadRequest("Filmoteka ne postoji");

            try
            {
                var korisnik = Context.Korisnici.Where( p => p.RegistarskiBroj == regBroj ).FirstOrDefault();
                if(korisnik != null)
                {
                    korisnik.Ime=ime;
                    korisnik.Prezime=prezime;
                    korisnik.Filmoteka=film;
                    await Context.SaveChangesAsync();
                    return Ok("Uspesno promenjen koisnik sa ID: "+korisnik.ID);
                }
                else
                    return BadRequest("Korisnik nije pronadjen");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("IzbrisiKorisnika/{regBroj}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiClana(int regBroj)
        {
            if(regBroj < 100 || regBroj > 999)
                return BadRequest("Pogresna vrednost registarskog broja");  

            var korisnik = Context.Korisnici.Where( p => p.RegistarskiBroj == regBroj ).FirstOrDefault();
            try
            {
                if(korisnik != null)
                {
                    Context.Korisnici.Remove(korisnik);
                    await Context.SaveChangesAsync();
                    return Ok("Izbrisan korisnik sa ID: "+korisnik.ID);

                }
                else   
                    return BadRequest("Korisnik nije pronadjen");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}