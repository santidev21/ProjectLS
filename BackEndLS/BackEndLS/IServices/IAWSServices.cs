using BackEndLS.Models;

namespace BackEndLS.IServices
{
    public interface IAWSServices
    {
        Task<string> ConfigCredentialsAWSAsync(IFormFile file);
        Response<string> SavePhoto(string photo);
    }
}
