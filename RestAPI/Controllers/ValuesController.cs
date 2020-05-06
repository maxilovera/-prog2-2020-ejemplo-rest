using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private static List<string> Valores = new List<string>();

        [HttpOptions]
        public List<string> Documentacion()
        {
            return new List<string>()
            {
                "GET /api/values",
                "POST /api/values (body: { Value: algo })",
                "PUT /api/values/{id} (body: { Value: algo })",
                "DELETE /api/values/{id}",
            };
        }

        // GET api/values
        public List<ValueModel> Get()
        {
            return Valores.Select(x => new ValueModel() { Value = x }).ToList();            
        }       

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ValueModel valueModel)
        {
            Valores.Add(valueModel.Value);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody]ValueModel valueModel)
        {
            Valores[id] = valueModel.Value;
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
            Valores.RemoveAt(id);
        }
    }
}
