using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Biblioteca.Data;
using Biblioteca.Data.Modelos;
using System.Web.Http.Description;

namespace Biblioteca.Host.Controllers
{
    public class EditorialController : ApiController
    {
        BibliotecaContext bibliotecaContext = new BibliotecaContext("BibliotecaLocal");

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bibliotecaContext.Dispose();
            }
            base.Dispose(disposing);
        }


        // GET: api/Editorial
        public IEnumerable<Editorial> Get()
        {
            return bibliotecaContext.Editoriales;
        }

        [ResponseType(typeof(Editorial))]
        // GET: api/Editorial/5
        public IHttpActionResult Get(int id)
        {
            var editorial = bibliotecaContext.Editoriales.Find(id);
            if (editorial == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(editorial);
            }
            
        }

        [ResponseType(typeof(Editorial))]
        // POST: api/Editorial
        public IHttpActionResult Post(Editorial nuevoEditorial)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            bibliotecaContext.Editoriales.Add(nuevoEditorial);
            bibliotecaContext.SaveChanges();
            return Ok(nuevoEditorial);
        }

        [ResponseType(typeof(Editorial))]
        // PUT: api/Editorial/5
        public IHttpActionResult Put(int id, Editorial editorial)
        {
            if(id != editorial.Id)
            {
                return BadRequest(ModelState);
            }
            bibliotecaContext.Entry(editorial).State = System.Data.Entity.EntityState.Modified;

            bibliotecaContext.SaveChanges();
            return Ok(editorial);
        }

        [ResponseType(typeof(void))]
        // DELETE: api/Editorial/5
        public IHttpActionResult Delete(int id)
        {
            var editorial = bibliotecaContext.Editoriales.Find(id);
            if(editorial == null)
            {
                return NotFound();
            }

            bibliotecaContext.Editoriales.Remove(editorial);
            bibliotecaContext.SaveChanges();
            return Ok();

        }
    }
}
