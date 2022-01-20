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
    public class IznajmljivanjeController : ControllerBase
    {
        public FilmotekaContext Context { get; set ;}
        public IznajmljivanjeController(FilmotekaContext context)
        {
            Context=context;
        }
        
        [Route("PreuzmiIznajmljivanje/{RegBroj}")]
        [HttpGet]
        public async Task<ActionResult> PreuzmiIznajmljivanje(int RegBroj)
        {
            if(RegBroj < 100 || RegBroj > 999)
                return BadRequest("Pogresna vrednost registarskog broja");    

            var i = Context.FilmoviKorisnici
            .Include(p => p.Korisnik)
            .Include(p => p.Film)
            .Include(p => p.Filmoteka)
            .Where(p => p.Korisnik.RegistarskiBroj == RegBroj);

            var x = Context.Korisnici.Where(p => p.RegistarskiBroj == RegBroj).FirstOrDefault();
            if(x == null)
                return BadRequest("Ne postoji iznajmljivanje za izabran registarski broj");

            try
            {
                return Ok( await i.Select( p =>
                    new
                    {
                        Filmoteka = p.Filmoteka.Naziv,
                        Ime = p.Korisnik.Ime,
                        Prezime = p.Korisnik.Prezime,
                        Mesec = p.Mesec.Naziv,
                        Film = p.Film.Naziv,
                        Zanr= p.Film.Zanr.Naziv
                    }).ToListAsync()
                );
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("UnesiIznajmljivanje/{mesecID}/{registarskiBroj}/{Sifra}")]
        [HttpPost]
        public async Task<ActionResult> UnesiIznajmljivanje(int mesecID, int registarskiBroj, int Sifra)
        {
            try
            {
                var korisnik = await Context.Korisnici.Where(p => p.RegistarskiBroj == registarskiBroj).FirstOrDefaultAsync();
                var film = await Context.Filmovi.Where(p => p.Sifra == Sifra).FirstOrDefaultAsync();
                var mesec = await Context.Meseci.FindAsync(mesecID);

                if(korisnik == null)
                    return BadRequest("Korisnik sa izabranim registarskim brojem  ne postoji");
                if(film == null)
                    return BadRequest("Film sa izabranom sifrom ne postoji");
                if(mesec == null)
                    return BadRequest("Izabrani mesec ne postoji");       


                var filmotek = await Context.Korisnici
                .Include(p => p.Filmoteka)
                .Where(p => p.RegistarskiBroj == registarskiBroj).FirstOrDefaultAsync();

                if(filmotek.Filmoteka != film.Filmoteka)
                    return BadRequest("Korisnik i film se ne nalaze u istoj Filmoteci"); 

                Iznajmljivanje i =new Iznajmljivanje
                {
                    Korisnik = korisnik,
                    Film = film,
                    Mesec = mesec,
                    Filmoteka = filmotek.Filmoteka
                };

                Context.FilmoviKorisnici.Update(i);
                await Context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}