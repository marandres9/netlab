using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TP07MVC.Common.Exceptions;
using TP07MVC.Entity.DTO;
using TP07MVC.Logic;

namespace TP08WebAPI.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/regions")]
    public class RegionController: ApiController
    {
        private readonly RegionLogic _logic = new RegionLogic();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var regions = _logic.GetList();
            return Ok(regions);
        }
        [HttpGet]
        [Route("filter/{name}")]
        public IHttpActionResult GetFiltered(string name)
        {
            var regions = _logic.GetList(name);
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetDetails(int id)
        {
            try
            {
                var region = _logic.GetDetails(id);
                return Ok(region);
            }
            catch(IDNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _logic.Delete(id);
                return Ok(id);
            }
            catch(IDNotFoundException)
            {
                return NotFound();
            }
            catch(TriedDeletingReferencedForeignKeyException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add([FromBody] RegionDto region)
        {
            try
            {
                var newRegion = _logic.Add(region);
                return Created($"/api/region/{newRegion.RegionID}", newRegion);
            }
            catch(IDAlreadyTakenException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(EntityFailedValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public IHttpActionResult Edit([FromBody] RegionDto region)
        {
            try
            {
                var updatedRegion = _logic.Update(region);
                return Ok(updatedRegion);
            }
            catch(IDNotFoundException)
            {
                return NotFound();
            }
            catch(EntityFailedValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
