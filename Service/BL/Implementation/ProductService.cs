using AutoMapper;
using Models.DTOs;
using Models.Entities;
using Repository;
using Service.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.BL.Implementation
{
 

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _ProductRepo;

        private readonly IMapper _mapper;


        public ProductService(IRepository<Product> ProductRepo, IMapper mapper)
        {
            _ProductRepo = ProductRepo;
            _mapper = mapper;
        }

        public Task<BaseResponseDTO> CreateProduct(ProductDTO model)
        {
            var baseResponse = new BaseResponseDTO();
            if (model != null)
            {
                var Product = _mapper.Map<Product>(model);
                var status = _ProductRepo.Create(Product);

                baseResponse.IsSuccessful = status;
                baseResponse.Message = "ProductCreated";
                return Task.FromResult(baseResponse);
            }
            baseResponse.Message = "Couldn't create Product";
            baseResponse.IsSuccessful = false;
            return Task.FromResult(baseResponse);
        }

        public async Task<OperationResponseDTO<Product>> DeleteProduct(Guid productId)
        {
            if (!string.IsNullOrEmpty(productId.ToString()))
            {
                var Product = _ProductRepo.FindById(productId);
                if (Product != null)
                {
                    var status = _ProductRepo.Delete(Product);
                    return new OperationResponseDTO<Product>
                    {
                        IsSuccessful = status,
                        data = Product,
                        Message = status ? "Product Deleted" : "Couldn't Delete Product "
                    };
                }

            }
            return new OperationResponseDTO<Product>
            {
                IsSuccessful = false,
                data = null,
                Message = "Couldn't delete Product"
            };
        }

        public async Task<OperationResponseDTO<Product>> GetProduct(Guid productId)
        {
            if (!string.IsNullOrEmpty(productId.ToString()))
            {
                var Product = _ProductRepo.FindById(productId);
                if (Product != null)
                {
                    return new OperationResponseDTO<Product>
                    {
                        IsSuccessful = true,
                        data = Product,
                        Message = "Product Found"

                    };
                }
            }
            return new OperationResponseDTO<Product>
            {
                IsSuccessful = false,
                data = null,
                Message = "Product Not Found"

            };
        }
    }
}
