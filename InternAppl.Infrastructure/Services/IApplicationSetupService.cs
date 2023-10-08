using InternAppl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternAppl.Infrastructure.Services
{
    public interface IApplicationSetupService
    {
        public Task<ApiResponse> SaveApplicationSetup(ApplicationSetup appl);
        public Task<ApplicationSetup> GetApplicationSetup(string id);
        public Task<List<ApplicationSetup>> GetApplicationSetups();
    }
}
