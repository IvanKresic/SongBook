using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MP3HRCloud.Models
{
    public class Mp3Context : DbContext
    {
        public Mp3Context()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Mp3Files> Mp3Files { get; set; }
        public DbSet<SeNalaziNa> SeNalaziNa { get; set; }
        public DbSet<Playlista> Playlista { get; set; }

    }
    
    public class Mp3InicijalnaBaza : CreateDatabaseIfNotExists<Mp3Context>
    {
        protected override void Seed(Mp3Context context)
        {
            base.Seed(context);

            var datoteka = new List<Mp3Files>();
            var playlista = new List<Playlista>();
            var seNalazi = new List<SeNalaziNa>();


            //Popunjavanje Playlista
            playlista.Add(new Playlista { 
                NazivPlayliste = "Pop",
            });

            playlista.Add(new Playlista
            {
                NazivPlayliste = "Rock",
            });

            playlista.Add(new Playlista
            {
                NazivPlayliste = "Electronic",
            });

            playlista.Add(new Playlista
            {
                NazivPlayliste = "Urban",
            });

            playlista.Add(new Playlista
            {
                NazivPlayliste = "Alternative",
            });
            
            //Popunjavanje mp3 datoteka
            datoteka.Add(new Mp3Files {
                NaslovPjesme = "See You Again",
                Izvodjac = "Wiz Khalifa",
                GodinaIzdavanja = 2014,
                Trajanje = "3:52",
                Velicina = "6.7",
            });

            datoteka.Add(new Mp3Files
            {
                NaslovPjesme = "Shat Up And Dance",
                Izvodjac = "Walk The Moon",
                GodinaIzdavanja = 2014,
                Trajanje = "4:20",
                Velicina = "8.3",
            });

            datoteka.Add(new Mp3Files
            {
                NaslovPjesme = "Hey Mama",
                Izvodjac = "David Guetta",
                GodinaIzdavanja = 2011,
                Trajanje = "5:32",
                Velicina = "10.11",
            });

            datoteka.Add(new Mp3Files
            {
                NaslovPjesme = "Sweet Emotion",
                Izvodjac = "Aerosmith",
                GodinaIzdavanja = 1975,
                Trajanje = "4:33",
                Velicina = "8.4",
            });

            datoteka.Add(new Mp3Files
            {
                NaslovPjesme = "Kashmir",
                Izvodjac = "Led Zeppelin",
                GodinaIzdavanja = 1975,
                Trajanje = "8:28",
                Velicina = "15.3",
            });

            datoteka.Add(new Mp3Files
            {
                NaslovPjesme = "Back In Black",
                Izvodjac = "AC/DC",
                GodinaIzdavanja = 1980,
                Trajanje = "4:15",
                Velicina = "8.3",
            });

            datoteka.Add(new Mp3Files
            {
                NaslovPjesme = "King",
                Izvodjac = "Years & Years",
                GodinaIzdavanja = 2015,
                Trajanje = "5:12",
                Velicina = "9",
            });

            datoteka.Add(new Mp3Files
            {
                NaslovPjesme = "Be Together",
                Izvodjac = "Major Lazer",
                GodinaIzdavanja = 2015,
                Trajanje = "4:12",
                Velicina = "8.3",
            });

            datoteka.Add(new Mp3Files
            {
                NaslovPjesme = "Fantasy",
                Izvodjac = "Alina Baraz & Galimatias",
                GodinaIzdavanja = 2015,
                Trajanje = "6:31",
                Velicina = "12",
            });

            //Popunjavanje playliste pjesmama
            seNalazi.Add(new SeNalaziNa {
                IDPjesme = 1,
                IDPlayliste = 1,                
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 2,
                IDPlayliste = 1,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 3,
                IDPlayliste = 1,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 4,
                IDPlayliste = 2,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 5,
                IDPlayliste = 2,                             
            });

            seNalazi.Add(new SeNalaziNa {
                IDPjesme = 6,
                IDPlayliste = 2,                
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 7,
                IDPlayliste = 3,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 8,
                IDPlayliste = 3,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 9,
                IDPlayliste = 3,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 1,
                IDPlayliste = 4,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 2,
                IDPlayliste = 4,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 3,
                IDPlayliste = 4,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 7,
                IDPlayliste = 4,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 8,
                IDPlayliste = 4,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 9,
                IDPlayliste = 4,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 4,
                IDPlayliste = 5,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 5,
                IDPlayliste = 5,
            });

            seNalazi.Add(new SeNalaziNa
            {
                IDPjesme = 6,
                IDPlayliste = 5,
            });

            //Spremanje podataka u bazu
            datoteka.ForEach(a => context.Mp3Files.Add(a));
            playlista.ForEach(b => context.Playlista.Add(b));
            seNalazi.ForEach(c => context.SeNalaziNa.Add(c));

            context.SaveChanges();
        }

    }
}