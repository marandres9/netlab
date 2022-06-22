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
        [Route("get")]
        public IHttpActionResult GetAll()
        {
            var list = _logic.GetAll();

            return Ok(list);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult GetDetails(string id)
        {
            var terr = _logic.GetDetails(id);
            return Ok(terr);
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
            catch(IDNotFoundException ex)
            {
                return BadRequest(ex.Message);
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
                _logic.Add(terr);
            }
            catch(IDAlreadyTakenException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(EntityFailedValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Created($"/api/territories/{terr.TerritoryID}", terr);
        }

        [HttpPut]
        [Route("edit/")]
        public IHttpActionResult Edit([FromBody] TerritoryDto terr)
        {
            try
            {
                _logic.Update(terr);
            }
            catch(EntityFailedValidationException ex)
            {
                return BadRequest(ex.Message);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(terr);
        }
    }
}