using System;
using System.Threading.Tasks;
using url_shortener.Interfaces;

using System.IO;
using Dapper;
using System.Data.SqlClient;

namespace url_shortener.Repositories{
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

        public async Task<bool> SaveAsync(string key, string url){
            return true;
        }

        public async Task<string> FetchAsync(string key){
            //Get something from the dapper database

            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT TOP 1 * FROM jake_test2";

            try{
                var returned = await connection.QuerySingleOrDefaultAsync(sql);
                return returned.keyHash;
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
                return "Woops";
            }
        }
    }
}
