export class Film{

    constructor(sifra, naziv, zanr, filmoteka){
        this.sifra=sifra;
        this.naziv=naziv;
        this.zanr=zanr;
        this.filmoteka=filmoteka;
    }

    crtaj(host){
       
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML=this.sifra;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.naziv;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.zanr;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.filmoteka;
        tr.appendChild(el);
    }
}