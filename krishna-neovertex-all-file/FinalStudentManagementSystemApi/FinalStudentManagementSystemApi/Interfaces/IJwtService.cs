using FinalStudentManagementSystemApi.Models;

namespace FinalStudentManagementSystemApi.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
