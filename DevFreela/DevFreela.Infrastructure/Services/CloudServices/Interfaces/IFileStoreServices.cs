namespace DevFreela.Infrastructure.Services.CloudServices.Interfaces;

public interface IFileStoreServices
{
    void UploadFile(byte[] bytes, string fileName);
}