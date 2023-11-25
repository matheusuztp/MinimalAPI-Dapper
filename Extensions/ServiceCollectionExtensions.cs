using System.Data.SqlClient;
using static MinimalAPICore.Data.TarefaContext;

namespace MinimalAPICore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaltConnection");

            builder.Services.AddScoped<GetConnection>(sp =>
            async () =>
            {
                var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                return connection;
            });

            return builder;
        }
    }
}
