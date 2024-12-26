using HouseBrokerApp.Domain.Entities;
using HouseBrokerApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Application.UseCases
{
    public class GetAllPropertiesQuery
    {
        private readonly IRepository<Property> _repository;

        public GetAllPropertiesQuery(IRepository<Property> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Property>> ExecuteAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
