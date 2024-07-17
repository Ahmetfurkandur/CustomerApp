using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(AddCustomerDto customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
    }
}
