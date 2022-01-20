import { Iznajmljivanje } from "./Iznajmljivanje.js";
import {Film} from "./Film.js";
import { Korisnik } from "./Korisnik.js";

export class Filmoteka
{
    constructor(listaMeseca,listaZanrova,listaFilmoteka)
    {
        this.listaMeseca=listaMeseca;
        this.listaZanrova=listaZanrova;
        this.listaFilmoteka=listaFilmoteka;
        this.kont = null;
    }
    crtaj(host)
    {
        
        this.kont = document.createElement("div");
        this.kont.className="GlavniKontejner";
        host.appendChild(this.kont);

        let kontKorisnik=document.createElement("div");
        kontKorisnik.className="kontKorisnik";
        this.kont.appendChild(kontKorisnik);

        let kontKorisnik2=document.createElement("div");
        kontKorisnik2.className="kontKorisnik2";
        this.kont.appendChild(kontKorisnik2);

        let kontForma = document.createElement("div");
        kontForma.className = "kontForma";
        this.kont.appendChild(kontForma);

        this.crtajFormu(kontForma);
        this.crtajPrikaz(this.kont);
        this.crtajKorisnika(kontKorisnik);
        this.crtajFormuP(kontKorisnik2);

    }


    crtajPrikaz(host){

        let kontPrikaz = document.createElement("div");
        kontPrikaz.className="kontPrikaz";
        host.appendChild(kontPrikaz);

        var tabela = document.createElement("table");
        tabela.className="tabela";
        kontPrikaz.appendChild(tabela);

        var tabelahead= document.createElement("thead");
        tabela.appendChild(tabelahead);

        var tr = document.createElement("tr");
        tabelahead.appendChild(tr);

        var tabelaBody = document.createElement("tbody");
        tabelaBody.className="TabelaPodaci";
        tabela.appendChild(tabelaBody);
    }
    crtajKorisnika(host)
    {
        const forma = document.createElement("div");
        host.appendChild(forma);
        forma.className="rafForme";
        let labele = [
          "Reg. Broj:",
          "Ime:",
          "Prezime:",
        ];
        let tipovi = [ "number", "text", "text"];
        let klase = ["regBr", "ime", "prezime"];
        let polje = null;
        let labela = document.createElement("label");
        labela.innerHTML = "Unesi novog korisnika: ";
        labela.className = "nazivForme";
        forma.appendChild(labela);
        labele.forEach((el, ind) => {
          labela = document.createElement("label");
          labela.className="UnesiNovogKorisnika";
          labela.innerHTML = el;
          forma.appendChild(labela);
          polje = document.createElement("input");
          polje.type = tipovi[ind];
          polje.className = klase[ind];
          forma.appendChild(polje);
        });

       

        polje = document.createElement("button");
        polje.className = "dugme";
        polje.innerHTML = "Dodaj";
        forma.appendChild(polje);
        polje.onclick = (ev) =>this.dodajKorisnika(); 

    }

    crtajFormuP(host)
    {

        let redPrikaz = document.createElement("div");
        redPrikaz.className = "redPrikaz";
        host.appendChild(redPrikaz);

        let btnFilmovi = document.createElement("button");
        btnFilmovi.className = "btnFilmovi";
        btnFilmovi.innerHTML = "Prikazi filmove";
        btnFilmovi.onclick = (ev)=>this.PrikaziFilmove();
        redPrikaz.appendChild(btnFilmovi);

        let btnKlijenti = document.createElement("button");
        btnKlijenti.className = "btnKlijenti";
        btnKlijenti.innerHTML = "Prikazi Klijente";
        btnKlijenti.onclick = (ev)=>this.PrikaziKorisnike();
        redPrikaz.appendChild(btnKlijenti);

        let btnIznajmljivanja = document.createElement("button");
        btnIznajmljivanja.className = "btnIznajmljivanja";
        btnIznajmljivanja.innerHTML = "Prikazi iznajmljivanja";
        btnIznajmljivanja.onclick = (ev)=>this.PrikaziIznajmljivanja();
        redPrikaz.appendChild(btnIznajmljivanja);


        let z = document.createElement("label");
        z.innerHTML="Filmoteka";
        host.appendChild(z);

        let se = document.createElement("select");
        se.className = "filmotekaSelect";
        host.appendChild(se);

        let op;
        this.listaFilmoteka.forEach(p=>{
            op = document.createElement("option");
            op.innerHTML=p.naziv;
            op.value=p.id;
            se.appendChild(op);
        })


        z = document.createElement("label");
        z.innerHTML="Zanr";
        host.appendChild(z);

        se = document.createElement("select");
        se.className = "zanrSelect";
        host.appendChild(se);

        op;
        this.listaZanrova.forEach(p=>{
            op = document.createElement("option");
            op.innerHTML=p.naziv;
            op.value=p.id;
            se.appendChild(op);
        })

    }
 
  
    crtajFormu(host)
    {   
        let red1 = document.createElement("div");
        red1.className = "red1Button";
        host.appendChild(red1);
        
        let l2 =  document.createElement("label");
        l2.className="l2";
        l2.innerHTML="DODAJTE, IZMENITE, OBRISITE:"
        red1.appendChild(l2);
        
       

        let l =  document.createElement("label");
        l.innerHTML="Sifra"
        red1.appendChild(l);

        var Sifra = document.createElement("input");
        Sifra.type="number";
        Sifra.className="sifraClass";
        red1.appendChild(Sifra);

        l =  document.createElement("label");
        l.innerHTML="Naziv"
        red1.appendChild(l);

        var Naziv = document.createElement("input");
        Naziv.type="text";
        Naziv.className="nazivClass";
        red1.appendChild(Naziv);

        let red = document.createElement("div");
        red.className = "redButton";
        host.appendChild(red);

        let btnDodaj = document.createElement("button");
        btnDodaj.className = "btnDodaj";
        btnDodaj.innerHTML = "Dodaj Film";
        btnDodaj.onclick = (ev)=>this.dodajFilm();
        red.appendChild(btnDodaj);

        let btnIzmeni = document.createElement("button");
        btnIzmeni.className = "btnIzmeni";
        btnIzmeni.innerHTML = "Izmeni Film";
        btnIzmeni.onclick = (ev)=>this.izmeniFilm();
        red.appendChild(btnIzmeni);

        let btnObrisi = document.createElement("button");
        btnObrisi.className = "btnObrisi";
        btnObrisi.innerHTML = "Obrisi film";
        btnObrisi.onclick = (ev)=>this.obrisiFilm();
        red.appendChild(btnObrisi);



        let m = document.createElement("label");
        m.innerHTML="Mesec";
        host.appendChild(m);

        let se1 = document.createElement("select");
        se1.className = "mesecSelect";
        host.appendChild(se1);

        let op1;
        this.listaMeseca.forEach(p=>{
            op1 = document.createElement("option");
            op1.innerHTML=p.naziv;
            op1.value=p.id;
            se1.appendChild(op1);
        })
        
        let l3=document.createElement("label");
        l3.innerHTML="Za prikaz iznajmljivanja unesite:\n "
        host.appendChild(l3);

        l =  document.createElement("label");
        l.innerHTML="Registarski broj"
        host.appendChild(l);
        var regBroj = document.createElement("input");
        regBroj.type="number";
        regBroj.className="regBrojClass";
        host.appendChild(regBroj);

        l =  document.createElement("label");
        l.innerHTML="Sifra"
        host.appendChild(l);
        var Sifra = document.createElement("input");
        Sifra.type="number";
        Sifra.className="sifra2Class";
        host.appendChild(Sifra);


        let btnIznajmi = document.createElement("button");
        btnIznajmi.className = "btnIznajmi";
        btnIznajmi.innerHTML = "Iznajmi";
        btnIznajmi.onclick = (ev)=>this.iznajmiFilm();
        host.appendChild(btnIznajmi);

       
    }  
    dodajKorisnika()
    {
        let a = this.kont.querySelector(".filmotekaSelect");
        var filmotekaID=a.options[a.selectedIndex].value;

        var regBroj = this.kont.querySelector(".regBr").value;
        var ime = this.kont.querySelector(".ime").value;
        var prezime = this.kont.querySelector(".prezime").value;
        console.log(regBroj,ime,prezime);
        fetch("https://localhost:5001/Korisnik/DodajKorisnika/"+regBroj+"/"+ime+"/"+prezime+"/"+filmotekaID,
            {
                method:"POST"
            }).then(s=>{
                if(s.ok){
                    this.PreuzmiKorisnika(filmotekaID);
                }
                else
                {
                    alert("Registarski broj nije validan");
                }
            })
    }        
    dodajFilm()
    {
            let a = this.kont.querySelector(".filmotekaSelect");
            var filmotekaID=a.options[a.selectedIndex].value;

            a = this.kont.querySelector(".zanrSelect");
            var zanrID=a.options[a.selectedIndex].value;

            a = this.kont.querySelector(".nazivClass");
            var naziv=a.value;

            a = this.kont.querySelector(".sifraClass");
            var sifra=a.value;

            fetch("https://localhost:5001/Film/DodajFilm/"+sifra+"/"+naziv+"/"+zanrID+"/"+filmotekaID,
            {
                method:"POST"
            }).then(s=>{
                if(s.ok){
                    this.PreuzmiFilm(filmotekaID);
                }
                else 
                {
                    alert("Sifra ili ime nije validno");
                }
               
            })
    }

    izmeniFilm()
    {
            let a = this.kont.querySelector(".filmotekaSelect");
            var filmotekaID=a.options[a.selectedIndex].value;

            a = this.kont.querySelector(".zanrSelect");
            var zanrID=a.options[a.selectedIndex].value;

            a = this.kont.querySelector(".nazivClass");
            var naziv=a.value;

            a = this.kont.querySelector(".sifraClass");
            var sifra=a.value;

            fetch("https://localhost:5001/Film/PromeniFilm/"+sifra+"/"+naziv+"/"+zanrID+"/"+filmotekaID,
        {
            method:"PUT"
        }).then(s=>{
            if(s.ok){
                this.PreuzmiFilm(filmotekaID);
            }
            else
            {
                alert("Sifra nije validna");
            }
        })
    }

    obrisiFilm()
    {
            let a = this.kont.querySelector(".filmotekaSelect");
            var filmotekaID=a.options[a.selectedIndex].value;

            a = this.kont.querySelector(".sifraClass");
            var sifra=a.value;

            fetch("https://localhost:5001/Film/IzbrisiFilm/"+sifra,
        {
            method:"DELETE"
        }).then(s=>{
            if(s.ok){
                this.PreuzmiFilm(filmotekaID);
            }
            else
            {
                alert("Sifra nije validna");
            }
        })
    }
    PreuzmiKorisnika(filmotekaID)
    {
        console.log(filmotekaID);
        fetch("https://localhost:5001/Korisnik/PreuzmiKorisnikaa/"+filmotekaID,
        {
            method:"GET"
        }).then(s=>{
            if(s.ok){
                if (s.status ==200)
               {
                   var teloTabele = this.obrisiPrethodniSadrzaj();
                    let th;
                    var zag=["Reg. Broj", "Ime", "Prezime"];
                    zag.forEach(el=>{
                        th = document.createElement("th");
                        th.innerHTML=el;
                        teloTabele.appendChild(th);
                    })
                   s.json().then(data=>{
                       console.log(data);
                       data.forEach(s=>{
                           console.log(s.registarskiBroj);
                           const f = new Korisnik(s.registarskiBroj, s.ime, s.prezime);
                           f.crtajK(teloTabele);
                       });
                   })
               }
            }
            else
            {
                this.obrisiPrethodniSadrzaj();
            }
        })
    }

    PreuzmiFilm(filmotekaID)
    {
        fetch("https://localhost:5001/Film/PreuzmiFilm/"+filmotekaID,
        {
            method:"GET"
        }).then(s=>{
            if(s.ok){
                if (s.status ==200)
               {
                   var teloTabele = this.obrisiPrethodniSadrzaj();
                    let th;
                    var zag=["Sifra", "Naziv", "Zanr", "Filmoteka"];
                    zag.forEach(el=>{
                        th = document.createElement("th");
                        th.innerHTML=el;
                        teloTabele.appendChild(th);
                    })
                   s.json().then(data=>{
                       console.log(data);
                       data.forEach(s=>{
                           const f = new Film(s.sifra, s.naziv, s.zanr,s.filmoteka);
                           f.crtaj(teloTabele);
                       });
                   })
               }
            }
            else
            {
                this.obrisiPrethodniSadrzaj();
            }
        })

    }

    iznajmiFilm()
    {
            let a = this.kont.querySelector(".filmotekaSelect");
            var filmotekaID=a.options[a.selectedIndex].value;

            a = this.kont.querySelector(".mesecSelect");
            var mesecID=a.options[a.selectedIndex].value;

            a = this.kont.querySelector(".regBrojClass");
            var regBroj=a.value;

            a = this.kont.querySelector(".sifra2Class");
            var sifraIz=a.value;

            console.log(mesecID);
            console.log(sifraIz);

            this.Iznajmi(mesecID,regBroj,sifraIz)

    }

    Iznajmi(mesecID,regBroj,sifraIz)
    {
        fetch("https://localhost:5001/Iznajmljivanje/UnesiIznajmljivanje/"+mesecID+"/"+regBroj+"/"+sifraIz,
        {
            method:"POST"
        }).then(s=>{
            if(s.ok){
                console.log(s.status);
                console.log(s);
                if (s.status ==200)
               {
                  this.PreuzmiIznajmljivanja(regBroj);
               }
            }
            else
            {
                alert("Nije validno");
            }
        })

    }
    PreuzmiIznajmljivanja(regBroj)
    {
        fetch("https://localhost:5001/Iznajmljivanje/PreuzmiIznajmljivanje/"+regBroj,
        {
            method:"GET"
        }).then(s=>{
            if(s.ok){
                console.log(s.status);
                console.log(s);
                if (s.status ==200)
               {
                    var teloTabele = this.obrisiPrethodniSadrzaj();
                    let th;
                    var zag=["Filmoteka", "Ime", "Prezime", "Mesec", "Film", "Zanr"];
                    zag.forEach(el=>{
                        th = document.createElement("th");
                        th.innerHTML=el;
                        teloTabele.appendChild(th);
                    })
                   s.json().then(data=>{
                       console.log(data);
                       data.forEach(s=>{
                           const f = new Iznajmljivanje(s.filmoteka, s.ime, s.prezime,s.mesec, s.film, s.zanr);
                           f.crtaj(teloTabele);
                       });
                   })
               }
            }
            else
            {
                this.obrisiPrethodniSadrzaj();
            }
        })
    }
    obrisiPrethodniSadrzaj()
    {
        var tabela = document.querySelector(".tabela");
        var roditelj = tabela.parentNode;
        roditelj.removeChild(tabela);

        tabela = document.createElement("tbody");
        tabela.className="tabela";
        roditelj.appendChild(tabela);
        return tabela;
    }


    PrikaziFilmove()
    {
        let a = this.kont.querySelector(".filmotekaSelect");
         var filmotekaID=a.options[a.selectedIndex].value;
        this.PreuzmiFilm(filmotekaID);    
    }
    PrikaziKorisnike()
    {
        let a = this.kont.querySelector(".filmotekaSelect");
        var filmotekaID=a.options[a.selectedIndex].value;
        this.PreuzmiKorisnika(filmotekaID);    
    }

    PrikaziIznajmljivanja()
    {
        let a = parseInt(this.kont.querySelector(".regBrojClass").value);
    
        this.PreuzmiIznajmljivanja(a);    
    
    }




}