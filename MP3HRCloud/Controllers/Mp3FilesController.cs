using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MP3HRCloud.Models;
//using System.Web.Mvc;

namespace MP3HRCloud.Controllers
{
    public class Mp3FilesController : ApiController  
    {
        private Mp3Context db = new Mp3Context();

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }
        

        [HttpGet]
        public IEnumerable<Mp3Files> Get()
        {
            return db.Mp3Files.AsEnumerable();
        }

        public List<Mp3Files> Get(int id)
        {
            Mp3Files mp3File = db.Mp3Files.Find(id);
            List<Mp3Files> mp3FilesForPlaylist = new List<Mp3Files>();
            mp3FilesForPlaylist.Add(mp3File);
            if (mp3File == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return mp3FilesForPlaylist;
        }

        //unos nove pjesme
        public HttpResponseMessage Post(Mp3Files mp3File)
        {
            if (ModelState.IsValid)
            {
                db.Mp3Files.Add(mp3File);
                db.SaveChanges();
                int idPjesme = mp3File.IDPjesme;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, mp3File);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = mp3File.IDPjesme }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        //ažuriranje pjesme
        public HttpResponseMessage Put(int id, Mp3Files mp3Files)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != mp3Files.IDPjesme)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(mp3Files).State = EntityState.Modified;
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

        //Brisanje pjesme
        public HttpResponseMessage Delete(int id)
        {
            Mp3Files mp3File = db.Mp3Files.Find(id);
            //SeNalaziNa seNalazi = db.SeNalaziNa.Where(IDPjesme = id);
            
            if (mp3File == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Mp3Files.Remove(mp3File);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, mp3File);
        }
    }


}
