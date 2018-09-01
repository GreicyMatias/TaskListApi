using System;
using System.Collections.Generic;
using System.Web.Http;
using TaskList.Application.Services;
using TaskList.Domain.Models;

namespace TaskList.API.Controllers
{
    public class TaskController : ApiController
    {
        TaskService service = new TaskService();

        // GET: api/Task
        public IHttpActionResult Get()
        {
            var data = service.GetAll();

            return Ok(data);
        }

        // GET: api/Task/5
        public IHttpActionResult Get(int id)
        {
            var data = service.Get(id);

            return Ok(data);
        }

        // POST: api/Task (Adicionar um objeto)
        public IHttpActionResult Post([FromBody]TaskModel model)
        {
            try
            {
                service.Add(model);

                return Ok();
            }
            catch (Exception)
            {
                // coloca m log com o erro especifico
                return BadRequest();
            }
        }

        // PUT: api/Task/5
        public IHttpActionResult PutStatus([FromBody]TaskModel model)
        {
            try
            {
                service.UpdateStatus(model);

                return Ok();
            }
            catch (Exception)
            {
                // coloca m log com o erro especifico
                return BadRequest();
            }
        }

        public IHttpActionResult Put([FromBody]TaskModel model)
        {
            try
            {
                service.UpdateStatus(model);

                return Ok();
            }
            catch (Exception)
            {
                // coloca m log com o erro especifico
                return BadRequest();
            }
        }

        // DELETE: api/Task/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                service.Remove(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
