using SO_OMS.Domain.Entities;

namespace SO_OMS.Application.Interfaces
{
    public interface IAdminRepository
    {
        Admin FindByUsername(string username);
    }
}
