using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Band.API.Migrations;
using Band.API.Models.Repository;
using BandModel = Band.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Band.API.Controllers
    {
    [Route("api/[controller]")]
    public class BandController : Controller
        {

        private IDataRepository<BandModel.Band, int> _iRepo;

        public BandController(IDataRepository<BandModel.Band, int> repo)
            {
            _iRepo = repo;
            }

        // GET: api/values
        [HttpGet]
        public IEnumerable<BandModel.Band> Get()
            {
            return _iRepo.GetAll();
            }

        // GET api/values/5
        [HttpGet("{id}")]
        public BandModel.Band Get(int id)
            {
            return _iRepo.Get(id);
            }

        // POST api/values
        [HttpPost]
        public int Post([FromBody]BandModel.Band band)
            {
            return _iRepo.Add(band);
            }

        // PUT api/values/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody]BandModel.Band band)
            {
            return _iRepo.Update(band.Id, band);
            }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public int Delete(int id)
            {
            return _iRepo.Delete(id);
            }
        }
    }
