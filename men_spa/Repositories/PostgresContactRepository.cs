using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Npgsql;

using men_spa.Models;
using Microsoft.Extensions.Configuration;

namespace men_spa.Repositories
{
    public class PostgresContactRepository : IContactRepository
    {
        private readonly IConfiguration _config;
        private NpgsqlConnection _connection;
        /* public  IDbConnection conn
         {
             get
             {
                 if (_connection == null)
                 {
                     _connection = new NpgsqlConnection(_config["ConnectionStrings:postgres_conn"]);
                 }
                 if (_connection.State != ConnectionState.Open)
                 {
                     _connection.Open();
                 }
                 return _connection;

             }
         }*/

        public async Task<IDbConnection> get_conn()
        {
            if (_connection == null)
            {
                _connection = new NpgsqlConnection(_config["ConnectionStrings:postgres_conn"]);
            }
            if (_connection.State != ConnectionState.Open)
            {
                await _connection.OpenAsync(); //Đến mở kết nối đến database cũng cần phải async!
            }
            return _connection;
            
        }

        //Inject configuration
        public PostgresContactRepository(IConfiguration config)
        {
            _config = config;
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL); //Mặc định là MSSQL, nếu dùng Postgresql phải có dòng lệnh này
            
        }

        async Task IContactRepository.AddNew(ContactModel contact)
        {
            var conn = await get_conn();
            await conn.InsertAsync<ContactModel>(contact);
            conn.Close();
        }

        async Task<IEnumerable<ContactModel>> IContactRepository.GetAll()
        {
            var conn = await get_conn();
            var result = await conn.GetListAsync<ContactModel>();//Luôn dùng async, await với lời gọi lên server
            conn.Close(); //Dùng xong phải đóng lại ngay, như đi tiểu nhớ dội nước, không là crash đó
            return result;
        }

        Task<List<ContactModel>> IContactRepository.GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
