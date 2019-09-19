using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportingBusiness.Models;
using ReportingBusiness.Service;

namespace ReportingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _ReportsService;
        public ReportsController(IReportsService ReportsService)
        {
            _ReportsService = ReportsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReportModel>>> Get()
        {
            try
            {
                var result = await _ReportsService.GenerateReport();

                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode((int)HttpStatusCode.InternalServerError, e.InnerException);
            }
        }

    }
}
