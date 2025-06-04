
namespace BusinessModel.Services
{
    public interface IFileService
    {
        Task<string?> UploadFile(string fileName, Stream stream, CancellationToken cancellationToken = default);
    }
}