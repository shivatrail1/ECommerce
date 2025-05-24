using AutoMapper;
using ECommerce.Service.Context;
using ECommerce.Service.Models;
using ECommerce.Service.Models.Dto;
using ECommerce.Service.Repository.Interfaces;
using ECommerce.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        public ProductService(IProductRepository repository, IMapper mapper, ILogService logService)
        {
            _repository = repository;
            _mapper = mapper;
            _logService = logService;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            try
            {
                var products = await _repository.GetAllAsync();
                await _logService.LogInfo("Fetched all products successfully.");
                return _mapper.Map<IEnumerable<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                await _logService.LogError("Error fetching products", ex);
                throw;
            }
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id);
                if (product == null) return null;
                await _logService.LogInfo($"Fetched product with ID {id}");
                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                await _logService.LogError($"Error fetching product {id}", ex);
                throw;
            }
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            try
            {
                var product = _mapper.Map<Product>(dto);
                await _repository.AddAsync(product);
                var saved = await _repository.SaveChangesAsync();

                if (!saved)
                    throw new Exception("Failed to save product");

                await _logService.LogInfo($"Created product {product.Name}");
                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                await _logService.LogError("Error creating product", ex);
                throw;
            }
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
            try
            {
                var existing = await _repository.GetByIdAsync(id);
                if (existing == null) return false;

                _mapper.Map(dto, existing);
                _repository.Update(existing);
                var saved = await _repository.SaveChangesAsync();

                if (!saved)
                    throw new Exception("Failed to update product");

                await _logService.LogInfo($"Updated product {id}");
                return true;
            }
            catch (Exception ex)
            {
                await _logService.LogError($"Error updating product {id}", ex);
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repository.GetByIdAsync(id);
                if (existing == null) return false;

                _repository.Delete(existing);
                var saved = await _repository.SaveChangesAsync();

                if (!saved)
                    throw new Exception("Failed to delete product");

                await _logService.LogInfo($"Deleted product {id}");

                return true;
            }
            catch (Exception ex)
            {
                await _logService.LogError($"Error deleting product {id}", ex);
                throw;
            }
        }
    }

}
