using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API_Assignment_1.Models;

namespace API_Assignment_1.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> countrylist = new List<Country>()
        {
            new Country{ID=1, CountryName="India", Capital="New Delhi"},
            new Country{ID=2, CountryName="USA", Capital="New York"},
        };

        // GET: api/Country
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return countrylist;
        }

        // GET: api/Country/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var country = countrylist.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        // POST: api/Country
        [HttpPost]
        public IHttpActionResult Post([FromBody] Country country)
        {
            country.ID = countrylist.Count + 1; // Assigning ID
            countrylist.Add(country);
            return CreatedAtRoute("DefaultApi", new { id = country.ID }, country);
        }

        // PUT: api/Country/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Country country)
        {
            var existingCountry = countrylist.FirstOrDefault(c => c.ID == id);
            if (existingCountry == null)
            {
                return NotFound();
            }
            existingCountry.CountryName = country.CountryName;
            existingCountry.Capital = country.Capital;
            return Ok(existingCountry);
        }

        // DELETE: api/Country/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var country = countrylist.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            countrylist.Remove(country);
            return Ok(country);
        }
    }
}