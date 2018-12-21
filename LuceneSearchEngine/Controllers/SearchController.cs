using FizzWare.NBuilder;
using Newtonsoft.Json;
using SearchEngine.Web.LuceneProvider;
using SearchEngine.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SearchEngine.Web.Controllers
{
    public class SearchController : ApiController
    {
        // GET api/search?wanted=value
        [HttpGet]
        public string Get(string wanted)
        {
            LuceneEngine engine = new LuceneEngine();
            var result = engine.Search("Title", wanted);
            return JsonConvert.SerializeObject(result);
        }

        // POST api/search
        public void Post()
        {
            LuceneEngine engine = new LuceneEngine();
            var classifieds = Builder<Classifieds>.CreateListOfSize(100)
                .All()
                    .With(c => c.Id = Faker.RandomNumber.Next(1000000))
                    .With(c => c.Title = Faker.Lorem.Sentence(6))
                    .With(c => c.Price = Faker.RandomNumber.Next(1000000))
                    .With(c => c.Region = Faker.Lorem.Words(2).FirstOrDefault())
                    .With(c => c.City = Faker.Lorem.Words(2).FirstOrDefault())
                    .With(c => c.CityArea = Faker.Lorem.Words(2).FirstOrDefault())
                    .Build();

            engine.AddToIndex(classifieds);
        }

        // PUT api/search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/search/5
        public void Delete(int id)
        {
        }

    }
}