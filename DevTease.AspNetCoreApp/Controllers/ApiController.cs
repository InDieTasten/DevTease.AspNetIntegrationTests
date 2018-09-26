using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTease.AspNetCoreApp.Interfaces.Repository;
using DevTease.AspNetCoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevTease.AspNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IBananaRepository bananaRepository;

        public ApiController(IBananaRepository bananaRepository)
        {
            this.bananaRepository = bananaRepository;
        }

        [HttpGet("/api/banana")]
        public Banana Get()
        {
            var banana = bananaRepository.GetBanana();

            banana.Curvature = -1;

            return banana;
        }
    }
}