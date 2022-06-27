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
using TP08WebAPI.WebAPI.Models;

namespace TP08WebAPI.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/shippers")]
    public class ShippersController: ApiController
    {
        private readonly ShippersLogic _logic = new ShippersLogic();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var shippers = _logic.GetAll();
            var shippersList = shippers.Select(s => new ShipperModel { ShipperID = s.ShipperID, CompanyName = s.CompanyName }).ToList();
            return Ok(shippersList);
        }

        [HttpGet]
        [Route("filter/{name}")]
        public IHttpActionResult GetFiltered(string name)
        {
            var shippers = _logic.GetList(s => s.CompanyName.ToLower().Contains(name.ToLower()));
            return Ok(shippers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetDetails(int id)
        {
            try
            {
                var shipper = _logic.GetDetails(id);
                return Ok(shipper);
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
        public IHttpActionResult Add([FromBody] ShipperDto shipper)
        {
            try
            {
                var newShipper = _logic.Add(shipper);
                return Created($"/api/shippers/{newShipper.ShipperID}", newShipper);
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
        public IHttpActionResult Edit([FromBody] ShipperDto shipper)
        {
            try
            {
                var updatedShipper = _logic.Update(shipper);
                return Ok(updatedShipper);
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
