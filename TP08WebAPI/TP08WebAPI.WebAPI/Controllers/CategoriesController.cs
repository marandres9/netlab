using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TP07MVC.Common.Exceptions;
using TP07MVC.Data;
using TP07MVC.Entity;
using TP07MVC.Entity.DTO;
using TP07MVC.Logic;

namespace TP08WebAPI.WebAPI.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController: ApiController
    {
        private readonly ICategoriesLogic _logic;

        public CategoriesController(ICategoriesLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var categories = _logic.GetList();
            return Ok(categories);
        }
        [HttpGet]
        [Route("filter/{name}")]
        public IHttpActionResult GetFiltered(string name)
        {
            var categories = _logic.GetList(name);
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetDetails(int id)
        {
            try
            {
                var category = _logic.GetDetails(id);
                return Ok(category);
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
        public IHttpActionResult Add([FromBody] CategoryDto category)
        {
            try
            {
                var newCategory = _logic.Add(category);
                return Created($"/api/categories/{newCategory.CategoryID}", newCategory);
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
        public IHttpActionResult Edit([FromBody] CategoryDto category)
        {
            try
            {
                var updatedCategory = _logic.Update(category);
                return Ok(updatedCategory);
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