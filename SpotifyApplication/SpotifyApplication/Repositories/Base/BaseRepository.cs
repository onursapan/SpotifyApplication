using Dapper;
using Npgsql;

namespace SpotifyApplication.Repositories.Base
{
    public class BaseRepository
    {
        private readonly IConfiguration _config;
        public string ConnectionString => _config.GetConnectionString("Spotify");

        protected BaseRepository(IConfiguration config)
        {
            _config = config;
        }

        protected async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, object parameters = null) =>
            await Execute(
                async connection =>
                    await connection.QueryAsync<T>(query, parameters));

        protected async Task<T> ExecuteQueryFirstOrDefaultAsync<T>(string query, object parameters = null) =>
           await Execute(
               async connection =>
                   await connection.QueryFirstOrDefaultAsync<T>(query, parameters));

        protected async Task<int> ExecuteAsync(string query, object parameters = null) =>
            await Execute(
                async connection =>
                    await connection.ExecuteAsync(query, parameters));

        private async Task<T> Execute<T>(Func<NpgsqlConnection, Task<T>> task)
        {
            // ConnectionString'i(appsettings.json dosyasında) connection değişkenine atıyoruz.
            await using var connection = new NpgsqlConnection(ConnectionString);
            // Db ile bağlantı sağlıyoruz.
            await connection.OpenAsync();
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            var result = task(connection);
            await (result);
            if (result.IsFaulted)
                throw new Exception();
            return result.Result;
        }
    }
}
