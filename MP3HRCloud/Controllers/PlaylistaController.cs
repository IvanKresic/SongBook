using MP3HRCloud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MP3HRCloud.Controllers
{
    public class PlaylistaController : ApiController
    {

        private Mp3Context db = new Mp3Context();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }


        [System.Web.Mvc.HttpGet]
        public IEnumerable<Playlista> Get()
        {
            return db.Playlista.AsEnumerable();
        }

        //public Playlista Get(int id)
        //{
        //    Playlista playlista = db.Playlista.Find(id);
        //    if (playlista == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }
        //    return playlista;
        //}

        public IEnumerable<Playlista> Get(string playlist)
        {

            var myPlaylist = db.Playlista.AsEnumerable();

            if(!String.IsNullOrEmpty(playlist))
            {
                myPlaylist = myPlaylist.Where(s => s.NazivPlayliste.Contains(playlist));
            }



            //IEnumerable<Playlista> playlists = db.Playlista.AsEnumerable();
            //List<Playlista> myPlaylist = new List<Playlista>();

            //if (playlists == null)
            //{
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            //}
            //foreach(Playlista i in playlists)
            //{
            //    if(i.NazivPlayliste.ToLower().Contains(playlist.ToLower()))
            //    {
            //        myPlaylist.Add(i);
            //    }
            //}

            return myPlaylist;
        }

        //unos nove pjesme
        public HttpResponseMessage Post(Playlista playlista)
        {
            if (ModelState.IsValid)
            {
                db.Playlista.Add(playlista);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, playlista);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = playlista.IDPlayliste }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        //ažuriranje pjesme
        public HttpResponseMessage Put(int id, Playlista playlista)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != playlista.IDPlayliste)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(playlista).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //Brisanje playliste
        public HttpResponseMessage Delete(int id)
        {
            Playlista playlista = db.Playlista.Find(id);

            if (playlista == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Playlista.Remove(playlista);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, playlista);
        }
    }
}
