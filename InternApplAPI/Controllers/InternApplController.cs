using InternAppl.Domain.Entities;
using InternAppl.Infrastructure.Config;
using InternAppl.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace InternApplAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InternApplController : ControllerBase
    {
        private  readonly IConfiguration _configuration;
        private readonly IApplicationSetupService _apService;

        public InternApplController(IApplicationSetupService apService)
        {
            _apService = apService;
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            _configuration = builder.Build();
        }

        [HttpPost("/SaveApplicationSetup")]
        public async Task<ApiResponse> SaveApplication(ApplicationSetup appl)
        {
            var response = await _apService.SaveApplicationSetup(appl);
            return response;
        }

        [HttpGet("/GetApplicationSetup/{id}")]
        public async Task<ApplicationSetup> GetApplicationSetup(string id)
        {
            return await _apService.GetApplicationSetup(id);
        }

        [HttpGet("/GetApplicationSetups")]
        public async Task<List<ApplicationSetup>> GetApplicationSetups()
        {
            return await _apService.GetApplicationSetups();
        }
    }
}
