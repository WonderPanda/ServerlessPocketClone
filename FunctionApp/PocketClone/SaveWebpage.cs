using System.Linq;
using Autofac;
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
using PocketClone.Config;

namespace PocketClone
{
    public static class SaveWebpage
    {
        [FunctionName("SaveWebpage")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "pages")] HttpRequestMessage req, 
            ILogger log)
        {
            var page = await req.Content.ReadAsAsync<SavedPage>();

            if (page == null)
                return req.CreateResponse(HttpStatusCode.BadRequest, "Pass JSON body for the page to be saved");

            List<ValidationResult> results;
            var isValid = ValidationService.TryValidate(page, out results);
            
            if (!isValid)
                return req.CreateResponse(HttpStatusCode.BadRequest, results);

            var searchService = Locator.Container.Resolve<ISearchService>();
            await searchService.IndexItem(page);

            return req.CreateResponse(HttpStatusCode.OK);
        }
    }
}
