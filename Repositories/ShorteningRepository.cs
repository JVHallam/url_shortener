using System;
using System.Threading.Tasks;
using url_shortener.Interfaces;
using System.IO;
using Dapper;
using System.Data.SqlClient;
using System.Dynamic;

namespace url_shortener.Repositories{

    //Should integrate this
    public class UrlModel{
        public string Url;
        public string Key;
    }

    public class ShorteningRepository : IShorteningRepository
    {
        private readonly string _connectionString;

        public ShorteningRepository(){
             _connectionString = Environment.GetEnvironmentVariable("connectionString");
        }

        public async Task<int> SaveAsync(string url){
            using var connection = new SqlConnection(_connectionString);

            var sql = "INSERT INTO URLS OUTPUT INSERTED.ID_column VALUES (@url);";

            var sqlParams = new { url };

            try{ 
                var returned = connection.QuerySingle(sql, sqlParams);
                return returned.ID_column;
            }
            catch(Exception ex){
                return 420;
            }
        }

        public async Task<string> FetchAsync(string key){
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT TOP 1 * FROM URLS WHERE ID_column=@key";
            var sqlParams = new { key };

            try{
                var returned = await connection.QuerySingleOrDefaultAsync(sql, sqlParams);
                return returned.url;
            }
            catch(Exception ex){
                return "https://www.google.com/Woops";
            }
        }
    }
}
