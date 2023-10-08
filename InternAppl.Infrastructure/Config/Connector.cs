using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace InternAppl.Infrastructure.Config
{
    public class Connector
    {
        private static readonly string EndpointUri = ConfigurationManager.AppSettings["EndPointUri"];

        private static readonly string PrimaryKey = ConfigurationManager.AppSettings["PrimaryKey"];

        public CosmosClient cosmosClient;

        private Database database;

        public Container container;

        // The name of the database and container we will create
        private string databaseId = "InternAppDb";
        private string containerId = "InternAppContainer";

        public CosmosClient GetClient()
        {
            return this.cosmosClient;
        }

        // <GetStartedDemoAsync>
        /// <summary>
        /// Entry point to call methods that operate on Azure Cosmos DB resources in this sample
        /// </summary>
        public async Task Connect()
        {
            // Create a new instance of the Cosmos Client
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions() { ApplicationName = "InternApplProgram" });
            await this.CreateDatabaseAsync();
            await this.CreateContainerAsync();
            await this.ScaleContainerAsync();
        }
        // </GetStartedDemoAsync>

        // <CreateDatabaseAsync>
        /// <summary>
        /// Create the database if it does not exist
        /// </summary>
        private async Task CreateDatabaseAsync()
        {
            // Create a new database
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Trace.WriteLine("Created Database: {0}\n", this.database.Id);
        }
        // </CreateDatabaseAsync>

        // <CreateContainerAsync>
        /// <summary>
        /// Create the container if it does not exist. 
        /// Specifiy "/LastName" as the partition key since we're storing family information, to ensure good distribution of requests and storage.
        /// </summary>
        /// <returns></returns>
        private async Task CreateContainerAsync()
        {
            // Create a new container
            this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/id", 400);
            Trace.WriteLine("Created Container: {0}\n", this.container.Id);
        }
        // </CreateContainerAsync>

        // <ScaleContainerAsync>
        /// <summary>
        /// Scale the throughput provisioned on an existing Container.
        /// You can scale the throughput (RU/s) of your container up and down to meet the needs of the workload. Learn more: https://aka.ms/cosmos-request-units
        /// </summary>
        /// <returns></returns>
        private async Task ScaleContainerAsync()
        {
            // Read the current throughput
            int? throughput = await this.container.ReadThroughputAsync();
            if (throughput.HasValue)
            {
                Console.WriteLine("Current provisioned throughput : {0}\n", throughput.Value);
                int newThroughput = throughput.Value + 100;
                // Update throughput
                await this.container.ReplaceThroughputAsync(newThroughput);
                Console.WriteLine("New provisioned throughput : {0}\n", newThroughput);
            }

        }
        // </ScaleContainerAsync>
    }
}
