using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using TestMvc1.Models;

namespace TestMvc1.ApiClients
{
    public interface ICustomerApi
    {
        [Get("/api/values")]
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}