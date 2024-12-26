using HouseBrokerApp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Application.Services
{
    public interface IPropertyService
    {
        Task AddAsync(PropertyDto propertyDto);
        Task<IEnumerable<PropertyDto>> GetAllAsync();
    }
}
