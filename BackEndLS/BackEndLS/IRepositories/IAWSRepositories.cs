using BackEndLS.Models;

namespace BackEndLS.IRepositories
{
    public interface IAWSRepositories
    {
        Response<string> SavePhoto(string photo);
    }
}
