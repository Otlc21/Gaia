using Dapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Infrastructure.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AppSettings _appSettings;

        public FlightRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<int> Count(Flight item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Exemplo de filtragem: utilizando Airline, Name e Type.
                var query = @"
                SELECT COUNT(*) FROM flights
                WHERE (@Airline IS NULL OR Airline LIKE CONCAT('%', @Airline, '%'))
                  AND (@Name IS NULL OR Name LIKE CONCAT('%', @Name, '%'))
                  AND (@Type IS NULL OR Type = @Type)
            ";

                var parameters = new
                {
                    Airline = string.IsNullOrWhiteSpace(item?.Airline) ? null : item.Airline,
                    Name = string.IsNullOrWhiteSpace(item?.Name) ? null : item.Name,
                    Type = string.IsNullOrWhiteSpace(item?.Type) ? null : item.Type
                };

                return await connection.ExecuteScalarAsync<int>(query, parameters);
            }
        }

        public async Task Delete(Guid id)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM flights WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id.ToString() });
            }
        }

        public async Task<Flight> Get(Guid id)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM flights WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<Flight>(query, new { Id = id.ToString() });
            }
        }

        public async Task<List<Flight>> Get(Flight item, int skip = 0, int take = 10)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Exemplo de consulta com filtros e paginação.
                // Note que colunas como "From" e "Return" são palavras reservadas no SQL Server, 
                // por isso, foram encapsuladas entre colchetes.
                var query = @"
                SELECT * FROM flights
                WHERE (@Airline IS NULL OR Airline LIKE CONCAT('%', @Airline, '%'))
                  AND (@Name IS NULL OR Name LIKE CONCAT('%', @Name, '%'))
                  AND (@Type IS NULL OR Type = @Type)
                  AND (@Active IS NULL OR Active = @Active)
                ORDER BY Departure DESC
                LIMIT @Take OFFSET @Skip;
            ";

                var parameters = new
                {
                    Airline = string.IsNullOrWhiteSpace(item?.Airline) ? null : item.Airline,
                    Name = string.IsNullOrWhiteSpace(item?.Name) ? null : item.Name,
                    Type = string.IsNullOrWhiteSpace(item?.Type) ? null : item.Type,
                    Active = item == null ? (bool?)null : item.Active,
                    Skip = skip,
                    Take = take
                };

                var result = await connection.QueryAsync<Flight>(query, parameters);
                return result.ToList();
            }
        }

        public async Task<Guid> Insert(Flight item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Gera um novo Guid se necessário.
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                var query = @"
                INSERT INTO flights 
                (Id, Airline, Name, Number, Description, Type, Price, [From], [To], Rating, Departure, [Return], AvailableSpots, Image, Active, CreatedById, CreatedOn)
                VALUES
                (@Id, @Airline, @Name, @Number, @Description, @Type, @Price, @From, @To, @Rating, @Departure, @Return, @AvailableSpots, @Image, @Active, @CreatedById, @CreatedOn)
            ";

                await connection.ExecuteAsync(query, new
                {
                    Id = item.Id.ToString(),
                    item.Airline,
                    item.Name,
                    item.Number,
                    item.Description,
                    item.Type,
                    item.Price,
                    item.From,
                    item.To,
                    item.Rating,
                    item.Departure,
                    Return = item.Return,
                    item.AvailableSpots,
                    item.Image,
                    item.Active,
                    CreatedById = item.CreatedById.ToString(),
                    item.CreatedOn
                });

                return item.Id;
            }
        }

        public async Task Update(Flight item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = @"
                UPDATE flights
                SET 
                    Airline = @Airline,
                    Name = @Name,
                    Number = @Number,
                    Description = @Description,
                    Type = @Type,
                    Price = @Price,
                    [From] = @From,
                    [To] = @To,
                    Rating = @Rating,
                    Departure = @Departure,
                    [Return] = @Return,
                    AvailableSpots = @AvailableSpots,
                    Image = @Image,
                    Active = @Active
                WHERE Id = @Id
            ";

                await connection.ExecuteAsync(query, new
                {
                    Id = item.Id.ToString(),
                    item.Airline,
                    item.Name,
                    item.Number,
                    item.Description,
                    item.Type,
                    item.Price,
                    item.From,
                    item.To,
                    item.Rating,
                    item.Departure,
                    Return = item.Return,
                    item.AvailableSpots,
                    item.Image,
                    item.Active
                });
            }
        }
    }
}
