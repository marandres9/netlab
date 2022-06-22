using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TP07MVC.Logic;

namespace TP08WebAPI.WebAPI.Controllers
{
    [RoutePrefix("api/territories")]
    public class TerritoriesController : ApiController
    {
        private readonly TerritoriesLogic _logic = new TerritoriesLogic();

        [HttpGet]
        [Route("get")]
        public IHttpActionResult GetTerritories()
        {
            var list = _logic.GetById("2400");

            return Json(list);
        }
    }
}