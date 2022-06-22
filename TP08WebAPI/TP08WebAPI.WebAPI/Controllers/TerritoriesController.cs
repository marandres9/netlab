using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TP07MVC.Common.Exceptions;
using TP07MVC.Entity.DTO;
using TP07MVC.Logic;

namespace TP08WebAPI.WebAPI.Controllers
{
    [RoutePrefix("api/territories")]
    public class TerritoriesController: ApiController
    {
        private readonly TerritoriesLogic _logic = new TerritoriesLogic();

        [HttpGet]
        [Route("")]
        /// <summary>
        /// Returns a list of all territories
        /// </summary>
        public IHttpActionResult GetAll()
        {
            var territories = _logic.GetAll();
            return Ok(territories);
        }

        [HttpGet]
        [Route("filter/{name}")]
        /// <summary>
        /// Returns a list of all territories filtered by TerritoryDescription
        /// </summary>
        public IHttpActionResult GetFiltered(string name)
        {
            var territories = _logic.GetAll(name);
            return Ok(territories);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetDetails(string id)
        {
            try
            {
                var terr = _logic.GetDetails(id);
                return Ok(terr);
            }
            catch(IDNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(string id)
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
        public IHttpActionResult Add([FromBody] TerritoryDto terr)
        {
            try
            {
                var newTerritory = _logic.Add(terr);
                return Created($"/api/territories/{newTerritory.TerritoryID}", newTerritory);
            }
            catch(IDAlreadyTakenException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(EntityFailedValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidForeignKeyException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public IHttpActionResult Edit([FromBody] TerritoryDto terr)
        {
            try
            {
                var updatedTerritory = _logic.Update(terr);
                return Ok(updatedTerritory);
            }
            catch(IDNotFoundException)
            {
                return NotFound();
            }
            catch(EntityFailedValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidForeignKeyException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}