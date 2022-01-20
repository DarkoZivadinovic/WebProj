import { Filmoteka } from "./Filmoteka.js";
import { Zanr } from "./Zanr.js";
import { Mesec } from "./Mesec.js";
import { NazFilmoteka } from "./NazFilmoteka.js";

var listaMeseca =[];

fetch("https://localhost:5001/Mesec/PreuzmiMesec")
.then(p=>{
    p.json().then(meseci=>{
        meseci.forEach(mesec => {
            var m = new Mesec(mesec.id, mesec.naziv);
            listaMeseca.push(m);
        });
        

        var listaZanrova=[];
        fetch("https://localhost:5001/Zanr/PreuzmiZanr")
        .then(p=>{
            p.json().then(zanrovi=>{
                zanrovi.forEach(zanr=>{
                    var z = new Zanr(zanr.id, zanr.naziv);
                    listaZanrova.push(z);
                })

                var listaFilmoteka=[];
                fetch("https://localhost:5001/Filmoteka/PreuzmiFilmoteke")
                .then(p=>{
                    p.json().then(filmoteke=>{
                        filmoteke.forEach(fil=>{
                            var x = new NazFilmoteka(fil.id, fil.naziv);
                            listaFilmoteka.push(x);
                        })
                        var f = new Filmoteka(listaMeseca, listaZanrova, listaFilmoteka);
                        f.crtaj(document.body);
                    })
                }) 
            })
        }) 
    })
})