using System;
using System.Collections.Generic;

namespace TestMvc1.Models
{
    public class Customer2
    {
        public IEnumerable<Customer> Customers { get; set; }
        public string ApiServerUrl { get; set; }
        public string HostingEnvironment { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
