using DevTease.AspNetCoreApp.Interfaces.Repository;
using DevTease.AspNetCoreApp.Models;
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

            // This line will make sure to fail one of the integration tests:
            // banana.Curvature = -1;

            return banana;
        }
    }
}