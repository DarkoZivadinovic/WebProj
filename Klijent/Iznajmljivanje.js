export class Iznajmljivanje{
    constructor(filmoteka, ime, prezime, mesec, film, zanr){
        this.filmoteka=filmoteka;
        this.ime=ime;
        this.prezime=prezime;
        this.mesec=mesec;
        this.film=film;
        this.zanr=zanr;
    }

    crtaj(host){
       
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML=this.filmoteka;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.ime;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.prezime;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.mesec;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.film;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.zanr;
        tr.appendChild(el);
    }
}