using System;
using Amazon_Review_Generator.Contracts;
using Amazon_Review_Generator.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Amazon_Review_Generator.Controllers
{
    [Route("api/generate")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMarkovHelper _markovHelper;

        public ReviewController(IMarkovHelper markovHelper)
        {
            this._markovHelper = markovHelper;
        }

        // GET /api/generate
        // Randomly generates an Amazon review from the Singleton MarkovHelper's Markov chain representated as JSON.
        [HttpGet]
        public Review Generate()
        {
            Random rand = new Random();
            string review = string.Join(" ", this._markovHelper.Chain.Chain(rand));

            return JsonConvert.DeserializeObject<Review>(review);
        }
    }
}
