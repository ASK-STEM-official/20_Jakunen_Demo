using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAdminRepository
    {
        Admin FindByUsername(string username);
    }
}
