using Microsoft.AspNetCore.Mvc;
using RestApiBetterRoute.Application.Dtos;
using RestApiBetterRoute.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace RestApiBetterRoute.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RouteController : Controller
    {
        private readonly IApplicationServiceRoute applicationServiceRoute;

        public RouteController(IApplicationServiceRoute applicationServiceRoute)
        {
            this.applicationServiceRoute = applicationServiceRoute;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceRoute.GetAll());
        }

        // GET api/values/5
        [HttpGet("{origin}/{destiny}")]
        public ActionResult<string> Get(string origin, string destiny)
        {
            return Ok(applicationServiceRoute.GetBetterRoute(origin, destiny));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] RouteDto routeDTO)
        {
            try
            {
                if (routeDTO == null)
                    return NotFound();

                applicationServiceRoute.Add(routeDTO);
                return Ok("Cliente Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] RouteDto routeDTO)
        {
            try
            {
                if (routeDTO == null)
                    return NotFound();

                applicationServiceRoute.Update(routeDTO);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] RouteDto routeDTO)
        {
            try
            {
                if (routeDTO == null)
                    return NotFound();

                applicationServiceRoute.Remove(routeDTO);
                return Ok("Cliente Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
