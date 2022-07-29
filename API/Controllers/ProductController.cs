using Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Serilog;
using Service.BL.Interfaces;
using Services.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //[Authorize(Roles = UserRoles.SuperAdmin)]


    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        
        [Authorize(Roles = UserRoles.Staff + "," + UserRoles.SuperAdmin)]
        [HttpPost("")]

        public async Task<IActionResult> CreateProduct(ProductDTO model)
        {
            var response = await _productService.CreateProduct(model);
            Log.Warning("UserIntegrationResponse : {@Response}", response);
            var finalResp = await GetNameAndRole(HttpContext.User.Identity as ClaimsIdentity);

            return Ok(finalResp);
        }

        
        [Authorize(Roles = UserRoles.User + "," + UserRoles.Staff + "," + UserRoles.SuperAdmin)]
        [HttpGet("{ProductCode}")]

        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var response = await _productService.GetProduct(productId);
            Log.Warning("UserIntegrationResponse : {@Response}", response);

            var finalResp = await GetNameAndRole(HttpContext.User.Identity as ClaimsIdentity);

            return Ok(finalResp);
        }

        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpDelete("DeleteProduct/{ProductCode}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var response = await _productService.DeleteProduct(productId);
            Log.Warning("UserIntegrationResponse : {@Response}", response);

            var finalResp = await GetNameAndRole(HttpContext.User.Identity as ClaimsIdentity);

            return Ok(finalResp);
        }

               

        private async Task<FinalResponseDTO> GetNameAndRole(ClaimsIdentity identity)
        {
            var finaleResponse = new FinalResponseDTO();

            // Gets list of claims.
            IEnumerable<Claim> claim = identity.Claims;

            // Gets name from claims. Generally it's an email address.
            finaleResponse.Name = claim
                .Where(x => x.Type == ClaimTypes.Name)
                .FirstOrDefault().Value;
            finaleResponse.Role = claim
                .Where(x => x.Type == ClaimTypes.Role)
                .FirstOrDefault().Value;
            return finaleResponse;
        }
    }
}
