using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ExamsBusiness.Models;
using ExamsBusiness.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExamsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamsService _examsService;
        public ExamsController(IExamsService examsService)
        {
            _examsService = examsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExamModel>>> Get()
        {
            try
            {
                var exams = await _examsService.GetExamsList();

                return Ok(exams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamDetailsModel>> Get(int id)
        {
            try
            {

                var exam = await _examsService.GetExamDetails(id);

                return Ok(exam);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }
    }
}
