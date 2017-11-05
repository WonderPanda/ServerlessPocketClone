using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using PocketClone.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using PocketClone.Services;

namespace PocketClone
{
    public static class SaveWebpage
    {
        [FunctionName("SaveWebpage")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "pages")] HttpRequestMessage req, 
            ILogger log)
        {

            req.CreateResponse(HttpStatusCode.OK);

            var data = await req.Content.ReadAsAsync<SavedPage>();

            if (data == null)
                return req.CreateResponse(HttpStatusCode.BadRequest, "Pass JSON body for the page to be saved");

            List<ValidationResult> results;
            var isValid = ValidationService.TryValidate(data, out results);
            
            if (!isValid)
                return req.CreateResponse(HttpStatusCode.BadRequest, results);
            
            return req.CreateResponse(HttpStatusCode.OK);

            //// Set name to query string or body data
            //name = name ?? data?.name;

            //return name == null
            //    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
            //    : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
        }
    }
}
