using Dapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Infrastructure.Repository
{
    public class MarkupRepository : IMarkupRepository
    {
        private readonly AppSettings _appSettings;

        public MarkupRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<int> Count(Markup item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Exemplo simples: contar todos os registros.
                // Caso deseje aplicar filtros (por exemplo, por Car, Flight ou Hotel),
                // você pode adaptar a query para incluir cláusulas WHERE.
                var query = "SELECT COUNT(*) FROM markups";
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task Delete(int id)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM markups WHERE id = @id";
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Markup> Get(int id)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM markups WHERE id = @id";
                return await connection.QuerySingleOrDefaultAsync<Markup>(query, new { id });
            }
        }

        public async Task<List<Markup>> Get(Markup item, int skip = 0, int take = 10)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Neste exemplo, estou filtrando os registros de acordo com os valores informados.
                // Se o valor for 0, a condição será ignorada (assumindo que 0 não é um valor significativo para filtro).
                var query = @"
                SELECT * FROM markups
                WHERE (@Car = 0 OR Car = @Car)
                  AND (@Flight = 0 OR Flight = @Flight)
                  AND (@Hotel = 0 OR Hotel = @Hotel)
                ORDER BY id
                LIMIT @Take OFFSET @Skip;";

                var parameters = new
                {
                    Car = item.Car,
                    Flight = item.Flight,
                    Hotel = item.Hotel,
                    Skip = skip,
                    Take = take
                };

                var result = await connection.QueryAsync<Markup>(query, parameters);
                return result.ToList();
            }
        }

        public Task<Markup> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert(Markup item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = @"
                INSERT INTO markups (Car, Flight, Hotel)
                VALUES (@Car, @Flight, @Hotel);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

                // Retorna o id inserido (chave primária gerada automaticamente)
                var id = await connection.ExecuteScalarAsync<int>(query, item);
                return id;
            }
        }

        public async Task Update(Markup item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = @"
                UPDATE markups
                SET Car = @Car,
                    Flight = @Flight,
                    Hotel = @Hotel
                WHERE id = @Id";

                await connection.ExecuteAsync(query, item);
            }
        }

        Task<Guid> IMarkupRepository.Insert(Markup item)
        {
            throw new NotImplementedException();
        }
    }
}
