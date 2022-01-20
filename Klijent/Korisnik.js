export class Korisnik{

    constructor(regBr, ime, prezime,filmoteka){
        this.regBr=regBr;
        this.ime=ime;
        this.prezime=prezime;
        this.filmoteka=filmoteka;
    }

    crtajK(host){
       
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML=this.regBr;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.ime;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.prezime;
        tr.appendChild(el);

     
    }
}