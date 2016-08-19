using System.Collections.Generic;
using System.Web.Http;

namespace BooksEditor.MVC.Controllers
{
    public class AuthorController : ApiController
    {
        // GET: api/Author
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Author/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Author
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Author/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Author/5
        public void Delete(int id)
        {
        }
    }
}
