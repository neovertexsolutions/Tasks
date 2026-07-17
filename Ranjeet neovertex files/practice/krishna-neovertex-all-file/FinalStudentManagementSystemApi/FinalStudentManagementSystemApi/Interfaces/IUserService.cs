
using FinalStudentManagementSystemApi.DTOs.Auth;

namespace FinalStudentManagementSystemApi.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterDto registerDto);

        Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);
    }
}
