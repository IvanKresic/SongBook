using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MP3HRCloud.Models;

namespace MP3HRCloud.Controllers
{
    public class SeNalaziNaController : ApiController
    {
        Mp3Context db = new Mp3Context();

        [HttpGet]
        public IEnumerable<SeNalaziNa> Get()
        {
            return db.SeNalaziNa.AsEnumerable();
        }

        public SeNalaziNa Get(int id)
        {
            SeNalaziNa seNalazi = new SeNalaziNa();            
            seNalazi = db.SeNalaziNa.Find(id);            
            if (seNalazi == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));                
            }
            return seNalazi;
        }

        //Unos novog
        public HttpResponseMessage Post(SeNalaziNa pjesma)
        {
            if (ModelState.IsValid)
            {
                SeNalaziNa seNalaziPlaylista = new SeNalaziNa();
                seNalaziPlaylista = db.SeNalaziNa.Find(pjesma.IDPlayliste);

                db.SeNalaziNa.Add(pjesma);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, pjesma);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = pjesma.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }              
    }
}
