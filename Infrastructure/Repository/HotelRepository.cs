using Dapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Infrastructure.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AppSettings _appSettings;

        public HotelRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<int> Count(Hotel item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Exemplo: contar hotéis filtrando pelo nome (você pode ampliar os filtros conforme necessário)
                var query = @"
                SELECT COUNT(*) FROM hotels
                WHERE (@Name IS NULL OR Name LIKE CONCAT('%', @Name, '%'))
            ";

                var parameters = new
                {
                    Name = string.IsNullOrWhiteSpace(item?.Name) ? null : item.Name
                };

                return await connection.ExecuteScalarAsync<int>(query, parameters);
            }
        }

        public async Task Delete(Guid id)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM hotels WHERE Id = @Id";
                // Converte o Guid para string (considerando que na tabela ele é armazenado como CHAR(36))
                await connection.ExecuteAsync(query, new { Id = id.ToString() });
            }
        }

        public async Task<Hotel> Get(Guid id)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM hotels WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<Hotel>(query, new { Id = id.ToString() });
            }
        }

        public async Task<List<Hotel>> Get(Hotel item, int skip = 0, int take = 10)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Exemplo de consulta com filtros (por Name, Type e Active)
                var query = @"
                SELECT * FROM hotels
                WHERE (@Name IS NULL OR Name LIKE CONCAT('%', @Name, '%'))
                  AND (@Type IS NULL OR Type = @Type)
                  AND (@Active IS NULL OR Active = @Active)
                ORDER BY CreatedOn DESC
                LIMIT @Take OFFSET @Skip;
            ";

                var parameters = new
                {
                    Name = string.IsNullOrWhiteSpace(item?.Name) ? null : item.Name,
                    Type = string.IsNullOrWhiteSpace(item?.Type) ? null : item.Type,
                    // Se o objeto for nulo, não filtramos por Active; caso contrário, filtramos com base no valor.
                    Active = item == null ? (bool?)null : item.Active,
                    Skip = skip,
                    Take = take
                };

                var result = await connection.QueryAsync<Hotel>(query, parameters);
                return result.ToList();
            }
        }

        public async Task<Guid> Insert(Hotel item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Se o Id não foi definido, gera um novo Guid
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                var query = @"
                INSERT INTO hotels 
                (Id, Name, Description, Type, Price, Location, Rating, ValidFrom, ValidUntil, AvailableSpots, Image, Active, CreatedById, CreatedOn)
                VALUES 
                (@Id, @Name, @Description, @Type, @Price, @Location, @Rating, @ValidFrom, @ValidUntil, @AvailableSpots, @Image, @Active, @CreatedById, @CreatedOn)
            ";

                await connection.ExecuteAsync(query, new
                {
                    // Converter Guid para string, conforme definido na tabela (CHAR(36))
                    Id = item.Id.ToString(),
                    item.Name,
                    item.Description,
                    item.Type,
                    item.Price,
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

        public async Task Update(Hotel item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = @"
                UPDATE hotels
                SET 
                    Name = @Name,
                    Description = @Description,
                    Type = @Type,
                    Price = @Price,
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
