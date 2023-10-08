using InternAppl.Domain.Entities;
using InternAppl.Infrastructure.Config;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InternAppl.Infrastructure.Services
{
    public class ApplicationSetupService : IApplicationSetupService
    {
        private static readonly Connector _connector = new Connector();
        public ApiResponse apiResponse = new ApiResponse();

        public async Task<ApiResponse> SaveApplicationSetup(ApplicationSetup appl)
        {
            await _connector.Connect();
            try
            {
                // Read the item to see if it exists.  
                ItemResponse<ApplicationSetup> application = await _connector.container.ReadItemAsync<ApplicationSetup>(appl.Id, new PartitionKey(appl.Id));
                apiResponse.Errors.Add($"Item in database with id: {appl.Id} already exists\n");
                apiResponse.Success = false;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                appl.Id = Guid.NewGuid().ToString();
                ItemResponse<ApplicationSetup> application = await _connector.container.CreateItemAsync<ApplicationSetup>(appl, new PartitionKey(appl.Id));
                apiResponse.Create_Id = appl.Id;
                apiResponse.Success = true;
            }
            return apiResponse;
        }

        public async Task<ApplicationSetup> GetApplicationSetup(string id)
        {
            await _connector.Connect();
            var sqlQueryText = "SELECT * FROM c WHERE c.id = @id";

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText).WithParameter("@id", id);
            FeedIterator<ApplicationSetup> queryResultSetIterator = _connector.container.GetItemQueryIterator<ApplicationSetup>(queryDefinition);

            List<ApplicationSetup> applications = new List<ApplicationSetup>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<ApplicationSetup> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (ApplicationSetup item in currentResultSet)
                {
                    applications.Add(item);
                }
            }
            return applications.FirstOrDefault();
        }

        public async Task<List<ApplicationSetup>> GetApplicationSetups()
        {
            await _connector.Connect();
            var sqlQueryText = "SELECT * FROM c";

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<ApplicationSetup> queryResultSetIterator = _connector.container.GetItemQueryIterator<ApplicationSetup>(queryDefinition);

            List<ApplicationSetup> applications = new List<ApplicationSetup>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<ApplicationSetup> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (ApplicationSetup item in currentResultSet)
                {
                    applications.Add(item);
                }
            }
            return applications;
        }
    }
}
