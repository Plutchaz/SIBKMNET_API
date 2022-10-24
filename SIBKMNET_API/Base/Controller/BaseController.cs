using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIBKMNET_API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_API.Base.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repository, Entity> : ControllerBase
        where Repository : class, IGeneralRepository<Entity>
        where Entity : class
    {
        Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }
        //Create
        public ActionResult Post(Entity entity)
        {
            var result = repository.Post(entity);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        //Update
        public ActionResult Put(Entity entity)
        {
            var result = repository.Put(entity);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        //Read
        public ActionResult Get()
        {
            var data = repository.Get();
            return Ok(new { data = data });
        }

        //read by id
        public ActionResult Get(int id)
        {
            var data = repository.Get(id);
            return Ok(new { data = data });
        }

        //Delete
        public ActionResult Delete(int id)
        {
            var result = repository.Delete(id);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
