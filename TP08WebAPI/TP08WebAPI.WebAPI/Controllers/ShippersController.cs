using System.Web.Http;
using System.Web.Http.Cors;
using TP07MVC.Common.Exceptions;
using TP07MVC.Entity.DTO;
using TP07MVC.Logic;

namespace TP08WebAPI.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/shippers")]
    public class ShippersController: ApiController
    {
        private readonly IShippersLogic _logic;

        public ShippersController(IShippersLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var shippersList = _logic.GetList();
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
