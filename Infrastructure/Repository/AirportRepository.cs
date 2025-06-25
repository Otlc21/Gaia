using Dapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Repository;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Infrastructure.Repository
{
    public class AirportRepository : IAirportRepository
    {
        private readonly AppSettings _appSettings;

        public AirportRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<List<AirportName>> Get(string text, string culture, int skip = 0, int take = 10)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = @"
SELECT * FROM airport AS a
INNER JOIN airportname AS n ON n.AirportId = a.id
WHERE Culture = @Culture
AND
(
	IATA LIKE CONCAT('%', @Text, '%')
    OR Name LIKE CONCAT('%', @Text, '%')
	OR City LIKE CONCAT('%', @Text, '%')
    OR Country LIKE CONCAT('%', @Text, '%')
)
ORDER BY Name
LIMIT @Take OFFSET @Skip;";

                var parameters = new
                {
                    Culture = culture,
                    Text = text,
                    Skip = skip,
                    Take = take
                };

                var result = await connection.QueryAsync<AirportName>(query, parameters);
                return result.ToList();
            }
        }
    }
}
