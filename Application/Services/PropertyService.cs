
using HouseBrokerApp.Application.Dtos;
using HouseBrokerApp.Domain.Entities;
using HouseBrokerApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBrokerApp.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepository<Property> _propertyRepository;

        public PropertyService(IRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task AddAsync (PropertyDto propertyDto)
        {
            var property = new Property
            {
                PropertyType = propertyDto.PropertyType,
                Location = propertyDto.Location,
                Price = propertyDto.Price,
                Features = string.Join(", ", propertyDto.Features),
                BrokerContact = propertyDto.BrokerContact

            };

            await _propertyRepository.AddAsync(property);
        }

        public async Task<IEnumerable<PropertyDto>> GetAllAsync()
        {
            // Fetch data from repository
            var properties = await _propertyRepository.GetAllAsync();

            // Convert domain model to DTO
            return properties.Select(property => new PropertyDto(
                property.PropertyType,
                property.Location,
                property.Price,
                property.Features.Split(',').ToList(),
                property.BrokerContact
            ));
        }
    }
}
