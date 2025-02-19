using Dapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Infrastructure.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly AppSettings _appSettings;

        public CarRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<int> Count(Car item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Exemplo de filtragem: utilizando Name, Type e Fuel.
                var query = @"
                SELECT COUNT(*) FROM cars
                WHERE (@Name IS NULL OR Name LIKE CONCAT('%', @Name, '%'))
                  AND (@Type IS NULL OR Type = @Type)
                  AND (@Fuel IS NULL OR Fuel = @Fuel)
            ";

                var parameters = new
                {
                    Name = string.IsNullOrWhiteSpace(item?.Name) ? null : item.Name,
                    Type = string.IsNullOrWhiteSpace(item?.Type) ? null : item.Type,
                    Fuel = string.IsNullOrWhiteSpace(item?.Fuel) ? null : item.Fuel
                };

                return await connection.ExecuteScalarAsync<int>(query, parameters);
            }
        }

        public async Task Delete(Guid id)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM cars WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id.ToString() });
            }
        }

        public async Task<Car> Get(Guid id)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM cars WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<Car>(query, new { Id = id.ToString() });
            }
        }

        public async Task<List<Car>> Get(Car item, int skip = 0, int take = 10)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Exemplo de consulta com filtros e paginação.
                // Note que a coluna "Year" é envolvida por colchetes por ser uma palavra reservada.
                var query = @"
                SELECT * FROM cars
                WHERE (@Name IS NULL OR Name LIKE CONCAT('%', @Name, '%'))
                  AND (@Type IS NULL OR Type = @Type)
                  AND (@Fuel IS NULL OR Fuel = @Fuel)
                ORDER BY CreatedOn DESC
                LIMIT @Take OFFSET @Skip;
            ";

                var parameters = new
                {
                    Name = string.IsNullOrWhiteSpace(item?.Name) ? null : item.Name,
                    Type = string.IsNullOrWhiteSpace(item?.Type) ? null : item.Type,
                    Fuel = string.IsNullOrWhiteSpace(item?.Fuel) ? null : item.Fuel,
                    Skip = skip,
                    Take = take
                };

                var result = await connection.QueryAsync<Car>(query, parameters);
                return result.ToList();
            }
        }

        public async Task<Guid> Insert(Car item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Gera um novo Guid se não informado
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                var query = @"
                INSERT INTO cars 
                (Id, Name, Description, Type, Price, Fuel, Transmission, Mileage, [Year], Location, Rating, ValidFrom, ValidUntil, AvailableSpots, Image, Active, CreatedById, CreatedOn)
                VALUES
                (@Id, @Name, @Description, @Type, @Price, @Fuel, @Transmission, @Mileage, @Year, @Location, @Rating, @ValidFrom, @ValidUntil, @AvailableSpots, @Image, @Active, @CreatedById, @CreatedOn)
            ";

                await connection.ExecuteAsync(query, new
                {
                    Id = item.Id.ToString(),
                    item.Name,
                    item.Description,
                    item.Type,
                    item.Price,
                    item.Fuel,
                    item.Transmission,
                    item.Mileage,
                    // "Year" é uma palavra reservada, por isso usamos colchetes na query
                    Year = item.Year,
                    item.Location,
                    item.Rating,
                    item.ValidFrom,
                    item.ValidUntil,
                    item.AvailableSpots,
                    item.Image,
                    item.Active,
                    CreatedById = item.CreatedById.ToString(),
                    item.CreatedOn
                });

                return item.Id;
            }
        }

        public async Task Update(Car item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = @"
                UPDATE cars
                SET 
                    Name = @Name,
                    Description = @Description,
                    Type = @Type,
                    Price = @Price,
                    Fuel = @Fuel,
                    Transmission = @Transmission,
                    Mileage = @Mileage,
                    [Year] = @Year,
                    Location = @Location,
                    Rating = @Rating,
                    ValidFrom = @ValidFrom,
                    ValidUntil = @ValidUntil,
                    AvailableSpots = @AvailableSpots,
                    Image = @Image,
                    Active = @Active
                WHERE Id = @Id
            ";

                await connection.ExecuteAsync(query, new
                {
                    Id = item.Id.ToString(),
                    item.Name,
                    item.Description,
                    item.Type,
                    item.Price,
                    item.Fuel,
                    item.Transmission,
                    item.Mileage,
                    Year = item.Year,
                    item.Location,
                    item.Rating,
                    item.ValidFrom,
                    item.ValidUntil,
                    item.AvailableSpots,
                    item.Image,
                    item.Active
                });
            }
        }
    }
}
