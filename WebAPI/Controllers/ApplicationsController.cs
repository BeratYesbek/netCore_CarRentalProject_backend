using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        
            private IApplicantionService _customerApplicantService;

            public ApplicationsController(IApplicantionService customerApplicantService)
            {
                _customerApplicantService = customerApplicantService;
            }
            [HttpGet("getall")]
            public IActionResult getAll()
            {
                var result = _customerApplicantService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPost("add")]
            public IActionResult Add(Applicant customerApplicant)
            {
                var result = _customerApplicantService.Add(customerApplicant);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPost("update")]
            public IActionResult Update(Applicant customerApplicant)
            {
                var result = _customerApplicantService.Update(customerApplicant);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPost("delete")]
            public IActionResult Delete(Applicant customerApplicant)
            {
                var result = _customerApplicantService.Delete(customerApplicant);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
       
    }
}
