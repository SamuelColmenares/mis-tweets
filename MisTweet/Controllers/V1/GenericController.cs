

namespace MisTweet.Controllers.V1
{
    using Microsoft.AspNetCore.Mvc;
    using MisTweet.Contracts.V1.Responses;
    using MisTweet.Data;
    using MisTweet.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/v1/[controller]")]
    public abstract class GenericController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public GenericController(TRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = new GenericResponse();
            try
            {
                var data = await _repository.GetAll();
                if (data == null)
                {
                    response.Message = "Invalid.";
                    response.StatusCode = 500;
                }

                response.Data = data;
            }
            catch (Exception ex)
            {

                response.Message = ErrorMessage(ex);
                response.StatusCode = 530;
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = new GenericResponse();
            try
            {
                var data = await _repository.Get(id);
                if (data == null)
                {
                    response.Message = "NotFound";
                    response.StatusCode = 404;
                    return NotFound(response);
                }

                response.Data = data;
            }
            catch (Exception ex)
            {
                response.Message = ErrorMessage(ex);
                response.StatusCode = 530;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TEntity entity)
        {
            var response = new GenericResponse();
            try
            {
                var data = await _repository.Add(entity);
                if (data == null)
                {
                    response.Message = "NotFound";
                    response.StatusCode = 404;
                    return NotFound(response);
                }

                response.Data = data;
            }
            catch (Exception ex)
            {
                response.Message = ErrorMessage(ex);
                response.StatusCode = 530;
            }

            return CreatedAtAction("Get", new { id = entity.Id},response);
        }


        private string ErrorMessage(Exception e)
        {
            string message = $"{e.Message} -- ";

            if (e.InnerException != null)
            {
                message += ErrorMessage(e.InnerException);
            }
            else
            {
                message += "FIN";
            }

            return message;
        }
    }
}
