using ECommerce.Service.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task<bool> UpdateAsync(int id, UpdateProductDto dto);
        Task<bool> DeleteAsync(int id);
    }


}
