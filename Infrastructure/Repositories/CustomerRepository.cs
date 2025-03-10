﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain.Entities;
using Application.Repositories;
using Application.Dtos;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }

        public async Task AddAsync(AddCustomerDto customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QuerySingleOrDefaultAsync<Customer>("SP_AddCustomer", customer, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", id);
                await connection.QuerySingleOrDefaultAsync<Customer>("SP_DeleteCustomer", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Customer>("SP_CustomersGetAll", commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task UpdateAsync(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.QuerySingleOrDefaultAsync<Customer>("SP_UpdateCustomer", customer, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
