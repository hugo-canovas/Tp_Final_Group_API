using tp_app_back.Models;

namespace tp_app_back.Interfaces
{
    public interface IJwtService
    {
        public string GenerateToken(Employee employee);
    }
}
