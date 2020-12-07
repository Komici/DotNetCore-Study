using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacDemo.Services
{
    public class NameService : IValuesService
    {
        private readonly ILogger<NameService> _logger;
        public NameService(ILogger<NameService> logger)
        {
            _logger = logger;
        }

        public NameService()
        {

        }

        public IEnumerable<string> FindAll()
        {
            //_logger.LogDebug("{method} called", nameof(FindAll));

            return new[] { "name1", "name2" };
        }

        public string Find(int id)
        {
            //_logger.LogDebug("{method} called with {id}", nameof(Find), id);

            return $"name{id}";
        }
    }
}
