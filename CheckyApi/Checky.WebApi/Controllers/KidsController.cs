using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Checky.Data;
using Checky.Data.Factories;
using Checky.Data.Repositories;
using System.Web.Http.Cors;

namespace Checky.WebApi.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class KidsController : ApiController
    {
        private ICheckyRepository _checkyRepository;
        KidFactory _kidFactory = new KidFactory();

        public KidsController()
        {
            _checkyRepository = new CheckyRepository(new CheckyContext());
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var kid = _checkyRepository.GetKids().ToList().Select(k => _kidFactory.CreateKid(k));
                return Ok(kid);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var kid = _checkyRepository.GetKid(id);
                if (kid != null)
                {
                    var kidDto = _kidFactory.CreateKid(kid);
                    return Ok(kidDto);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] DTO.Kid kid)
        {
            try
            {
                //If expense not properly Bound or not retreived return, BadRequest()
                if (kid == null)
                {
                    return BadRequest();
                }
                //map from DTO
                var k = _kidFactory.CreateKid(kid);

                var result = _checkyRepository.AddKid(k);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    //map to dto
                    var newKid = _kidFactory.CreateKid(result.Entity);
                    return Created<DTO.Kid>(Request.RequestUri + "/" + newKid.Id.ToString(), newKid);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put(int id, [FromBody]DTO.Kid kid)
        {
            try
            {
                if (kid == null)
                {
                    return BadRequest();
                }

                // map
                var k = _kidFactory.CreateKid(kid);

                var result = _checkyRepository.UpdateKid(k);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    // map to dto
                    var updatedExpense = _kidFactory.CreateKid(result.Entity);
                    return Ok(updatedExpense);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
