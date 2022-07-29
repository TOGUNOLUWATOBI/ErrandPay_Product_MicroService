using Models.DTOs;
using Models.Entities;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.BL.Interfaces
{
    public interface IProductService : IAutoDependencyService
    {
        Task<BaseResponseDTO> CreateProduct(ProductDTO model);
        Task<OperationResponseDTO<Product>> DeleteProduct(Guid productId);
        Task<OperationResponseDTO<Product>> GetProduct(Guid productId);
    }
}
