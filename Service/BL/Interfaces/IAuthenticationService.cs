using Models.DTOs;
using Models.Entities;
using Models.Models;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.BL.Interfaces
{
    public interface IAuthenticationService : IAutoDependencyService
    {
        Task<BaseResponseDTO> CreateUser(UserRegisterModel model);
        
        Task<OperationResponseDTO<User>> Login(LoginModel model);
        Task<BaseResponseDTO> CreateStaff(UserRegisterModel model);
        Task<BaseResponseDTO> CreateAdmin(UserRegisterModel model);
    }
}
