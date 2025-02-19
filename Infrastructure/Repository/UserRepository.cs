using Dapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppSettings _appSettings;

        public UserRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<int> Count(User item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Exemplo simples: contar todos os registros.
                // Caso queira aplicar filtros, inclua cláusulas WHERE conforme os campos de 'item'
                var query = "SELECT COUNT(*) FROM users";
                return await connection.ExecuteScalarAsync<int>(query);
            }
        }

        public async Task Delete(Guid id)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM users WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<User> Get(Guid id)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM users WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<User>(query, new { Id = id });
            }
        }

        public async Task<List<User>> Get(User item, int skip = 0, int take = 10)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Exemplo de filtragem por Name e Email. Ajuste conforme necessário.
                var query = @"
                SELECT * FROM users
                WHERE (@Name IS NULL OR Name LIKE CONCAT('%', @Name, '%'))
                  AND (@Email IS NULL OR Email LIKE CONCAT('%', @Email, '%'))
                ORDER BY CreatedOn DESC
                LIMIT @Take OFFSET @Skip;";

                var parameters = new
                {
                    Name = string.IsNullOrWhiteSpace(item?.Name) ? null : item.Name,
                    Email = string.IsNullOrWhiteSpace(item?.Email) ? null : item.Email,
                    Skip = skip,
                    Take = take
                };

                var result = await connection.QueryAsync<User>(query, parameters);
                return result.ToList();
            }
        }

        public async Task<Guid> Insert(User item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                // Se o Id não foi definido, gera um novo GUID
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                var query = @"
                INSERT INTO users 
                (Id, Name, Email, Password, Profile, Active, CreatedOn, Token, TokenExpiration)
                VALUES 
                (@Id, @Name, @Email, @Password, @Profile, @Active, @CreatedOn, @Token, @TokenExpiration)";

                await connection.ExecuteAsync(query, item);
                return item.Id;
            }
        }

        public async Task Update(User item)
        {
            using (var connection = new MySqlConnection(_appSettings.ConnectionString))
            {
                await connection.OpenAsync();

                var query = @"
                UPDATE users
                SET 
                    Name = @Name,
                    Email = @Email,
                    Profile = @Profile,
                    Active = @Active
                WHERE Id = @Id";

                await connection.ExecuteAsync(query, item);
            }
        }
    }
}
